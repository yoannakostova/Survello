using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Survello.Web.Controllers
{
    [Authorize]
    public class BlobController : Controller
    {
        private readonly IConfiguration configuration;
        public IActionResult Index()
        {
            return View();
        }
        public BlobController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}