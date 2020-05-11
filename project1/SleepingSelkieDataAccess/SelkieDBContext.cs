using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SleepingSelkieDataAccess.DataModels;

namespace SleepingSelkieDataAccess
{
    class SelkieContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products {get;set;}
        public DbSet<Customer> Customers { get; set; }
    
    }
}
