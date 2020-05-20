using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Survello.Services.Services
{
    public class FormSenderServices : IFormSenderServices
    {
        public bool SendEmail(string to, string subject)
        {
            //string absoluteUrl = HttpContext.Request.GetDisplayUrl();
            MailMessage mailMessage = new MailMessage();
            string[] Emails = to.Split(',');
            foreach (var email in Emails)
            {
                mailMessage.To.Add(email);
            }
            mailMessage.Subject = subject;
            mailMessage.From = new MailAddress("survellosender@gmail.com");
            //TODO: Form Id need to be added to url!
            mailMessage.Body = $"Please <a href=https://localhost:5001/Answers/Index/> Go To Form</a>";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential("survellosender@gmail.com", "#2Survello")
            };
            smtp.Send(mailMessage);

            return true;
        }
    }
}
