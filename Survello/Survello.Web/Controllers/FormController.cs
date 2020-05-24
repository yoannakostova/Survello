﻿using System;
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
                    //model.QuestionNumbers.Add(question.QuestionNumber, question);

                    foreach (var desc in question.OptionsDescriptions)
                    {
                        var optionModel = new MultipleChoiceOptionViewModel();
                        optionModel.Option = desc;
                        question.Options.Add(optionModel);
                    }
                }

                //foreach (var item in model.DocumentQuestions)
                //{
                //    model.QuestionNumbers.Add(item.QuestionNumber, item);
                //}

                //foreach (var item in model.TextQuestions)
                //{
                //    model.QuestionNumbers.Add(item.QuestionNumber, item);
                //}


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
        public IActionResult Edit(CreateFormViewModel model = null)
        {
            var newModel = model;

            return View(newModel);
        }

    }
}