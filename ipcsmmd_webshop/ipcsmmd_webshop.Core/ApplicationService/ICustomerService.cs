using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;


namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface ICustomerService
    {
        /// <summary>
        /// Fetch an unfiltered, unordered list of customers.
        /// </summary>
        /// <returns>A list of customers</returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Fetch an unfiltered, unordered list of customers.
        /// </summary>
        /// <returns>A list of customers</returns>
        IEnumerable<Customer> ReadCustomers();

        /// <summary>
        /// Get a customer based on ID.
        /// </summary>
        /// <param name="id">The ID of the customer to be found.</param>
        /// <returns>The customer with the specified ID, or null if not found.</returns>
        Customer GetCustomerByID(int id);

        /// <summary>
        /// Save a new customer.
        /// </summary>
        /// <param name="customer">The customer that will be saved</param>
        /// <returns>The saved customer</returns>
        Customer AddCustomer(Customer customer);

        /// <summary>
        /// Update an already existing customer.
        /// </summary>
        /// <param name="customer">The customer that will be updated.</param>
        /// <returns>The updated customer.</returns>
        Customer UpdateCustomer(Customer customer);

        /// <summary>
        /// Remove a customer based on ID.
        /// </summary>
        /// <param name="id">The id of the customer that will be removed.</param>
        /// <returns>The removed customer.</returns>
        Customer RemoveCustomer(int id);
    }
}
