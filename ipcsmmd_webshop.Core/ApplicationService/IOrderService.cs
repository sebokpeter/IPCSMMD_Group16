using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;


namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface IOrderService
    {
        /// <summary>
        /// Fetch an unfiltered, unordered list of orders.
        /// </summary>
        /// <returns>A list of orders</returns>
        List<Order> GetOrders();

        /// <summary>
        /// Fetch an unfiltered, unordered list of orders.
        /// </summary>
        /// <returns>A list of orders</returns>
        IEnumerable<Order> ReadOrders();

        /// <summary>
        /// Save a new order.
        /// </summary>
        /// <param name="order">The order that will be saved.</param>
        /// <returns>The order that was saved.</returns>
        Order AddOrder(Order order);

        /// <summary>
        /// Remove an order based on ID.
        /// </summary>
        /// <param name="id">The Id of the order that will be removed.</param>
        /// <returns>The removed order.</returns>
        Order RemoveOrder(int id);

        /// <summary>
        /// Retrieve an ored based on ID.
        /// </summary>
        /// <param name="id">The ID of the order that will be retrieved.</param>
        /// <returns>The order with the specified ID, or null if not found.</returns>
        Order GetOrderByID(int id);

        /// <summary>
        /// Update an order.
        /// </summary>
        /// <param name="order">The order that will be updated.</param>
        /// <returns>The updated order.</returns>
        Order UpdateOrder(Order order);
    }
}
