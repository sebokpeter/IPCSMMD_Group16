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
            return _ctx.Customers.FirstOrDefault(c => c.ID == id);
        }

        public Customer Save(Customer cust)
        {
            Customer customer = _ctx.Customers.Add(cust).Entity;
            _ctx.SaveChanges();
            return customer;
        }

        public Customer Update(int id, Customer cust)
        {
            _ctx.Attach(cust).State = EntityState.Modified;
            _ctx.Entry(cust).Reference(p => p.Orders).IsModified = true;
            _ctx.SaveChanges();
            return cust;
        }

        public Customer Remove(int id)
        {
            Customer custRemoved = _ctx.Remove(new Customer { ID = id }).Entity;
            _ctx.SaveChanges();
            return custRemoved;
        }
    }
}
