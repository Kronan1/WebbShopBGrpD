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
            //    products = myDb.Products.ToList();
            //    suppliers = myDb.ProductSuppliers.ToList();
            //}


            menu.StartPage();
            

            Console.ReadLine();


            // Fixa admin
            // Fixa Beställningar
        }
    }
}
