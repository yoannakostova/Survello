using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IBlobServices
    {
        Task<string> Create(IEnumerable<IFormFile> files, Guid corelationToken, Guid questionId);
    }
}
