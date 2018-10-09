using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Core.ApplicationService;
using ipcsmmd_webshop.Core.ApplicationService.Impl;
using ipcsmmd_webshop.Core.Entity;
using System.IO;

namespace TestCore.ApplicationService.Impl
{
    public class CustomerServiceTest
    {
        #region AddCustomer
        [Fact]
        public void AddCustomerWithIDThrowsException()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(moqRep.Object);
            Customer newCustomer = new Customer() {
                ID = 1
            };
            Exception e = Assert.Throws<InvalidDataException>(() => customerService.AddCustomer(newCustomer));
            Assert.Equal("Cannot add customer with existing ID!", e.Message);
        }

        [Fact]
        public void AddCustomerWithoutFirstNameThrowsException()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(moqRep.Object);
            Customer newCustomer = new Customer() {
                Email = "cust1@fakemail.dk",
                Address = "BongiStreet",
                LastName = "Olesen",
                PhoneNumber = "+4512345678"
            };
            Exception e = Assert.Throws<InvalidDataException>(() => customerService.AddCustomer(newCustomer));
            Assert.Equal("Cannot add customer without first name!", e.Message);
        }

        [Fact]
        public void AddCustomerWithoutLastNameThrowsException()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(moqRep.Object);
            Customer newCustomer = new Customer() {
                Email = "cust1@fakemail.dk",
                Address = "BongiStreet",
                FirstName = "John",
                PhoneNumber = "+4512345678"
            };
            Exception e = Assert.Throws<InvalidDataException>(() => customerService.AddCustomer(newCustomer));
            Assert.Equal("Cannot add customer without last name!", e.Message);
        }

        [Fact]
        public void AddCustomerWithoutEmailThrowsException()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(moqRep.Object);
            Customer newCustomer = new Customer() {
                Address = "BongiStreet",
                FirstName = "John",
                LastName = "Olesen",
                PhoneNumber = "+4512345678"
            };
            Exception e = Assert.Throws<InvalidDataException>(() => customerService.AddCustomer(newCustomer));
            Assert.Equal("Cannot add customer without email address!", e.Message);
        }

        [Fact]
        public void AddCustomerWithoutAddressThrowsException()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(moqRep.Object);
            Customer newCustomer = new Customer() {
                Email = "cust1@fakemail.dk",
                FirstName = "John",
                LastName = "Olesen",
                PhoneNumber = "+4512345678"
            };
            Exception e = Assert.Throws<InvalidDataException>(() => customerService.AddCustomer(newCustomer));
            Assert.Equal("Cannot add customer without address!", e.Message);
        }

        [Fact]
        public void AddCustomersShouldCallAddOnce()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService service = new CustomerService(moqRep.Object);
            Customer newCustomer = new Customer() {
                Email = "cust1@fakemail.dk",
                Address = "BongiStreet",
                FirstName = "John",
                LastName = "Olesen",
                PhoneNumber = "+4512345678"
            };
            service.AddCustomer(newCustomer);
            moqRep.Verify(x => x.Save(newCustomer), Times.Once);
        }
        #endregion

        #region GetCustomer
        [Fact]
        public void GetCustomerWithIDMissingIDThrowsException()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(moqRep.Object);
            Exception e = Assert.Throws<ArgumentException>(() => customerService.GetCustomerByID(new int()));
            Assert.Equal("Missing customer ID!", e.Message);
        }

        [Fact]
        public void GetAllCustomersShouldCallGetAllOnce()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService service = new CustomerService(moqRep.Object);

            service.GetAllCustomers();
            moqRep.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void GetCustomerByIDShouldCallGetByIDOnce()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService service = new CustomerService(moqRep.Object);

            service.GetCustomerByID(1);
            moqRep.Verify(x => x.GetCustomerByID(1), Times.Once);
        }
        #endregion

        #region UpdateCustomer
        [Fact]
        public void UpdateCustomerWithMissingIDThrowsException()
        {
            var moqRep = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(moqRep.Object);
            Customer newCustomer = new Customer() {
                Email = "cust1@fakemail.dk",
                Address = "BongiStreet",
                FirstName = "John",
                LastName = "Olesen",
                PhoneNumber = "+4512345678"
            };
            Exception e = Assert.Throws<ArgumentException>(() => customerService.UpdateCustomer(newCustomer));
            Assert.Equal("Missing customer ID!", e.Message);
        }
        #endregion
    }
}
