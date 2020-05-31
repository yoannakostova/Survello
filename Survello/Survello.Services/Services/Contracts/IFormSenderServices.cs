using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services.Contracts
{
    public interface IFormSenderServices
    {
        Task<bool> ShareFormAsync(Guid formId, MailMessage mailMessage);
    }
}
