using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using ipcsmmd_webshop.Core.ApplicationService;
using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.ApplicationService.Impl;
using System.IO;
using ipcsmmd_webshop.Core.Entity;

namespace TestCore.ApplicationService.Impl
{
    public class OrderServiceTest
    {
        /******************************************************************************/
                                    //Create tests//
        [Fact]
        public void AddingNullOrderThrowsException()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.AddOrder(null));
            Assert.Equal("Input is null!", ex.Message);
        }

        [Fact]
        public void SavingOrderWithIDThrowsException()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Order order = new Order()
            {
                ID = 1,
                Customer = new Customer()
                {
                    ID = 1,
                    FirstName = "Test",
                    LastName = "LastTest",
                    Email = "test@testmail.dk",
                    Address = "Address",
                    PhoneNumber = "+52519631",
                    Orders = null
                },
                DeliveryDate = DateTime.Now.AddDays(5),
                OrderDate = DateTime.Now,
                OrderLines = null
            };
            
            Exception ex = Assert.Throws<InvalidDataException>(() => service.AddOrder(order));
            Assert.Equal("Cannot save an order with an already existing ID!", ex.Message);
        }

        [Fact]
        public void SavingOrderWithoutDeliveryDateThrowsException()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Order order = new Order()
            {
                Customer = new Customer()
                {
                    ID = 1,
                    FirstName = "Test",
                    LastName = "LastTest",
                    Email = "test@testmail.dk",
                    Address = "Address",
                    PhoneNumber = "+52519631",
                    Orders = null
                },
                OrderDate = DateTime.Now,
                OrderLines = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.AddOrder(order));
            Assert.Equal("Cannot save an order without delivery date!", ex.Message);
        }

        [Fact]
        public void SavingOrderWithoutOrderDateThrowsException()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Order order = new Order()
            {
                Customer = new Customer()
                {
                    ID = 1,
                    FirstName = "Test",
                    LastName = "LastTest",
                    Email = "test@testmail.dk",
                    Address = "Address",
                    PhoneNumber = "+52519631",
                    Orders = null
                },
                DeliveryDate = DateTime.Now.AddDays(3),
                OrderLines = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.AddOrder(order));
            Assert.Equal("Cannot save an order without order date!", ex.Message);
        }

        [Fact]
        public void SavingOrderWithoutCustomerThrowsException()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(3),
                OrderLines = null
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.AddOrder(order));
            Assert.Equal("Cannot save an order without a customer!", ex.Message);
        }

        [Fact]
        public void SavingOrderShouldCallRepoAddOrderOnce()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Order order = new Order()
            {
                Customer = new Customer()
                {
                    ID = 1,
                    FirstName = "Test",
                    LastName = "LastTest",
                    Email = "test@testmail.dk",
                    Address = "Address",
                    PhoneNumber = "+52519631",
                    Orders = null
                },
                DeliveryDate = DateTime.Now.AddDays(5),
                OrderDate = DateTime.Now,
                OrderLines = null
            };

            service.AddOrder(order);
            repo.Verify(x => x.Save(order), Times.Once);
        }

        [Fact]
        public void SavingOrderShouldReturnTheSavedObject()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Order order = new Order()
            {
                Customer = new Customer()
                {
                    ID = 1,
                    FirstName = "Test",
                    LastName = "LastTest",
                    Email = "test@testmail.dk",
                    Address = "Address",
                    PhoneNumber = "+52519631",
                    Orders = null
                },
                DeliveryDate = DateTime.Now.AddDays(5),
                OrderDate = DateTime.Now,
                OrderLines = null
            };

            repo.Setup(x => x.Save(order)).Returns(order);
            Assert.Equal(order, service.AddOrder(order));


        }

        /******************************************************************************/
                                //GetOrders test///

        [Fact]
        public void GettingAllOrdersShouldCallRepoGetAllOnce()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            service.GetOrders();
            repo.Verify(x => x.GetAll(), Times.Once);
        }

        /******************************************************************************/
                            //GetOrderByID test///

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(int.MinValue)]
        public void GetOrderByIDWithInvalidIDsShouldThrowException(int id)
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.GetOrderByID(id));
            Assert.Equal("ID must be greater than 0!", ex.Message);
        }

        [Fact]
        public void GettingOrderByIdShouldCallRepoGetOrderByIDOnce()
        {
            var repo = new Mock<IOrderRepository>();
            IOrderService service = new OrderService(repo.Object);

            service.GetOrderByID(1);
            repo.Verify(x => x.GetOrderByID(1), Times.Once);
        }
    }
}
