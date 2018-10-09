using ipcsmmd_webshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipcsmmd_webshop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(WebShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            #region Customers
            Customer cust1 = ctx.Customers.Add(new Customer() {
                Email = "cust1@fakemail.dk",
                Address = "BongiStreet",
                FirstName = "John",
                LastName = "Olesen",
                PhoneNumber = "+4512345678"
            }).Entity;

            Customer cust2 = ctx.Customers.Add(new Customer() {
                Email = "cust2@fakemail.dk",
                Address = "BongiStreet 22",
                FirstName = "Bill",
                LastName = "Bøllesen"
            }).Entity;
            #endregion

            #region Orders
            Order order1 = ctx.Orders.Add(new Order() {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Customer = cust1
            }).Entity;

            ctx.Orders.Add(new Order() {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Customer = cust2
            });

            Order order2 = ctx.Orders.Add(new Order() {
                OrderDate = DateTime.Now.AddMonths(-5),
                DeliveryDate = DateTime.Now.AddMonths(-5),
                Customer = cust1
            }).Entity;

            ctx.Orders.Add(new Order() {
                OrderDate = DateTime.Now.AddMonths(-5),
                DeliveryDate = DateTime.Now.AddMonths(-5),
                Customer = cust2
            });
            #endregion

            #region Beer
            Beer beer1 = ctx.Add(new Beer() {
                Name = "Test",
                Brand = "Carlsberg",
                Type = BeerType.Light,
                Percentage = 4.5f,
                Price = 4.99f,
                ImageURL = "https://gradybritton.com/assets/beertest-closeup.jpg",
                Stock = 500
            }).Entity;

            Beer beer2 = ctx.Add(new Beer() {
                Name = "Test",
                Brand = "Tuborg",
                Type = BeerType.Dark,
                Percentage = 3.5f,
                Price = 7.99f,
                ImageURL = "https://untappd.akamaized.net/photo/2015_03_07/511da93fcec6a8d1fb5114f73f1558e5_320x320.jpg",
                Stock = 300
            }).Entity;

            Beer beer3 = ctx.Add(new Beer() {
                Name = "Test",
                Brand = "FakeBrand",
                Type = BeerType.Brown,
                Percentage = 4.9f,
                Price = 66.99f,
                ImageURL = "https://belgianbeershrimper.files.wordpress.com/2009/11/kwak1.jpg",
                Stock = 123456
            }).Entity;
            #endregion

            #region OrderLines
            ctx.Add(new OrderLine() {
                Beer = beer1,
                Order = order1,
                Quanity = 20
            });

            ctx.Add(new OrderLine()
            {
                Beer = beer2,
                Order = order1,
                Quanity = 10
            });

            ctx.Add(new OrderLine() {
                Beer = beer3,
                Order = order2,
                Quanity = 50
            });

            ctx.Add(new OrderLine() {
                Beer = beer1,
                Order = order2,
                Quanity = 1
            });
            #endregion
        }
    }
}
