using Azure;
using WebbShopBGrpD.Models;
using WindowDemo;

namespace WebbShopBGrpD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>();
            List<ProductSupplier> suppliers = new List<ProductSupplier>();
            
            Menu menu = new Menu();


            

            using (var myDb = new MyDbContext())
            {
                products = myDb.Products.ToList();
                suppliers = myDb.ProductSuppliers.ToList();
            }

            menu.ShoppingCart.Add(products[1]);
            menu.ShoppingCart.Add(products[0]);

            foreach (var product in menu.ShoppingCart)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
            }


            int test = 0;

            menu.MenuBar();

            Console.ReadLine();



            





        }
    }
}
