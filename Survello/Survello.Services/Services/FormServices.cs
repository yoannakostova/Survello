using Microsoft.EntityFrameworkCore;
using Survello.Database;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Services.DTOMappers;
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

        public FormServices(SurvelloContext dbcontext)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
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

        public Task DeleteFormQuestion(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<FormDTO> GetFormAsync(Guid id)
        {
            var form = await this.dbcontext.Forms
                .Where(f => f.Id == id && f.IsDeleted == false)
                .Include(f => f.TextQuestions) //TODO: Other type of questions to be included!
                .FirstOrDefaultAsync()
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var formDto = form.MapFrom();

            return formDto;
        }
        public async Task<ICollection<FormDTO>> GetAllFormsAsync()
        {
            var form = await this.dbcontext.Forms
                .Where(f=>f.IsDeleted == false)
                .Include(f => f.TextQuestions)
                .ToListAsync();

            //if (form.Count == 0)
            //{
            //    throw new Exception(ExceptionMessages.ListNull);
            //}

            var formDto = form.MapFrom();

            return formDto;
        }

        public Task<FormDTO> UpdateFormAsync(FormDTO textQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
