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
            this.dateTimeProvider = dateTimeProvider;
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

        public async Task<bool> DeleteFormQuestionAsync(Guid id)
        {
            var form = await this.dbcontext.Forms
                .FirstOrDefaultAsync(f => f.Id == id)
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

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
                    .ThenInclude(f => f.Answers) //TODO: Other type of questions to be included!
                .FirstOrDefaultAsync()
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var formDto = form.MapFrom();

            return formDto;
        }
        public async Task<ICollection<FormDTO>> GetAllFormsAsync()
        {
            var form = await this.dbcontext.Forms
                .Include(f => f.TextQuestions)
                    .ThenInclude(f => f.Answers)
                .ToListAsync();

            //if (form.Count == 0)
            //{
            //    throw new Exception(ExceptionMessages.ListNull);
            //}

            var formDto = form.MapFrom();

            return formDto;
        }

        public async Task<FormDTO> UpdateFormAsync(Guid id, string newTitle, string newDescription)
        {
            var form = await this.dbcontext.Forms
                     .Where(f => f.Id == id)
                     .Include(f => f.TextQuestions)
                        .ThenInclude(f => f.Answers)
                     .FirstOrDefaultAsync()
                    ?? throw new Exception(ExceptionMessages.EntityNotFound);

            form.Title = newTitle;
            form.Description = newDescription;

            this.dbcontext.Update(form);
            form.LastModifiedOn = this.dateTimeProvider.GetDateTime();
            await this.dbcontext.SaveChangesAsync();

            var updatedForm = form.MapFrom();

            return updatedForm;
        }
    }
}