using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Info { get; set; }
        public int Quantity { get; set; }
        public bool Sale { get; set; }
        public bool FeaturedProduct { get; set; }
        public int Gender { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductSupplier Supplier { get; set; }
    }
}
