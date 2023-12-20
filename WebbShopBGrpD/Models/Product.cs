﻿using System;
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
        public int GenderId { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
    }
}
