using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Survello.Database;
using Survello.Models.Entites;
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

        public async Task<bool> SaveAnswerForm(FormDTO formDto)
        {
            Guid corelationToken = Guid.NewGuid();

            foreach (var item in formDto.TextQuestions)
            {
                if (item.Answer != null)
                {
                    var answer = new TextAnswer();
                    answer.Answer = item.Answer;
                    answer.CorelationToken = corelationToken;
                    answer.TextQuestionId = item.Id;

                    await this.dbcontext.TextAnswers.AddAsync(answer);
                }
            }

            foreach (var question in formDto.MultipleChoiceQuestions)
            {
                foreach (var option in question.Options)
                {
                    if (option.Answer != null && option.Answer != "false")
                    {
                        var answer = new MultipleChoiceAnswer();
                        answer.MultipleChoiceOptionId = option.Id;
                        answer.CorelationToken = corelationToken;

                        await this.dbcontext.MultipleChoiceAnswers.AddAsync(answer);
                    }
                }
            }

            foreach (var question in formDto.DocumentQuestions)
            {
                if (question.Files != null)
                {
                    var filePath = await this.blobServices.UploadAsync(question.Files, corelationToken, question.Id);
                    var answer = new DocumentAnswer();

                    answer.CorelationToken = corelationToken;
                    answer.DocumentQuestionId = question.Id;
                    answer.FileName = filePath;

                    await this.dbcontext.DocumentAnswers.AddAsync(answer);
                }
            }
            var form = this.dbcontext.Forms
                    .FirstOrDefault(f => f.Id == formDto.Id) ?? throw new Exception(ExceptionMessages.EntityNotFound);

            form.NumberOfFilledForms++;           
            await this.dbcontext.SaveChangesAsync();
            
            return true;
        }
    }
}
