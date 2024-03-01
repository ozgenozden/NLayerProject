using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Concrete.EntityFramework
{
	public class NorthwindContext:DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source = localhost; Initial Catalog = Northwind; User Id=SA;
Password=reallyStrongPwd123; TrustServerCertificate=True");

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Custumer> Custumers  { get; set; }
        public DbSet<Order> Orders  { get; set; }

    }
}

