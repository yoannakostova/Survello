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
                mailMessage.Subject = "Survello - Invitation to fill a form";
                mailMessage.From = new MailAddress("survellosender@gmail.com");
                mailMessage.Body = "You have been invited to fill in a form. Follow the link to see more info: " + "https://localhost:44339/Form/Answer/" + $"{formId}";
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


