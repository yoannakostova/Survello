using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IFormServices
    {
        Task<FormDTO> CreateFormAsync(FormDTO tempForm);
        Task<bool> DeleteFormAsync(Guid id);
        Task<FormDTO> UpdateFormAsync(Guid id, string newTitle, string newDescription);
        Task<FormDTO> GetFormAsync(Guid id);
        Task<ICollection<FormDTO>> GetAllFormsAsync();
    }
}
