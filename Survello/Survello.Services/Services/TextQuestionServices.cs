using Microsoft.EntityFrameworkCore;
using Survello.Database;
using Survello.Models.Entites;
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
    public class TextQuestionServices : ITextQuestionServices
    {
        private readonly SurvelloContext dbcontext;

        public TextQuestionServices(SurvelloContext dbcontext)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO textQuestion)
        {
            if (textQuestion == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            var tq = textQuestion.MapFrom();

            await this.dbcontext.TextQuestions.AddAsync(tq);
            await this.dbcontext.SaveChangesAsync();

            var formDto = tq.MapFrom();

            return formDto;
        }

        public async Task<bool> DeleteTextQuestion(Guid id)
        {

            var textQuestion = await this.dbcontext.TextQuestions
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (textQuestion == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            textQuestion.IsDeleted = true;
            await this.dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<TextQuestionDTO> UpdateTextQuestionAsync(TextQuestionDTO textQuestion)
        {
            var entity = new TextQuestion
            {
                Id = textQuestion.Id,
                Answers = textQuestion.Answers.MapFrom(),
                Description = textQuestion.Description,
                FormId = textQuestion.FormId,
                IsLongAnswer = textQuestion.IsLongAnswer,
                IsRequired = textQuestion.IsRequired
            };

            this.dbcontext.TextQuestions.Update(entity);
            await this.dbcontext.SaveChangesAsync();

            return entity.MapFrom();
        }

        public async Task<TextQuestionDTO> GetTextQuestion(Guid id)
        {
            var textQuestion = await this.dbcontext.TextQuestions
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (textQuestion == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return textQuestion.MapFrom();
        }

        public async Task<ICollection<TextQuestionDTO>> GetAllTextQuestionInForm(Guid id)
        {
            var textQuestions = await this.dbcontext.TextQuestions
                .Where(t => t.FormId == id)
                .ToListAsync();

            if (textQuestions == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return textQuestions.MapFrom();
        }
    }
}
