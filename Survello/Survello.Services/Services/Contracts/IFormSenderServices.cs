using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.Services.Contracts
{
    public interface IFormSenderServices
    {
        bool SendEmail(string to, string subject);
    }
}
