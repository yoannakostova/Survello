using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IFormSenderServices
    {
        Task<bool> ShareFormAsync(Guid formId, MailMessage mailMessage);
    }
}
