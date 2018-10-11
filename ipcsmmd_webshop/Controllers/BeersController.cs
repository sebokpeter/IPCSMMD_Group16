using System;
using System.Collections.Generic;
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
                if (filter.CurrentPage == 0 && filter.ItemsPerPage == 0 && filter.IsAscending == false && filter.SearchField == BeerFilter.Field.Id)
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
        public ActionResult<Beer> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("ID must be bigger than 0!");
                }

                Beer b = _service.GetBeerByID(id);
                if (b == null)
                {
                    return NotFound($"We didn't find the beer with the ID of {id}");
                }
                return Ok(b);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Beers
        [HttpPost]
        public ActionResult<Beer> Post([FromBody] Beer value)
        {
            try
            {
                Beer temp = _service.AddBeer(value);
                //value.ID = 0;
                if (String.IsNullOrEmpty(value.Name))
                {
                    return BadRequest("Cannot add a beer without name!");
                }
                if (String.IsNullOrEmpty(value.Brand))
                {
                    return BadRequest("Cannot add a beer without brand!");
                }

                if (temp != null)
                {
                    string s = String.Format($"Beer with the ID of {value.ID} has been added!");
                    //return StatusCode(StatusCodes.Status201Created, s);
                    return Ok(temp);
                }
                else
                {
                    return BadRequest("Could not add the beer!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Beers/5
        [HttpPut("{id}")]
        public ActionResult<Beer> Put(int id, [FromBody] Beer value)
        {
            try
            {
                Beer temp = _service.UpdateBeer(value);
                if (id < 1)
                {
                    return BadRequest("Cannot update non-existing beer!");
                }
                if (value.ID != id)
                {
                    return BadRequest("Parameter mismatch: supplied ID and beer ID are not equal!");
                }

                if (temp != null)
                {
                    //return Ok($"Beer with the ID of {id} has been updated!");
                    return Ok(temp);
                }
                else
                {
                    return BadRequest($"Could not update beer with the ID of {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Beer> Delete(int id)
        {
            try
            {
                Beer temp = _service.RemoveBeer(id);
                if (id < 1)
                {
                    return BadRequest("Cannot delete a non-existing beer!");
                }

                if (temp != null)
                {
                    //return Ok($"Beer with the ID of {id} has been deleted!");
                    return Ok(temp);
                }
                else
                {
                    return BadRequest($"Could not delete beer with the ID of {id}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}