using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class ProductSupplier
    {
        public ProductSupplier()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAdress { get; set; }

        public string City { get; set; }

        public string Country{ get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
