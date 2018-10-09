using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipcsmmd_webshop.Core.ApplicationService;
using ipcsmmd_webshop.Core.Entity;
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
        public ActionResult<List<Beer>> Get([FromQuery] BeerFilter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.ItemsPerPage == 0 && filter.IsAscending == false && filter.SearchField == BeerFilter.Field.Brand)
                {
                    return Ok(_service.GetBeers());
                }

                return Ok(_service.GetFilteredBeers(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Beers/5
        [HttpGet("{id}")]
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
