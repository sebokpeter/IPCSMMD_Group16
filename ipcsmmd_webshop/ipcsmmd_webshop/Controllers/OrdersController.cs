using System;
using System.Collections.Generic;
using ipcsmmd_webshop.Core.ApplicationService;
using ipcsmmd_webshop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ipcsmmd_webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            try
            {
                return Ok(_service.GetOrders());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("ID must be greater than 1");
                }

                Order o = _service.GetOrderByID(id);

                if (o == null)
                {
                    return NotFound($"We didn't find the order with the ID of {id}!");
                }
                return Ok(o);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order value)
        {
            try
            {
                value.ID = 0;
                if (_service.AddOrder(value) != null)
                {
                    string s = String.Format($"A new order with the ID of {value.ID} has been added!");
                    return Ok(s);
                }
                return BadRequest("Could not add the new order!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order value)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Cannot update non-existing order!");
                }
                if (id != value.ID)
                {
                    return BadRequest("Parameter mismatch: supplied ID and Order ID are not equal!");
                }

                if (_service.UpdateOrder(value) != null)
                {
                    return Ok($"Order with the ID of {value.ID} was successfully updated!");
                }
                else
                {
                    return BadRequest($"Could not update order with the ID of {value.ID}!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("ID must be greater than 0!");
                }

                if (_service.RemoveOrder(id) != null)
                {
                    return Ok($"Order with the ID of {id} was deleted!");
                }
                else
                {
                    return BadRequest($"Order with the ID of {id} could not be deleted!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
