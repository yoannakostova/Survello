using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Survello.Models.Entites;
using Survello.Services.Services.Contracts;
using Survello.Web.Common;
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
            this.formServices = formServices;
            this.userManager = userManager;
            this.toastNotification = toastNotification;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListForms(string sortOrder)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["CreatedOnSortParm"] = sortOrder == "CreatedOn" ? "createdon_desc" : "CreatedOn";
            ViewData["NumberOfFilledFormsSortParm"] = sortOrder == "NumberOfFilledForms" ? "numberoffilledforms_desc" : "NumberOfFilledForms";
            var userId = (await userManager.GetUserAsync(User)).Id;

            var allForms = this.formServices.Sort(sortOrder, userId).Select(f => f.MapToListFormsViewModel()).ToList();

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

                var createOptionsForMultipleChoiceQuestion = new Parser();

                if (createOptionsForMultipleChoiceQuestion.MapMultipleQuestionsWithOptions(model))
                {
                    var formDto = model.MapFrom();
                    var newForm = await this.formServices.CreateFormAsync(formDto);

                    newForm.MapFrom();

                    RedirectToAction("Index", "Home");
                }
                else
                {
                    this.toastNotification.AddErrorToastMessage("Something went wrong... Please try again!");
                }
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
        public async Task<IActionResult> Edit(FormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                model.UserId = (await userManager.GetUserAsync(User)).Id;

                foreach (var question in model.MultipleChoiceQuestions)
                {
                    foreach (var desc in question.OptionsDescriptions)
                    {
                        var optionModel = new MultipleChoiceOptionViewModel();
                        optionModel.OptionDescription = desc;
                        question.Options.Add(optionModel);
                    }
                }

                this.toastNotification.AddSuccessToastMessage("Form was successfully created");
                await this.formServices.CreateFormAsync(model.MapFrom());
            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Something went wrong... Please try again!");
            }

            return RedirectToAction("ListForms");
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
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Answer(FormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                var validator = new DataValidator();
                var formIsValid = validator.ValidateAnswer(form);

                if (formIsValid)
                {
                    this.toastNotification.AddSuccessToastMessage("Form was successfully answered");
                    var isAnswerSaved = await this.formServices.CreateAnswer(form.MapFrom());
                }
                else
                {
                    this.toastNotification.AddErrorToastMessage("You missed answering some required questions. Please review your answers again.");
                    return RedirectToAction("Answer", "Form", new { id = form.Id });
                }
            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Something went wrong... Please try again!");
                return RedirectToAction("Answer", "Form", new { id = form.Id });
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            try
            {
                this.toastNotification.AddInfoToastMessage("Form was succesfully deleted!");
                await this.formServices.DeleteFormAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(ListForms));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var form = (await this.formServices.GetFormWithAllAnswers(Id)).MapFrom();

            return View(form);
        }

        public async Task<IActionResult> AnsweredForm(Dictionary<string, string> paramss)
        {
            var form = (await this.formServices.GetFilledForm(paramss)).MapFrom();

            return View(form);
        }
    }
}
