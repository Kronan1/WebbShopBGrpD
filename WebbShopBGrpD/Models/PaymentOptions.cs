using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class PaymentOptions
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Order? Order { get; set; }
        
    }
}
