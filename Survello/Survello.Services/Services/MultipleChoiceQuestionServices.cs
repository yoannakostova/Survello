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
    public class MultipleChoiceQuestionServices : IMultipleChoiceQuestionServices
    {
        private readonly SurvelloContext dbcontext;

        public MultipleChoiceQuestionServices(SurvelloContext dbcontext)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }
        public async Task<MultipleChoiceQuestionDTO> CreateMultipleQuestionAsync(MultipleChoiceQuestionDTO tempMultipleQuestion)
        {
            if (tempMultipleQuestion == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            //TODO: Should we need to check whether the form exist? 
            var form = await this.dbcontext.Forms
                        .FirstOrDefaultAsync(f => f.Id == tempMultipleQuestion.FormId)
                        ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var multipleQuestion = tempMultipleQuestion.MapFrom();

            await this.dbcontext.MultipleChoiceQuestions.AddAsync(multipleQuestion);
            await this.dbcontext.SaveChangesAsync();

            var multipleQuestionDto = multipleQuestion.MapFrom();

            return multipleQuestionDto;
        }

        public async Task<bool> DeleteMultipleChoiceQuestion(Guid id)
        {
            var multipleChoiceQuestion = await this.dbcontext.MultipleChoiceQuestions
                .FirstOrDefaultAsync(mq => mq.Id == id)
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            multipleChoiceQuestion.IsDeleted = true;
            this.dbcontext.Update(multipleChoiceQuestion); //TODO: Deletion of options and answers?
            await this.dbcontext.SaveChangesAsync();

                //foreach (var item in multipleChoiceQuestion.Options)
                //{
                //    item.IsDeleted = true;
                //    foreach (var it in item.MultipleChoiceAnswers)
                //    {
                //        it.IsDeleted = true;
                //    }
                //}

            return true;
        }

        //TODO: Do wee need this method?
        public async Task<MultipleChoiceQuestionDTO> GetMultipleQuestionAsync(Guid id)
        {
            var multipleChoiceQuestion = await this.dbcontext.MultipleChoiceQuestions
                .FirstOrDefaultAsync(mq => mq.Id == id)
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var multipleChoiceQuestionDto = multipleChoiceQuestion.MapFrom();

            return multipleChoiceQuestionDto;
        }

        public async Task<ICollection<MultipleChoiceQuestionDTO>> GetAllMultipleQuestionsInFormAsync(Guid id)
        {
            var multipleChoiceQuestion = await this.dbcontext.MultipleChoiceQuestions
                .Where(t => t.FormId == id)
                .ToListAsync()
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            var multipleChoiceQuestionDto = multipleChoiceQuestion.MapFrom();

            return multipleChoiceQuestionDto;
        }
    }
}
