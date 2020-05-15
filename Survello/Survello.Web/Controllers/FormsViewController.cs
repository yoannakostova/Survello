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
    public class FormsViewController : Controller
    {
        private readonly IFormServices formServices;

        public FormsViewController(IFormServices formServices)
        {
            this.formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
        }
        public async Task<IActionResult> ListForms()
        {
            var allForms = await this.formServices.GetAllFormsAsync();

            return View(allForms.MapFrom());
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var form = await this.formServices.GetFormAsync(id);
            return View("Details", form.MapFrom());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                var formDto = model.MapFrom();
                var newForm = await this.formServices.CreateFormAsync(formDto);

                newForm.MapFrom();

                return RedirectToAction("ListForms", "FormsView");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}