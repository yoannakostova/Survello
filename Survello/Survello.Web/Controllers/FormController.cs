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
        public async Task<IActionResult> ListForms(string sortOrder)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["LastModifiedOnSortParm"] = sortOrder == "LastModifiedOn" ? "lastmodifiedon_desc" : "LastModifiedOn";
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
        public async Task<IActionResult> Edit(FormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                await this.formServices.CreateFormAsync(model.MapFrom());
                this.toastNotification.AddSuccessToastMessage("Form was successfully created");
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
                foreach (var tq in form.TextQuestions)
                {
                    if (tq.IsRequired == true && tq.Description == string.Empty)
                    {
                        this.toastNotification.AddErrorToastMessage($"You missed to answer some required questions.");
                        return RedirectToAction("Answer", "Form", new { id = form.Id });
                    }
                }

                //TODO: Validation for multiple question
                foreach (var dq in form.DocumentQuestions)
                {
                    if (dq.IsRequired == true)
                    {
                        if (dq.Files.Count == 0)
                        {
                            this.toastNotification.AddErrorToastMessage($"You missed to answer some required questions.");
                            return RedirectToAction("Answer", "Form", new { id = form.Id });
                        }
                    }

                    if (dq.Files == null && dq.IsRequired == false)
                    {
                        continue;
                    }


                    var fileSize = long.Parse(dq.FileSize) * 1024 * 1024;

                    foreach (var file in dq.Files)
                    {
                        if (file != null)
                        {
                            if (fileSize < file.Length)
                            {
                                this.toastNotification.AddErrorToastMessage("You uploaded bigger files than allowed. Please review the limitations again.");
                                return RedirectToAction("Answer", "Form", new { id = form.Id });
                            }
                            if (dq.FileNumberLimit < dq.Files.Count)
                            {
                                this.toastNotification.AddErrorToastMessage("You uploaded more files than allowed. Please review the limitations again.");
                                return RedirectToAction("Answer", "Form", new { id = form.Id });
                            }
                        }
                        else
                        {
                            this.toastNotification.AddErrorToastMessage("You missed uploading some files. You will be returned back to the form");
                            return RedirectToAction("Answer", "Form", new { id = form.Id });
                        }
                    }
                }

                var isAnswerSaved = await this.formServices.CreateAnswer(form.MapFrom());

                this.toastNotification.AddSuccessToastMessage("Form was successfully answered");
            }
            catch (Exception)
            {
                this.toastNotification.AddErrorToastMessage("Something went wrong... Please try again!");
                return RedirectToAction("Answer", "Form", new { id = form.Id });
            }
            return RedirectToAction("ListForms"); //TODO: Submitted form page
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
                await this.formServices.DeleteFormAsync(id);
                this.toastNotification.AddInfoToastMessage("Form was succesfully deleted!");
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
