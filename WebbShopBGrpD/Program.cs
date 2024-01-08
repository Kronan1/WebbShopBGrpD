using WebbShopBGrpD.Models;

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


        }
    }
}
