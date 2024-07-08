using ETicaretApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CF86AI3\\SQLEXPRESS01;Initial Catalog=EticaretDBb;Integrated Security=true;TrustServerCertificate = True;");
            //Data Source=DESKTOP-CF86AI3\\SQLEXPRESS01;Initial Catalog=EticaretDB;Integrated Security=true;TrustServerCertificate=True;
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EticaretDB;Integrated Security=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ETicaretApi.Domain.Entities.Exception> Exceptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //public ETicaretAPIDBContext(DbContextOptions options) : base(options)
        //{
        //}
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Customer> Customers { get; set; }
    }
}
