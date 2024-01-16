using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=WebbShopB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Models.PurchasedArticles> PurchasedArticles { get; private set; }
        public DbSet<Models.ProductCategory> ProductCategories { get; set; }
    }
}
