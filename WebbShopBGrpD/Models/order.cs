using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class Order
    {
        public int id { get; set; }
        public int DeliveryOptionId { get; set; }
        public int PaymentOptionId { get; set; }
        public int CustomerId { get; set; }
        public int PurchasedArticlesId { get; set; }
    }
}
