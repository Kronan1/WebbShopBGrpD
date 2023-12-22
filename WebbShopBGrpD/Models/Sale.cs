﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class Sale
    {
        public Sale() // Bit i products?
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
