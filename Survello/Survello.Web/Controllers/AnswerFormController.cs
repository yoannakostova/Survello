using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survello.Services.Services.Contracts;
using Survello.Web.Mappers;
using Survello.Web.Models;

namespace Survello.Web.Controllers
{
    public class AnswerFormController : Controller
    {
        private readonly IFormServices formServices;

        public AnswerFormController(IFormServices formServices)
        {
            this.formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
        }
        [HttpGet]
        public async Task<IActionResult> CreateAnswer(Guid id)
        {
            var form = (await this.formServices.GetFormAsync(id)).MapToAnswerFormViewModel();

            return View(form);
        }

        [HttpPost]
        public IActionResult CreateAnswer(AnswerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
               return NotFound();
            }
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}