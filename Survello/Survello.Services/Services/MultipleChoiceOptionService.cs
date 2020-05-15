using Microsoft.EntityFrameworkCore;
using Survello.Database;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Services.DTOMappers;
using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services
{
    public class MultipleChoiceOptionService : IMultipleChoiceOptionServices
    {
        private readonly SurvelloContext dbcontext;

        public MultipleChoiceOptionService(SurvelloContext dbcontext)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }
        public async Task<MultipleChoiceOptionDTO> CreateMultipleChoiceOptionAsync(MultipleChoiceOptionDTO tempOption)
        {
            if (tempOption == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            //TODO: Should we need this check here? 
            var optionQuestion = await this.dbcontext.MultipleChoiceQuestions
                .FirstOrDefaultAsync(op => op.Id == tempOption.MultipleChouceQuestionId)
                ?? throw new Exception(ExceptionMessages.EntityNotFound);
            
            var newOption = tempOption.MapFrom();

            await this.dbcontext.MultipleChoiceOptions.AddAsync(newOption);
            await this.dbcontext.SaveChangesAsync();

            var optionDto = newOption.MapFrom();

            return optionDto;
        }

        public async Task<bool> DeleteMultipleChoiceOption(Guid id)
        {
            var option = await this.dbcontext.MultipleChoiceOptions
                .FirstOrDefaultAsync(op => op.Id == id)
                ?? throw new Exception(ExceptionMessages.EntityNotFound);

            option.IsDeleted = true;
            //TODO: Should we delete answer
            await this.dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
