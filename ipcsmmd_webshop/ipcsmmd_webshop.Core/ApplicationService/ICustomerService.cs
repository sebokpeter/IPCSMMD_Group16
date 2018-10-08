using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;


namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        IEnumerable<Customer> ReadCustomers();

        Customer GetCustomerByID(int id);

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

    }
}
