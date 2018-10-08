using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.DomainService
{
    public interface ICustomerRepository
    {
        //Returns all Customers
        IEnumerable<Customer> GetAll();
        //Returns a filtered list of Customers
        IEnumerable<Customer> GetFiltered(/*Filter filter*/);
        //Returns a Customer by ID
        IEnumerable<Customer> GetCustomerByID(int id);

        //Saves a new Customer to the database 
        Customer Save(Customer cust);

        //Updates an existing Customer
        Customer Update(int id, Customer cust);
        
        //Deletes a Customer by ID
        Customer Remove(int id);
    }
}
