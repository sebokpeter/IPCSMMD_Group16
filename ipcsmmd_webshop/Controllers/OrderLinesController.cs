//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ipcsmmd_webshop.Core.ApplicationService;
//using ipcsmmd_webshop.Core.Entity;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ipcsmmd_webshop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderLinesController : ControllerBase
//    {
//        private readonly IOrderLineService _service;

//        public OrderLinesController(IOrderLineService service)
//        {
//            _service = service;
//        }

//        // GET: api/OrderLines
//        [HttpGet]
//        public ActionResult<List<OrderLine>> Get()
//        {
//            try {
//                return Ok(_service.GetAllOrderLines());
//            }
//            catch (Exception ex) {
//                return BadRequest(ex.Message);
//            }
//        }

//        // POST: api/OrderLiness
//        [HttpPost]
//        public ActionResult<OrderLine> Post([FromBody] OrderLine ol)
//        {
//            try {
//                if (_service.AddOrderLine(ol) != null) {
//                    return Ok($"A new order has been added to order: {ol.OrderID}!");
//                }
//                return BadRequest("Could not add the new orderline!");
//            }
//            catch (Exception ex) {
//                return BadRequest(ex.Message);
//            }
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{orderID}&{beerID}")]
//        public ActionResult<OrderLine> Delete(int orderID, int beerID)
//        {
//            try {
//                if (orderID < 1 || beerID < 1) {
//                    return BadRequest("ID must be greater than 0!");
//                }

//                if (_service.RemoveOrderLine(orderID, beerID) != null) {
//                    return Ok($"OrderLines with the ID of {orderID} and {beerID} was deleted!");
//                }
//                else {
//                    return BadRequest($"OrderLine with the IDs of {orderID} and {beerID} could not be deleted!");
//                }
//            }
//            catch (Exception ex) {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}
