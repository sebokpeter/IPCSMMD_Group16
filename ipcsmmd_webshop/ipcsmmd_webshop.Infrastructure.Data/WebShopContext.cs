using System;
using System.Collections.Generic;
using System.Text;
using ipcsmmd_webshop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace ipcsmmd_webshop.Infrastructure.Data
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions<WebShopContext> opt): base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Order)
                .WithMany(o => o.OrderLines)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Beer)
                .WithMany(b => b.OrderLines)
                .OnDelete(DeleteBehavior.SetNull);

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Beer> Beers { get; set; }
    }
}
