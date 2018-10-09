using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;


namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface ICustomerService
    {
        //Returns a list of Customers from the Infrastructure
        IEnumerable<Customer> ReadCustomers();

        //Returns a Customer by the provided ID from the Infrastructure
        Customer GetCustomerByID(int id);

        //Attempts to save a new Customer
        Customer AddCustomer(Customer customer);

        //Attempts to update an existing Customer
        Customer UpdateCustomer(Customer customer);
    }
}
