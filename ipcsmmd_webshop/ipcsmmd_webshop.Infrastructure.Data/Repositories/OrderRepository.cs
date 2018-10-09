using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    class OrderRepository : IOrderRepository
    {
        private readonly WebShopContext _ctx;

        public OrderRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Order> GetAll()
        {
            return _ctx.Orders;
        }

        public Order Save(Order order)
        {
            _ctx.Attach(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _ctx.SaveChanges();
            return order;
        }

        public Order GetOrderByID(int id)
        {
            return _ctx.Orders.FirstOrDefault(x => x.ID == id);
        }
        
        public Order Update(Order order)
        {
            _ctx.Attach(order).State = EntityState.Modified;
            _ctx.Entry(order).Collection(o => o.OrderLines).IsModified = true;
            var orderlines = _ctx.OrderLines.Where(ol => ol.Order.ID == order.ID &&
                !order.OrderLines.Exists(o => o.BeerID == ol.BeerID && o.OrderID == ol.OrderID));

            foreach (var orderline in orderlines) {
                order.Customer = null;
                _ctx.Entry(orderline).Reference(ol => ol.Order).IsModified = true;
            }
            _ctx.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {
            Order orderRemoved = _ctx.Orders.Remove(new Order { ID = id }).Entity;
            _ctx.SaveChanges();
            return orderRemoved;
        }
    }
}
