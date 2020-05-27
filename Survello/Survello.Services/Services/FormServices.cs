using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Survello.Database;
using Survello.Services.ConstantMessages;
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
                throw new Exception(ExceptionMessages.EntityNull);
            }

            var form = tempForm.MapFrom();

            await this.dbcontext.Forms.AddAsync(form);
            await this.dbcontext.SaveChangesAsync();

            var formDto = form.MapFrom();

            return formDto;
        }

        public async Task<bool> DeleteFormAsync(Guid id)
        {
            var form = await this.dbcontext.Forms
                .FirstOrDefaultAsync(f => f.Id == id)
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            form.IsDeleted = true;
            form.DeletedOn = this.dateTimeProvider.GetDateTime();

            //TODO: Delete all questions in form

            await this.dbcontext.SaveChangesAsync();

            return true;
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
                throw new Exception(ExceptionMessages.ListNull);
            }

            var formsDto = forms.MapFrom();

            return formsDto;
        }

        public async Task<FormDTO> GetFormAsync(Guid id)
        {
            var form = await this.dbcontext.Forms
                .Where(f => f.Id == id)
                .Include(f => f.TextQuestions)
                .Include(f => f.MultipleChoiceQuestions)
                    .ThenInclude(mq => mq.Options)
                 .Include(f => f.DocumentQuestions)//TODO: Other type of questions to be included!
                .FirstOrDefaultAsync()
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var formDto = form.MapFrom();

            return formDto;
        }
        public async Task<ICollection<ListFormsDTO>> GetAllFormsAsync()
        {
            var forms = await this.dbcontext.Forms
                .Include(f => f.TextQuestions)
                .Include(f => f.MultipleChoiceQuestions)
                    .ThenInclude(f => f.Options)
                .Include(f => f.DocumentQuestions)
                .ToListAsync();

            if (forms.Count == 0)
            {
                throw new Exception(ExceptionMessages.ListNull);
            }

            var formsDto = forms.MapToListFormsDTO();

            return formsDto;
        }
        public async Task<FormDTO> GetAnswer(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAnswerForm(FormDTO form)
        {
            Guid corelationToken = Guid.NewGuid();

            foreach (var item in form.TextQuestions)
            {
                if (item.Answer != null)
                {
                    var answer = new TextAnswerDTO();
                    answer.Answer = item.Answer;
                    answer.CorelationToken = corelationToken;
                    answer.TextQuestionId = item.Id;

                    item.Answers.Add(answer);
                }
            }

            foreach (var question in form.MultipleChoiceQuestions)
            {
                foreach (var option in question.Options)
                {
                    if (option.Answer != null)
                    {
                        var answer = new MultipleChoiceAnswerDTO();
                        answer.Answer = option.Answer;
                        answer.CorelationToken = corelationToken;
                        answer.MultipleChoiceOptionId = option.Id;

                        option.Answers.Add(answer);
                    }
                }
            }

            foreach (var question in form.DocumentQuestions)
            {
                if (question.Files != null)
                {
                    await this.blobServices.Create(question.Files, corelationToken, question.Id);
                    var answer = new DocumentAnswerDTO();

                    answer.CorelationToken = corelationToken;
                    answer.DocumentQuestionId = question.Id;

                    question.Answers.Add(answer);
                }
            }

            var formEntity = form.MapFrom();

            await this.dbcontext.SaveChangesAsync();
            
            return true;
        }
    }
}
