using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
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
            throw new NotImplementedException();
        }

        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
