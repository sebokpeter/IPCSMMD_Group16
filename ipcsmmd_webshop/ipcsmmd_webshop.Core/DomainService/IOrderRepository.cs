using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Core.DomainService
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Fetch an unordered list of Order objects.
        /// </summary>
        /// <returns>An unordered list of Order objects.</returns>
        IEnumerable<Order> GetAll();

        /// <summary>
        /// Fetch an Order object based on ID.
        /// </summary>
        /// <param name="id">The ID of the Order object that will be returned.</param>
        /// <returns>The Order object with the corresponding ID, or null if not found.</returns>
        Order GetOrderByID(int id);

        /// <summary>
        /// Save an Order object to the database.
        /// </summary>
        /// <param name="order">The Order object that will be saved.</param>
        /// <returns>The saved Order object.</returns>
        Order Save(Order order);

        /// <summary>
        /// Update an already existing Order object inside the database.
        /// </summary>
        /// <param name="order">The order that will be updated.</param>
        /// <returns>The updated Order object.</returns>
        Order Update(Order order);

        /// <summary>
        /// Delete an Order object fro the databese based on ID.
        /// </summary>
        /// <param name="id">The ID of the Order object that will be deleted.</param>
        /// <returns>The deleted Order object, or null if it was not found.</returns>
        Order Delete(int id);
    }
}
