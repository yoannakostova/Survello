using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Survello.Services.Services.Contracts;

namespace Survello.Web.Controllers
{
    [Authorize]
    public class FormSenderController : Controller
    {
        private readonly IToastNotification toastNotification;
        private readonly IFormSenderServices formSenderServices;
        private const string MatchEmailPattern =
           @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        public FormSenderController(IToastNotification toastNotification, IFormSenderServices formSenderServices)
        {
            this.toastNotification = toastNotification;
            this.formSenderServices = formSenderServices;
        }
        // GET: Emails
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(Guid id, string allRecipients)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            if (allRecipients == null)
            {
                this.toastNotification.AddAlertToastMessage("You didn`t add any emails. Please try again.");
                return View();
            }
            string[] Emails = allRecipients.Split(new char[] { ',', ' ' },
                                           StringSplitOptions.RemoveEmptyEntries);
            MailMessage mailMessage = new MailMessage();
            foreach (var email in Emails)
            {
                if (Regex.IsMatch(email, MatchEmailPattern))
                {
                    mailMessage.To.Add(email);
                }
                else
                {
                    this.toastNotification.AddAlertToastMessage("Wrong email format. Please try again.");
                    return View();
                }
            }
            try
            {
                var isEmailSent = await this.formSenderServices.ShareFormAsync(id, mailMessage);

                this.toastNotification.AddSuccessToastMessage("Email was sent successfully"!);
            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Something went wrong... Please try again!");
            }
            return View();
        }
    }
}