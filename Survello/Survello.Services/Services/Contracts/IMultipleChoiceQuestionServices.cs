using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IMultipleChoiceQuestionServices
    {
        Task<MultipleChoiceQuestionDTO> CreateMultipleQuestionAsync(MultipleChoiceQuestionDTO tempMultipleQuestion);
        Task<bool> DeleteMultipleChoiceQuestion(Guid id);
        //Task<MultipleChoiceQuestionDTO> UpdateMultipleQuestionAsync();
        Task<MultipleChoiceQuestionDTO> GetMultipleQuestionAsync(Guid id);
        Task<ICollection<MultipleChoiceQuestionDTO>> GetAllMultipleQuestionsInFormAsync(Guid id);
    }
}
