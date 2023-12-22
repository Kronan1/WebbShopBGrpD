using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class Product
    {
        public Product()
        {
            PurchasedArticles = new HashSet<PurchasedArticles>();
            Sales = new HashSet<Sale>(); 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Info { get; set; }
        public int Quantity { get; set; }

        public virtual FeaturedProducts? FeaturedProducts { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ProductSupplier Supplier { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<PurchasedArticles> PurchasedArticles { get; set; }
    }
}
