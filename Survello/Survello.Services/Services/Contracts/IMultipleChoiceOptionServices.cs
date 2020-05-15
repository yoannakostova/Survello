using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IMultipleChoiceOptionServices
    {
        Task<MultipleChoiceOptionDTO> CreateMultipleChoiceOptionAsync(MultipleChoiceOptionDTO tempMultipleQuestionOption);
        Task<bool> DeleteMultipleChoiceOption(Guid id);
    }
}
