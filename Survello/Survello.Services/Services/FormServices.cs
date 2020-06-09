using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Survello.Database;
using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.CustomExceptions;
using Survello.Services.DTOEntities;
using Survello.Services.DTOMappers;
using Survello.Services.Provider.Contract;
using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Services.Services
{
    public class FormServices : IFormServices
    {
        private readonly SurvelloContext dbcontext;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IBlobServices blobServices;
        public FormServices(SurvelloContext dbcontext, IDateTimeProvider dateTimeProvider, IBlobServices blobServices)
        {
            this.dbcontext = dbcontext;
            this.dateTimeProvider = dateTimeProvider;
            this.blobServices = blobServices;
        }
        public async Task<FormDTO> CreateFormAsync(FormDTO tempForm)
        {
            if (tempForm == null)
            {
                throw new BusinessLogicException(ExceptionMessages.EntityNull);
            }
            if (tempForm.Title == null)
            {
                throw new BusinessLogicException(ExceptionMessages.TitleNull);
            }

            var form = tempForm.MapFrom();
            form.CreatedOn = dateTimeProvider.GetDateTime();

            form.Id = Guid.NewGuid();

            await this.dbcontext.Forms.AddAsync(form);
            await this.dbcontext.SaveChangesAsync();

            var formDto = form.MapFrom();

            return formDto;
        }

        public async Task<bool> DeleteFormAsync(Guid id)
        {
            var form = await this.dbcontext.Forms
                    .FirstOrDefaultAsync(f => f.Id == id)
                    ?? throw new BusinessLogicException(ExceptionMessages.EntityNotFound);

            form.IsDeleted = true;
            form.DeletedOn = this.dateTimeProvider.GetDateTime();

            await this.dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<FormDTO> GetFormAsync(Guid id)
        {
            var form = await this.dbcontext.Forms
                .Where(f => f.Id == id)
                .Include(f => f.TextQuestions)
                .Include(f => f.MultipleChoiceQuestions)
                    .ThenInclude(mq => mq.Options)
                .Include(f => f.DocumentQuestions)
                .FirstOrDefaultAsync()
                ?? throw new BusinessLogicException(ExceptionMessages.EntityNotFound);

            var formDto = form.MapFrom();

            return formDto;
        }

        public async Task<ICollection<FormDTO>> GetUserFormsAsync(Guid userId)
        {
            var forms = await this.dbcontext.Forms
                .Where(f => f.UserId == userId)
                .Include(f => f.TextQuestions)
                .Include(f => f.MultipleChoiceQuestions)
                    .ThenInclude(mq => mq.Options)
                .Include(f => f.DocumentQuestions)
                .ToListAsync();

            if (forms.Count == 0)
            {
                throw new BusinessLogicException(ExceptionMessages.ListNull);
            }

            var formsDto = forms.MapFrom();

            return formsDto;
        }

        public IQueryable<ListFormsDTO> Sort(string sortOrder, Guid userId)
        {
            var forms = this.dbcontext.Forms.Where(f => f.UserId == userId);

            switch (sortOrder)
            {
                case "title_desc":
                    forms = forms.OrderByDescending(f => f.Title);
                    break;
                case "CreatedOn":
                    forms = forms.OrderBy(f => f.CreatedOn);
                    break;
                case "createdon_desc":
                    forms = forms.OrderByDescending(f => f.CreatedOn);
                    break;
                case "NumberOfFilledForms":
                    forms = forms.OrderBy(f => f.NumberOfFilledForms);
                    break;
                case "numberoffilledforms_desc":
                    forms = forms.OrderByDescending(f => f.NumberOfFilledForms);
                    break;
            }

            return forms.Include(f => f.TextQuestions)
                         .Include(f => f.MultipleChoiceQuestions)
                             .ThenInclude(mq => mq.Options)
                         .Include(f => f.DocumentQuestions)
                         .Select(f => f.MapToListFormsDTO());
        }

        public async Task<bool> CreateAnswer(FormDTO formDto)
        {
            Guid corelationToken = Guid.NewGuid();

            await this.SaveTextAnswers(formDto.TextQuestions, corelationToken);

            await this.SaveMultipleChoiceAnswers(formDto.MultipleChoiceQuestions, corelationToken);

            await this.SaveDocumentAnswers(formDto.DocumentQuestions, corelationToken);

            var form = await this.dbcontext.Forms
                    .FirstOrDefaultAsync(f => f.Id == formDto.Id)
                    ?? throw new Exception(ExceptionMessages.EntityNotFound);

            form.NumberOfFilledForms++;

            await this.dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<FormDTO> GetFilledForm(Dictionary<string, string> paramss)
        {
            var idForm = Guid.Parse(paramss["idForm"]);
            var idToken = Guid.Parse(paramss["idToken"]);

            var form = await this.dbcontext.Forms
                .Where(f => f.Id == idForm)
                .Include(f => f.TextQuestions)
                   .ThenInclude(a => a.Answers)
                .Include(f => f.MultipleChoiceQuestions)
                    .ThenInclude(mq => mq.Options)
                 .Include(f => f.MultipleChoiceQuestions)
                    .ThenInclude(a => a.Answers)
                .Include(f => f.DocumentQuestions)
                    .ThenInclude(a => a.Answers)
                .FirstOrDefaultAsync()
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var formResult = new Form();
            formResult.Title = form.Title;
            formResult.Description = form.Description;
            formResult.CreatedOn = form.CreatedOn;

            foreach (var item in form.TextQuestions)
            {
                for (int i = 0; i < item.Answers.Count; i++)
                {
                    form.TextQuestions.Any(t => t.Answers
                    .Remove(t.Answers
                    .Where(a => a.CorelationToken != idToken)
                    .FirstOrDefault()));
                }
            }

            foreach (var item in form.DocumentQuestions)
            {
                for (int i = 0; i < item.Answers.Count; i++)
                {
                    form.DocumentQuestions.Any(t => t.Answers
                    .Remove(t.Answers
                    .Where(a => a.CorelationToken != idToken)
                    .FirstOrDefault()));
                }
            }

            foreach (var item in form.MultipleChoiceQuestions)
            {
                for (int j = 0; j < item.Answers.Count; j++)
                {
                    form.MultipleChoiceQuestions.Any(t => t.Answers
                    .Remove(t.Answers
                    .Where(a => a.CorelationToken != idToken)
                    .FirstOrDefault()));
                }
            }

            return form.MapFrom();
        }

        public async Task<FormDTO> GetFormWithAllAnswers(Guid id)
        {
            var form = await this.dbcontext.Forms
                .Where(f => f.Id == id)
                .Include(f => f.TextQuestions)
                     .ThenInclude(q => q.Answers)
                .Include(f => f.MultipleChoiceQuestions)
                     .ThenInclude(q => q.Options)
                .Include(f => f.MultipleChoiceQuestions)
                     .ThenInclude(q => q.Answers)
                .Include(f => f.DocumentQuestions)
                     .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync()
                ?? throw new BusinessLogicException(ExceptionMessages.EntityNotFound);

            var allCorelations = new List<Guid>();

            if (form.TextQuestions.Count > 0)
            {
                foreach (var item in
                    from item in form.TextQuestions
                    where item.Answers != null
                    select item)
                {
                    allCorelations.AddRange(item.Answers
                                  .Select(t => t.CorelationToken));
                }
            }

            if (form.DocumentQuestions.Count > 0)
            {
                foreach (var item in
                    from item in form.DocumentQuestions
                    where item.Answers != null
                    select item)
                {
                    allCorelations.AddRange(item.Answers
                                  .Select(t => t.CorelationToken));
                }
            }

            if (form.MultipleChoiceQuestions.Count > 0)
            {
                foreach (var item in
                    from item in form.MultipleChoiceQuestions
                        where item.Answers != null
                    select item)
                {
                    allCorelations.AddRange(item.Answers
                                  .Select(t => t.CorelationToken));
                }
            }

            var distinctGuids = allCorelations.Distinct().ToList();

            var formdto = form.MapFrom();
            formdto.CorelationTokens = distinctGuids;

            return formdto;
        }

        private async Task SaveTextAnswers(ICollection<TextQuestionDTO> textQuestions, Guid token)
        {
            foreach (var item in textQuestions)
            {
                if (item.Answer != null)
                {
                    var answer = new TextAnswer();
                    answer.Answer = item.Answer;
                    answer.CorelationToken = token;
                    answer.TextQuestionId = item.Id;

                    await this.dbcontext.TextAnswers.AddAsync(answer);
                }
            }
        }

        private async Task SaveMultipleChoiceAnswers(ICollection<MultipleChoiceQuestionDTO> multipleQuestions, Guid token)
        {
            foreach (var question in multipleQuestions)
            {
                foreach (var option in question.Options)
                {
                    if (option.Answer != null)
                    {
                        var answer = new MultipleChoiceAnswer();
                        answer.MultipleChoiceQuestionId = question.Id;
                        answer.Answer = option.Answer;
                        answer.CorelationToken = token;

                        await this.dbcontext.MultipleChoiceAnswers.AddAsync(answer);
                    }
                }
            }
        }

        private async Task SaveDocumentAnswers(ICollection<DocumentQuestionDTO> documentQuestions, Guid token)
        {
            foreach (var question in documentQuestions)
            {
                if (question.Files != null)
                {
                    foreach (var file in question.Files)
                    {
                        var filePath = await this.blobServices.UploadAsync(file, token, question.Id)
                        ?? throw new BusinessLogicException(ExceptionMessages.BlobError);

                        var answer = new DocumentAnswer();
                        answer.CorelationToken = token;
                        answer.DocumentQuestionId = question.Id;
                        answer.FileName = filePath;

                        await this.dbcontext.DocumentAnswers.AddAsync(answer);
                    }
                }
            }
        }
    }
}

