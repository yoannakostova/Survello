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

        public async Task<ICollection<CreateMultipleChoiceQuestionDTO>> GetAllMultipleQuestionsInFormAsync(Guid id)
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
