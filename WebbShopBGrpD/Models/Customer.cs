using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAdress { get; set; }
        public int ZIPCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }


    }
}
