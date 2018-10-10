using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ipcsmmd_webshop.Core.ApplicationService.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public Order AddOrder(Order order)
        {
            if (order == null)
            {
                throw new InvalidDataException("Input is null!");
            }
            if (order.ID > 0)
            {
                throw new InvalidDataException("Cannot save an order with an already existing ID!");
            }
            if (order.DeliveryDate == DateTime.MinValue)
            {
                throw new InvalidDataException("Cannot save an order without delivery date!");
            }
            if (order.OrderDate == DateTime.MinValue)
            {
                throw new InvalidDataException("Cannot save an order without order date!");
            }
            if (order.Customer == null)
            {
                throw new InvalidDataException("Cannot save an order without a customer!");
            }

            return _repo.Save(order);
        }

        public List<Order> GetOrders()
        {
            return _repo.GetAll().ToList();
        }

        public Order GetOrderByID(int id)
        {
            if (id < 1)
            {
                throw new InvalidDataException("ID must be greater than 0!");
            }

            return _repo.GetOrderByID(id);
        }

        public IEnumerable<Order> ReadOrders()
        {
            return _repo.GetAll();
        }

        public Order RemoveOrder(int id)
        {
            if (id == 0)
                throw new ArgumentException("Missing order ID!");
            return _repo.Delete(id);
        }

        public Order UpdateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentException("Missing update data!");
            else if (order.ID == 0)
                throw new ArgumentException("Missing order ID!");
            return _repo.Update(order);
        }
    }
}
