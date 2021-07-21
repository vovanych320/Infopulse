using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPlusAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace AspPlusAngular.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders  { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order_Products> OrderProducts  { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            Guid id = Guid.NewGuid();
            string s = id.ToString("N");

            modelBuilder.Entity<Customer>().HasData(new Customer
                {
                    CustomerId = s.Substring(0,8),
                    CustomerName = "Vova",
                    CustomerAddress = "Kyiv",
                    TotalOrderCost = 134.42,
                    OrdersCount = 4,
                    Date = DateTime.Now
                }
            );
        }

    }
}
