using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IFormServices
    {
        Task<FormDTO> CreateFormAsync(FormDTO formDto);
        Task DeleteFormQuestion(Guid id);
        Task<FormDTO> UpdateFormAsync(FormDTO formDto);
        Task<FormDTO> GetFormAsync(Guid id);
        Task<ICollection<FormDTO>> GetAllFormsAsync();
    }
}
