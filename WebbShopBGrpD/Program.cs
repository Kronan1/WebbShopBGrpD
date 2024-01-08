using WebbShopBGrpD.Models;
using WindowDemo;

namespace WebbShopBGrpD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Product
            //using (var myDb = new MyDbContext())
            //{
            //myDb.AddRange(
            //new Gender
            //{
            //    Name = "Man"
            //}
            //    );

            //myDb.AddRange(
            //    new ProductSupplier
            //    {
            //        Name = "Nike",
            //        StreetAdress = "Malmvägen 15",
            //        City = "Stockholm",
            //        Country = "Sverige"
            //    }
            //);


            #endregion

            Menu.MenuBar();

            Console.ReadLine();

            Dictionary<string, float> PaymentOptionPrice = new Dictionary<string, float>();

            PaymentOptionPrice.Add(MyEnums.DeliveryOption.Postnord.ToString(), 50);
            PaymentOptionPrice.Add(MyEnums.DeliveryOption.Dhl.ToString(), 75);
            PaymentOptionPrice.Add(MyEnums.DeliveryOption.Schenker.ToString(), 60);
            PaymentOptionPrice.Add(MyEnums.DeliveryOption.Bring.ToString(), 49);
            PaymentOptionPrice.Add(MyEnums.DeliveryOption.EarlyBird.ToString(), 64);

            while (true)
            {
                Console.WriteLine((MyEnums.DeliveryOption.Postnord.ToString()));
                Console.WriteLine(MyEnums.Gender.Man);
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadLine();
            }


            // Hämtar från databasen
            List<string> categoriesText = new List<string> { "Byxor", "Tröjor", "Skor", "Skjortor", "xxxxxxxxxxxxxxxxxxxxxxx" };
            //foreach(var text in categoriesText)
            //{
            //    Console.WriteLine(text);
            //}

            // Detta hämtas från databas
            List<string> cartText = new List<string> { "1 st Blå byxor", "1 st Grön tröja", "1 st Röd skjorta" };
            var windowCart = new Window("Din varukorg", 30, 6, cartText);
            windowCart.Draw();

            var windowCategories = new Window("Kategorier", 2, 6, categoriesText);
            windowCategories.Draw();

            List<string> topText = new List<string> { "# Fina butiken #", "Allt inom kläder" };
            var windowTop = new Window("", 2, 1, topText);
            windowTop.Draw();

            windowTop.Left = 45;
            windowTop.Draw();

            Console.WriteLine("Nån annan text");

            Console.ReadLine();


        }
    }
}
