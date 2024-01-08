using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopBGrpD.Models;
using WindowDemo;

namespace WebbShopBGrpD
{
    internal class Menu
    {
        public List<Product> ShoppingCart { get; set; }

        public Menu()
        {
            ShoppingCart = new List<Product>();
        }
        public void MenuBar()
        {
            List<string> titleText = new List<string> { "# Fina butiken #", "Allt inom kläder" };
            var windowTitle = new Window("", 2, 1, titleText);
            windowTitle.Left = 45;
            windowTitle.Draw();

            //List<string> navigationText = new List<string> { "[1] = Start", "[2] = Shop", "[3] = Varukorg", "[4] = Admin" };
            List<string> navigationText = new List<string> { "[1] = Start [2] = Shop [3] = Varukorg [4] = Admin" };
            var windowNavigation = new Window("", 2, 5, navigationText);
            windowNavigation.Left = 28;
            windowNavigation.Draw();

            List<string> shoppingCartText = new List<string> { };

            int productsInCart = 3;
            switch (ShoppingCart.Count())
            {
                case 1:
                    productsInCart = 1;
                    break;
                case 2:
                    productsInCart = 2;
                    break;
                case > 2:
                    productsInCart = 3;
                    break;

                default:
                    productsInCart = 0;
                    break;
            }

            int quantity = 0;
            for (int i = 0; i < productsInCart; i++)
            {
                foreach (var product in ShoppingCart)
                {
                    if (product.Id == ShoppingCart[i].Id)
                    {
                        quantity++;
                    }
                }
                shoppingCartText.Add(ShoppingCart[i].Name + " : " + quantity);
            }

            
            
            var windowShoppingCart = new Window("", 15, 1, shoppingCartText);
            windowShoppingCart.Left = 45;
            windowShoppingCart.Draw();



        }

        public void StartPage()
        {
            MenuBar();

            List<Product> featuredProducts = new List<Product>();

            using (var myDb = new MyDbContext())
            {
                featuredProducts = myDb.Products.Where(x => x.FeaturedProduct == true).ToList(); 
            }

            try
            {
                List<string> Product1 = new List<string> { featuredProducts[0].Name.ToUpper(), featuredProducts[0].Price.ToString() + "kr", "[Q] KÖP" };

                var featuredWindow1 = new Window("", 14, 10, Product1);
                featuredWindow1.Draw();

                List<string> Product2 = new List<string> { featuredProducts[1].Name.ToUpper(), featuredProducts[1].Price.ToString() + "kr", "[W] KÖP" };

                var featuredWindow2 = new Window("", 38, 10, Product2);
                featuredWindow2.Draw();
                
                List<string> Product3 = new List<string> { featuredProducts[2].Name.ToUpper(), featuredProducts[2].Price.ToString() + "kr", "[E] KÖP" };

                var featuredWindow3 = new Window("", 80, 10, Product3);
                featuredWindow3.Draw();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void ShopPage()
        {
            MenuBar();
        }

        public void AdminPage()
        {

        }
        
    }
}
