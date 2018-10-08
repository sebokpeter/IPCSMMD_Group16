using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomerByID(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Save(Customer cust)
        {
            throw new NotImplementedException();
        }

        public Customer Update(int id, Customer cust)
        {
            throw new NotImplementedException();
        }

        public Customer Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
