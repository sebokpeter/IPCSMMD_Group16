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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            try {
                return Ok(_customerService.GetAllCustomers());
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            try {
                return Ok(_customerService.GetCustomerByID(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            try {
                return Ok(_customerService.AddCustomer(customer));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            if (id == customer.ID) {
                try {
                    return _customerService.UpdateCustomer(customer);
                }
                catch (Exception e) {
                    return BadRequest(e.Message);
                }
            }
            else {
                return BadRequest("ID mismatch");
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            try {
                return Ok(_customerService.RemoveCustomer(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}