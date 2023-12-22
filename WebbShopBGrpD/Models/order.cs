﻿using System;
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
            PaymentOptions = new HashSet<PaymentOptions>();
            DeliveryOptions = new HashSet<DeliveryOptions>();
        }
        public int Id { get; set; }

        public virtual ICollection<PurchasedArticles> PurchasedArticles { get; set; }
        public virtual ICollection<PaymentOptions> PaymentOptions { get; set; } // En till en?
        public virtual ICollection<DeliveryOptions> DeliveryOptions { get; set; } // En till en?
        public virtual Customer Customer { get; set; }
    }
}
