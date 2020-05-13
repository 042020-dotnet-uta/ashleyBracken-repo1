using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SleepingSelkieDataAccess.DataModels;

namespace SleepingSelkieDataAccess
{
    public class SelkieContext : DbContext
    {
        public SelkieContext() { }
        public SelkieContext(DbContextOptions<SelkieContext> options) : base(options) { }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products {get;set;}
        public DbSet<Customer> Customers { get; set; }

        
       protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=TheSleepingSelkie.db");
            }
        }
    }
}
