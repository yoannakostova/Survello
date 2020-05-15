using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface ITextQuestionServices
    {
        Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO textQuestion);
        Task<bool> DeleteTextQuestionAsync(Guid id);
        Task<TextQuestionDTO> UpdateTextQuestionAsync(TextQuestionDTO textQuestion);
        Task<TextQuestionDTO> GetTextQuestionAsync(Guid id);
        Task<ICollection<TextQuestionDTO>> GetAllTextQuestionInForm(Guid id);
    }
}
