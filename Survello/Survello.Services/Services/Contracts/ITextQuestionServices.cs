using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface ITextQuestionServices
    {
        Task<ICollection<TextQuestionDTO>> GetAllTextQuestionInForm(Guid id);
    }
}
