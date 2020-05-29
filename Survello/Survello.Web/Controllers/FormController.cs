using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using Survello.Models.Entites;
using Survello.Services.Services.Contracts;
using Survello.Web.Mappers;
using Survello.Web.Models;

namespace Survello.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormServices formServices;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastNotification;

        public FormController(IFormServices formServices, UserManager<User> userManager, IToastNotification toastNotification)
        {
            this.formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.toastNotification = toastNotification ?? throw new ArgumentNullException(nameof(toastNotification));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListForms()
        {
            //var userId = (await userManager.GetUserAsync(User)).Id;
            //var allForms = await this.formServices.GetUserFormsAsync(userId);
            var allForms = (await this.formServices.GetAllFormsAsync()).MapToListFormsViewModel();

            return View(allForms);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task Create(FormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotFound();
            }
            try
            {
                model.UserId = (await userManager.GetUserAsync(User)).Id;

                foreach (var question in model.MultipleChoiceQuestions)
                {
                    foreach (var desc in question.OptionsDescriptions)
                    {
                        var optionModel = new MultipleChoiceOptionViewModel();
                        optionModel.Option = desc;
                        question.Options.Add(optionModel);
                    }
                }

                var formDto = model.MapFrom();
                var newForm = await this.formServices.CreateFormAsync(formDto);

                newForm.MapFrom();

                RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                NotFound();
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = (await this.formServices.GetFormAsync(id)).MapFrom();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Answer(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            try
            {
                var form = (await this.formServices.GetFormAsync(id)).MapFrom();

                return View(form);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //TODO: HiddenFor leaves IDs visible in the browser! 
        [HttpPost]
        public async Task<IActionResult> Answer(FormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                var isAnswerSaved = await this.formServices.SaveAnswerForm(form.MapFrom());

                this.toastNotification.AddSuccessToastMessage("Form was successfully answered");

                return RedirectToAction("ListForms"); 
            }
            catch (Exception e)
            {
                throw;  
            }

        }
    }
}
