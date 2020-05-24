using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IFormServices
    {
        Task<CreateFormDTO> CreateFormAsync(CreateFormDTO tempForm);
        Task<bool> DeleteFormAsync(Guid id);
        Task<CreateFormDTO> GetFormAsync(Guid id);
        Task<ICollection<ListFormsDTO>> GetAllFormsAsync();
        Task<ICollection<CreateFormDTO>> GetUserFormsAsync(Guid userId);


    }
}
