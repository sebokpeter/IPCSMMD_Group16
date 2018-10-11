//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using ipcsmmd_webshop.Core.DomainService;
//using ipcsmmd_webshop.Core.Entity;

//namespace ipcsmmd_webshop.Core.ApplicationService.Impl
//{
//    public class OrderLineService : IOrderLineService
//    {
//        private IOrderLineReporitory _olrepo;

//        public OrderLineService(IOrderLineReporitory repository)
//        {
//            _olrepo = repository;
//        }

//        public OrderLine AddOrderLine(OrderLine ol)
//        {
//            if (ol == null) {
//                throw new ArgumentException("Missing orderline");
//            }
//            return _olrepo.Add(ol);
//        }

//        public List<OrderLine> GetAllOrderLines()
//        {
//            return _olrepo.GetAll().ToList();
//        }

//        public OrderLine RemoveOrderLine(int orderID, int beerID)
//        {
//            if (orderID == 0) {
//                throw new ArgumentException("Missing orderID!");
//            }
//            if (beerID == 0) {
//                throw new ArgumentException("Missing beerID");
//            }
//            return _olrepo.Remove(orderID, beerID);
//        }
//    }
//}
