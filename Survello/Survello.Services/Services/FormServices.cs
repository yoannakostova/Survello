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
using System.Text;
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
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.blobServices = blobServices ?? throw new ArgumentNullException(nameof(blobServices));
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
                case "LastModifiedOn":
                    forms = forms.OrderBy(f => f.LastModifiedOn);
                    break;
                case "lastmodifiedon_desc":
                    forms = forms.OrderByDescending(f => f.LastModifiedOn);
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
                .Include(f => f.DocumentQuestions)
                    .ThenInclude(a => a.Answers)
                .FirstOrDefaultAsync()
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var formResult = new Form();
            formResult.Title = form.Title;
            formResult.Description = form.Description;
            formResult.CreatedOn = form.CreatedOn;


            //foreach (var text in form.TextQuestions)
            //{
            //    var textQuestion = text;

            //    formResult.TextQuestions.Add(textQuestion);

            //    foreach (var item in text.Answers)
            //    {
            //        if (item.CorelationToken != idToken)
            //        {
            //            textQuestion.Answers.Remove(item);
            //        }
            //    }
            //}

            //foreach (var multiple in form.MultipleChoiceQuestions)
            //{
            //    var multipleQuestion = multiple;

            //    formResult.MultipleChoiceQuestions.Add(multipleQuestion);

            //    foreach (var option in multiple.Options)
            //    {
            //        multipleQuestion.Options.Add(option);

            //        foreach (var answer in option.Answers)
            //        {
            //            if (answer.CorelationToken != idToken)
            //            {
            //                option.Answers.Remove(answer);
            //            }
            //        }
            //    }
            //}

            //foreach (var document in form.DocumentQuestions)
            //{
            //    var documentQuestion = document;
            //    formResult.DocumentQuestions.Add(documentQuestion);

            //    foreach (var item in document.Answers)
            //    {
            //        if (item.CorelationToken != idToken)
            //        {
            //            documentQuestion.Answers.Remove(item);
            //        }
            //    }
            //}

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
                foreach (var option in item.Options)
                {
                    for (int j = 0; j < option.Answers.Count; j++)
                    {
                        var answer = option.Answers
                            .Where(a => a.CorelationToken != idToken)
                            .FirstOrDefault();

                        form.MultipleChoiceQuestions
                            .Any(t => t.Options
                            .Any(o => o.Answers
                            .Remove(answer)));
                    }
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
                     .ThenInclude(o => o.Answers)
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
                foreach (var option in 
                    from item in form.MultipleChoiceQuestions
                    from option in item.Options
                    where option.Answers != null
                    select option)
                {
                    allCorelations.AddRange(option.Answers
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
                        //TODO: Why I do that???????
                        if (option.Answer != "false")
                        {
                            var answer = new MultipleChoiceAnswer();
                            answer.MultipleChoiceOptionId = option.Id;
                            answer.Answer = option.Answer;
                            answer.CorelationToken = token;

                            await this.dbcontext.MultipleChoiceAnswers.AddAsync(answer);
                        }
                        else if (option.Option == "false" && option.Answer == "false")
                        {
                            var answer = new MultipleChoiceAnswer();
                            answer.MultipleChoiceOptionId = option.Id;
                            answer.Answer = option.Answer;
                            answer.CorelationToken = token;

                            await this.dbcontext.MultipleChoiceAnswers.AddAsync(answer);
                        }
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
