using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;


namespace ipcsmmd_webshop.Core.ApplicationService
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        IEnumerable<Order> ReadOrders();

        Order AddOrder(Order order);

        Order RemoveOrder(int id);

        Order GetOrderByID(int id);

        Order UpdateOrder(Order order);
    }
}
