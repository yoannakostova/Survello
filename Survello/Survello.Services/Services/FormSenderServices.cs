using Survello.Services.ConstantMessages;
using Survello.Services.Services.Contracts;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Survello.Services.Services
{
    public class FormSenderServices : IFormSenderServices
    {
        public async Task<bool> ShareFormAsync(Guid formId, MailMessage mailMessage)
        {
            try
            {
                mailMessage.Subject = "You are wellcome to complete our form!";
                mailMessage.From = new MailAddress("survellosender@gmail.com");
                mailMessage.Body = "Please be aware that you are invited to fill the following form: " + "https://localhost:44339/Form/Answer/" + $"{formId}";
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials = new System.Net.NetworkCredential("survellosender@gmail.com", "#2Survello")
                };
                await smtp.SendMailAsync(mailMessage);

                return true;
            }
            catch (Exception)
            {
                throw new Exception(ExceptionMessages.MailSenderError);
            }
        }
    }
}


