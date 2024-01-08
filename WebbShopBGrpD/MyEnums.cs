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
            Postnord = 50,
            Dhl = 75,
            Schenker = 60,
            Bring = 49,
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


    }
}
