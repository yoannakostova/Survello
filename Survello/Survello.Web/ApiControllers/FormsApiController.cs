using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survello.Services.Services.Contracts;

namespace Survello.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsApiController : ControllerBase
    {
        private readonly IFormServices formServices;

        public FormsApiController(IFormServices formServices)
        {
            this.formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
        }

        // GET: api/FormsApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FormsApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FormsApi
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/FormsApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
