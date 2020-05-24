using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public FormController(IFormServices formServices, UserManager<User> userManager)
        {
            this.formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<IActionResult> ListForms()
        {
            //var userId = (await userManager.GetUserAsync(User)).Id;
            //var allForms = await this.formServices.GetUserFormsAsync(userId);
            var allForms = (await this.formServices.GetAllFormsAsync()).MapToListFormsViewModel();

            return View(allForms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task Create(CreateFormViewModel model)
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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = (await this.formServices.GetFormAsync(id)).MapFrom();

            foreach (var question in model.DocumentQuestions)
            {
                model.QuestionNumbers.Add(question.QuestionNumber, question);
            }

            foreach (var question in model.MultipleChoiceQuestions)
            {
                model.QuestionNumbers.Add(question.QuestionNumber, question);
            }

            foreach (var question in model.TextQuestions)
            {
                model.QuestionNumbers.Add(question.QuestionNumber, question);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }
    }
}