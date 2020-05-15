using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survello.Web.Mappers;
using Survello.Services.Services.Contracts;
using Survello.Web.Models;

namespace Survello.Web.Controllers
{
    public class TextQuestionsViewController : Controller
    {
        private readonly ITextQuestionServices textQuestionServices;

        public TextQuestionsViewController(ITextQuestionServices textQuestionServices)
        {
            this.textQuestionServices = textQuestionServices ?? throw new ArgumentNullException(nameof(textQuestionServices));
        }

        public async Task<IActionResult> GetAllQuestionsInForm(Guid id)
        {
            var allQuestions = await this.textQuestionServices.GetAllTextQuestionInForm(id);

            return View(allQuestions.MapFrom());
        }

        [HttpGet]

        public async Task<IActionResult> GetTextQuestion(Guid id)
        {
            var textQuestion = await this.textQuestionServices.GetTextQuestionAsync(id);

            return PartialView(textQuestion);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TextQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                var textQuestionDto = model.MapFrom();
                var newQuestion = await this.textQuestionServices.CreateTextQuestionAsync(textQuestionDto);

                newQuestion.MapFrom();

                return RedirectToAction("Details", "FormsView");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTextQuestion(Guid id)
        {
            bool result = await this.textQuestionServices.DeleteTextQuestionAsync(id);

            if (result)
            {
                return View("Details", "FormView");
            }

            return BadRequest();
        }
    }
}