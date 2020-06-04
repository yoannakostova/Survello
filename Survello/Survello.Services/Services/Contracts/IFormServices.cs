using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IFormServices
    {
        Task<FormDTO> CreateFormAsync(FormDTO tempForm);
        Task<bool> DeleteFormAsync(Guid id);
        Task<FormDTO> GetFormAsync(Guid id);
        Task<ICollection<FormDTO>> GetUserFormsAsync(Guid userId);
        Task<FormDTO> GetFormWithAllAnswers(Guid id);
        Task<bool> CreateAnswer(FormDTO form);
        IQueryable<ListFormsDTO> Sort(string sortOrder, Guid userId);
        Task<FormDTO> GetFilledForm(Dictionary<string, string> paramss);



    }
}
