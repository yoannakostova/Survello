using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IMultipleChoiceQuestionServices
    {
        Task<ICollection<CreateMultipleChoiceQuestionDTO>> GetAllMultipleQuestionsInFormAsync(Guid id);
    }
}
