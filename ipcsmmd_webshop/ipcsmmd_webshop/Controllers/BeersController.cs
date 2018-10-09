using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipcsmmd_webshop.Core.ApplicationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ipcsmmd_webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerService _service;

        public BeersController(IBeerService service)
        {
            _service = service;
        }

        // GET: api/Beers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Beers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Beers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Beers/5
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
