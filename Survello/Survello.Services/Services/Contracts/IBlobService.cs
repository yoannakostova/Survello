using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IBlobServices
    {
        Task<string> UploadAsync(IFormFile files, Guid corelationToken, Guid questionId);
    }
}
