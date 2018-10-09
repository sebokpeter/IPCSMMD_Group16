using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;


namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface ICustomerService
    {
        /// <summary>
        /// Returns an unfiltered, unordered list of customers.
        /// </summary>
        /// <returns>A list of customers</returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Gets a customer based on ID.
        /// </summary>
        /// <param name="id">The ID of the customer to be found.</param>
        /// <returns>The customer with the specified ID, or null if not found.</returns>
        Customer GetCustomerByID(int id);

        /// <summary>
        /// Saves a new customer.
        /// </summary>
        /// <param name="customer">The customer that will be saved</param>
        /// <returns>The saved customer</returns>
        Customer AddCustomer(Customer customer);

        /// <summary>
        /// Updates the existing customer with the provided ID.
        /// </summary>
        /// <param name="customer">Update data</param>
        /// <returns></returns>
        Customer UpdateCustomer(Customer customer);

        /// <summary>
        /// Removes customer with the provided ID.
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns></returns>
        Customer RemoveCustomer(int id);
    }
}
