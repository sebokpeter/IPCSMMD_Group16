using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private WebShopContext _ctx;
        
        public CustomerRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }
        
        public IEnumerable<Customer> GetAll()
        {
            return _ctx.Customers;
        }

        public Customer GetCustomerByID(int id)
        {
            return _ctx.Customers
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.ID == id);
        }

        public Customer Save(Customer cust)
        {
            Customer customer = _ctx.Customers.Add(cust).Entity;
            _ctx.SaveChanges();
            return customer;
        }

        public Customer Update(Customer cust)
        {
            _ctx.Attach(cust).State = EntityState.Modified;
            _ctx.Entry(cust).Collection(c => c.Orders).IsModified = true;
            var orders = _ctx.Orders.Where(o => o.Customer.ID == cust.ID && !cust.Orders.Exists(co => co.ID == o.ID));
            foreach (var order in orders)
            {
                order.Customer = null;
                _ctx.Entry(order).Reference(o => o.Customer).IsModified = true;
            }
            
            _ctx.SaveChanges();
            return cust;
        }

        public Customer Remove(int id)
        {
            Customer custRemoved = _ctx.Customers.Remove(new Customer { ID = id }).Entity;
            IEnumerable<Order> ordersToRemove = _ctx.Orders.Where(o => o.Customer == custRemoved);
            _ctx.RemoveRange(ordersToRemove);
            _ctx.SaveChanges();
            return custRemoved;
        }
    }
}
