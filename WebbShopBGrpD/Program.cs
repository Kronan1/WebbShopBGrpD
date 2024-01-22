using Azure;
using System.Globalization;
using WebbShopBGrpD.Models;
using WindowDemo;

namespace WebbShopBGrpD
{

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sv-SE");



            //List<Product> products = new List<Product>();
            //List<ProductSupplier> suppliers = new List<ProductSupplier>();

            Menu menu = new Menu();

            //using (var myDb = new MyDbContext())
            //{
            //    var order = myDb.Orders.OrderBy(x => x.Id)
            //        .Last();

            //    var pa = order.PurchasedArticles;
            //    int test = 0;
            //}


            menu.StartPage();
            

            Console.ReadLine();


            // Fixa admin
            // Fixa Beställningar
        }
    }
}
