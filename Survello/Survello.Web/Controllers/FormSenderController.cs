using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Survello.Services.Services.Contracts;
using Survello.Web.Models;

namespace Survello.Web.Controllers
{
    [Authorize]
    public class FormSenderController : Controller
    {
        private readonly IToastNotification toastNotification;
        private readonly IFormSenderServices formSenderServices;

        public FormSenderController(IToastNotification toastNotification, IFormSenderServices formSenderServices)
        {
            this.toastNotification = toastNotification ?? throw new ArgumentNullException(nameof(toastNotification));
            this.formSenderServices = formSenderServices ?? throw new ArgumentNullException(nameof(formSenderServices));
        }
        // GET: Emails
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(Guid id, string allRecipients, string subj)
        {
            if (id == Guid.Empty)
            {
                //TODO: Middleware to be added and may be some toast notification.
                return NotFound();
            }
            try
            { 
                var isEmailSent = await this.formSenderServices.ShareFormAsync(id, allRecipients, subj);

                this.toastNotification.AddSuccessToastMessage("Email was sent successfully"!);
            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Something went wrong... Please try again!");
            }
            return RedirectToAction("ListForms", "Form");
        }
    }
}