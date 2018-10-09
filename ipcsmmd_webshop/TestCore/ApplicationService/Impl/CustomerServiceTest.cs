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
        [Fact]
        public void CreateCustomerWithIDThrowsException()
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
        public void CreateCustomerWithoutFirstNameThrowsException()
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
        public void CreateCustomerWithoutLastNameThrowsException()
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
        public void CreateCustomerWithoutEmailThrowsException()
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
        public void CreateCustomerWithoutAddressThrowsException()
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
    }
}
