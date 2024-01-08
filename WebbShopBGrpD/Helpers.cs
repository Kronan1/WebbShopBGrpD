using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopBGrpD.Models;

namespace WebbShopBGrpD
{
    internal class Helpers
    {

        public List<Product> ShoppingCart { get; set; }
        public Helpers()
        {

        }

        public static Dictionary<string, float> CreateDeliveryPrice()
        {
            Dictionary<string, float> DeliveryPrice = new Dictionary<string, float>();
            DeliveryPrice.Add(MyEnums.DeliveryOption.Postnord.ToString(), 50);
            DeliveryPrice.Add(MyEnums.DeliveryOption.Dhl.ToString(), 75);
            DeliveryPrice.Add(MyEnums.DeliveryOption.Schenker.ToString(), 60);
            DeliveryPrice.Add(MyEnums.DeliveryOption.Bring.ToString(), 49);
            DeliveryPrice.Add(MyEnums.DeliveryOption.EarlyBird.ToString(), 64);

            return DeliveryPrice;
        }


        //// Hämtar från databasen
        //List<string> categoriesText = new List<string> { "Byxor", "Tröjor", "Skor", "Skjortor", "xxxxxxxxxxxxxxxxxxxxxxx" };
        ////foreach(var text in categoriesText)
        ////{
        ////    Console.WriteLine(text);
        ////}

        //// Detta hämtas från databas
        //List<string> cartText = new List<string> { "1 st Blå byxor", "1 st Grön tröja", "1 st Röd skjorta" };
        //var windowCart = new Window("Din varukorg", 30, 6, cartText);
        //windowCart.Draw();

        //var windowCategories = new Window("Kategorier", 2, 6, categoriesText);
        //windowCategories.Draw();

        //List<string> topText = new List<string> { "# Fina butiken #", "Allt inom kläder" };
        //var windowTop = new Window("", 2, 1, topText);
        //windowTop.Draw();

        //windowTop.Left = 45;
        //windowTop.Draw();

        //Console.WriteLine("Nån annan text");

        //Console.ReadLine();




    }
}
