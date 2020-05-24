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

        public FormServices(SurvelloContext dbcontext, IDateTimeProvider dateTimeProvider)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dbcontext));
        }
        public async Task<CreateFormDTO> CreateFormAsync(CreateFormDTO tempForm)
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
        public async Task<ICollection<CreateFormDTO>> GetUserFormsAsync(Guid userId)
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

        public async Task<CreateFormDTO> GetFormAsync(Guid id)
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
    }
}