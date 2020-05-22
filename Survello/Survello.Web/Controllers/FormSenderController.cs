using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Survello.Services.Services.Contracts;
using Survello.Web.Models;

namespace Survello.Web.Controllers
{
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // GET: Emails/Details/5
        public IActionResult Index(FormSenderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO: Middleware to be added and may be some toast notification.
                return NotFound();
            }
            try
            {
                string to = model.To;
                string subject = model.Subject;
                var isEmailSend = this.formSenderServices.SendEmail(to, subject);

                this.toastNotification.AddSuccessToastMessage("Email was sent successfully"!);
            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Something went wrong... Please try again!");
            }
            return RedirectToAction("ListForms", "FormsView");
        }
    }
}