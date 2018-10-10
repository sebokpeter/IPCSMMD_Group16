using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class OrderLineRepository : IOrderLineReporitory
    {
        private WebShopContext _ctx;

        public OrderLineRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public OrderLine Add(OrderLine ol)
        {
            _ctx.OrderLines.Add(ol);
            _ctx.SaveChanges();
            return ol;
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _ctx.OrderLines;
        }

        public OrderLine Remove(int orderID, int beerID)
        {
            OrderLine del = _ctx.OrderLines.FirstOrDefault(ol => ol.OrderID == orderID && ol.BeerID == beerID);
            _ctx.OrderLines.Remove(del);
            _ctx.SaveChanges();
            return del;
        }
    }
}
