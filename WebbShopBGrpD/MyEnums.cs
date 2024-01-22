using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopBGrpD
{
    internal class MyEnums
    {
        public enum DeliveryOption
        {
            Postnord = 45,
            Bring = 49,
            Schenker = 55,
            Dhl = 60,
            EarlyBird = 64
        }

        public enum PaymentOption
        {
            Klarna,
            Swish,
            Kreditkort,
            Faktura
        }

        public enum Gender
        {
            Man,
            Kvinna,
            Unisex
        }

        public enum ProductCategory
        {
            Tröjor,
            Byxor,
            Skor
        }
    }
}
