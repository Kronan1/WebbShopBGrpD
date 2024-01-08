using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class Order
    {
        public Order()
        {
            PurchasedArticles = new HashSet<PurchasedArticles>();
        }
        public int Id { get; set; }
        public bool PaymentOption { get; set; }
        public bool DeliveryOption { get; set; }

        public virtual ICollection<PurchasedArticles> PurchasedArticles { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
