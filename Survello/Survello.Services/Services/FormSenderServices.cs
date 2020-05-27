using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services
{
    public class FormSenderServices : IFormSenderServices
    {
        public async Task<bool> ShareFormAsync(Guid formId, string to, string subject)
        {
            //string absoluteUrl = HttpContext.Request.GetDisplayUrl();
            MailMessage mailMessage = new MailMessage();

            string[] Emails = to.Trim().Split(',');
            foreach (var email in Emails)
            {
                mailMessage.To.Add(email);
            }
            mailMessage.Subject = subject;
            mailMessage.From = new MailAddress("survellosender@gmail.com");
            mailMessage.Body = "On the following path you can fill this form: " + "https://localhost:5001/AnswerForm/CreateAnswer/" + $"{formId}";
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
    }
}

