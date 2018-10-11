using Microsoft.EntityFrameworkCore;
using ipcsmmd_webshop.Core.Entity;

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

        //    modelBuilder.Entity<OrderLine>()
        //        .HasOne(ol => ol.Order)
        //        .WithMany(o => o.OrderLines)
        //        .HasForeignKey(ol => ol.OrderID)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    modelBuilder.Entity<OrderLine>()
        //        .HasOne(ol => ol.Beer)
        //        .WithMany(b => b.OrderLines)
        //        .HasForeignKey(ol => ol.BeerID)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    modelBuilder.Entity<OrderLine>()
        //        .HasKey(ol => new { ol.OrderID, ol.BeerID });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
       // public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Beer> Beers { get; set; }
    }
}
