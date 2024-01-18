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
        public int PaymentOption { get; set; }
        public int DeliveryOption { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<PurchasedArticles> PurchasedArticles { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
