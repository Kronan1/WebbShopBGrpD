using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
            List<string> navigationText = new List<string> { "[Q] = Start [W] = Shop [E] = Varukorg [R] = Admin" };
            var windowNavigation = new Window("", 2, 5, navigationText);
            windowNavigation.Left = 28;
            windowNavigation.Draw();


            #region QuantityCheck
            //int productsInCart = 3;
            //switch (ShoppingCart.Count())
            //{
            //    case 1:
            //        productsInCart = 1;
            //        break;
            //    case 2:
            //        productsInCart = 2;
            //        break;
            //    case > 2:
            //        productsInCart = 3;
            //        break;

            //    default:
            //        productsInCart = 0;
            //        break;
            //}

            //int quantity = 0;
            //for (int i = 0; i < productsInCart; i++)
            //{
            //    foreach (var product in ShoppingCart)
            //    {
            //        if (product.Id == ShoppingCart[i].Id)
            //        {
            //            quantity++;
            //        }
            //    }

            //}
            #endregion

            List<string> shoppingCartText = new List<string> { };

            shoppingCartText.Add("Varukorg");
            shoppingCartText.Add(ShoppingCart.Count.ToString() + " artiklar");

            var windowShoppingCart = new Window("", 2, 5, shoppingCartText);
            windowShoppingCart.Left = 85;
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
                List<string> Product1 = new List<string> { featuredProducts[0].Name.ToUpper(), featuredProducts[0].Price.ToString() + "kr", "[A] KÖP" };

                var featuredWindow1 = new Window("", 14, 10, Product1);
                featuredWindow1.Left = 15;
                featuredWindow1.Draw();

                List<string> Product2 = new List<string> { featuredProducts[1].Name.ToUpper(), featuredProducts[1].Price.ToString() + "kr", "[S] KÖP" };

                var featuredWindow2 = new Window("", 38, 10, Product2);
                featuredWindow2.Left = 35;
                featuredWindow2.Draw();

                List<string> Product3 = new List<string> { featuredProducts[2].Name.ToUpper(), featuredProducts[2].Price.ToString() + "kr", "[D] KÖP" };

                var featuredWindow3 = new Window("", 80, 10, Product3);
                featuredWindow3.Left = 80;
                featuredWindow3.Draw();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void ShopPage()
        {
            List<string> categoriesList = new List<string>();
            Char[] chars = { 'T', 'B', 'S' };
            MenuBar();
            int iterator = 0;
            foreach (var category in Enum.GetValues(typeof(MyEnums.ProductCategory)))
            {
                categoriesList.Add($" [{chars[iterator]}] = " + category.ToString());
                iterator++;
            }
            var categoriesWindow = new Window("Categories", 15, 10, categoriesList);
            categoriesWindow.Left = 15;
            categoriesWindow.Draw();

            bool process = true;

            while (process)
            {

                ConsoleKeyInfo input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.Q:
                        Console.Clear();
                        StartPage();
                        break;
                    case ConsoleKey.W:
                        Console.Clear();
                        ShopPage();
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        ShoppingCartPage();
                        break;
                    case ConsoleKey.R:
                        break;

                    case ConsoleKey.T:
                        showProductCategories(0);
                        break;
                    case ConsoleKey.B:
                        showProductCategories(1);
                        break;
                    case ConsoleKey.S:
                        showProductCategories(2);
                        break;
                }
            }

        }

        public void AdminPage()
        {

        }

        public void ShoppingCartPage()
        {

            bool process = true;

            while (process)
            {
                Console.Clear();
                List<Product> shoppingCartFilter = ShoppingCart.Distinct().ToList();
                Dictionary<Product, int> productDictionary = shoppingCartFilter.ToDictionary(x => x, value => 0);


                
                foreach (Product product in shoppingCartFilter)
                {
                    foreach (var product2 in ShoppingCart)
                    {
                        if (product2.Id == product.Id)
                        {
                            productDictionary[product] += 1;
                            
                        }
                    }
                }

                List<string> shoppingCartText = new List<string>();

                double totalSum = 0;
                int iterator = 1;
                foreach (var product in productDictionary)
                {
                    shoppingCartText.Add($" [{iterator}] " + product.Key.Name + " Antal " + product.Value.ToString() + " : " + (shoppingCartFilter[iterator - 1].Price * product.Value) + " kr") ;
                    totalSum += (shoppingCartFilter[iterator - 1].Price * product.Value);
                    iterator++;   
                }

                shoppingCartText.Add(" Totalsumma : " + totalSum + " kr");
                shoppingCartText.Add("");
                shoppingCartText.Add(" [X] för att backa");
                shoppingCartText.Add(" [Y] för att ändra produkt");
                shoppingCartText.Add(" [K] för att gå till kassan");

                var shoppingCartWindow = new Window("Varukorg", 15, 10, shoppingCartText);
                shoppingCartWindow.Left = 45;
                shoppingCartWindow.Draw();

                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.X)
                {
                    process = false;
                    Console.Clear();
                    ShopPage();
                }
                else if (input.Key == ConsoleKey.Y)
                {
                    List<string> instructionsText = new();
                    instructionsText.Add(" Välj artikel genom att ange artikelnummer");

                    var instructionsWindow = new Window("Instruktioner", 15, 5, instructionsText);
                    instructionsWindow.Left = 45;
                    instructionsWindow.Draw();

                    

                    if (int.TryParse(Console.ReadLine(), out int input2))
                    {
                        if (productDictionary.Count >= input2 && input2 >= 1)
                        {
                            Console.Clear();
                            bool processProduct = true;
                            while (processProduct)
                            {

                                var currentProduct = shoppingCartFilter[input2 - 1];
                                

                                int currentProductAmount = 0;
                                foreach (var product2 in ShoppingCart)
                                {
                                    if (product2 == currentProduct)
                                    {
                                        currentProductAmount++;
                                    }
                                }

                                List<string> currentProductList = new();
                                currentProductList.Add(" " + currentProduct.Name);
                                currentProductList.Add( " Antal : " + currentProductAmount.ToString());
                                currentProductList.Add(" ");
                                currentProductList.Add(" [A] för att minska antal");
                                currentProductList.Add(" [D] för att öka antal");
                                currentProductList.Add(" [X] för att bekräfta");


                                var currentProductWindow = new Window("", 15, 15, currentProductList);
                                currentProductWindow.Left = 45;
                                currentProductWindow.Draw();
                                input = Console.ReadKey(true);

                                
                                switch (input.Key)
                                {
                                    case ConsoleKey.A:
                                        if (ShoppingCart.Contains(currentProduct))
                                        {
                                            ShoppingCart.Remove(currentProduct);
                                        }
                                        break;
                                    case ConsoleKey.D:
                                        if (ShoppingCart.Contains(currentProduct) && currentProduct.Quantity > currentProductAmount)
                                        {
                                            ShoppingCart.Add(currentProduct);
                                        }
                                        break;
                                    case ConsoleKey.X:
                                        processProduct = false;
                                        break;
                                }
                            }
                            
                        }
                        else
                        {
                            instructionsText.Add(" Finns ingen artikel med det numret");

                            instructionsWindow = new Window("Instruktioner", 15, 5, instructionsText);
                            instructionsWindow.Left = 45;
                            instructionsWindow.Draw();
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        instructionsText.Add(" Felaktig inmatning");

                        instructionsWindow = new Window("Instruktioner", 15, 5, instructionsText);
                        instructionsWindow.Left = 45;
                        instructionsWindow.Draw();
                        Thread.Sleep(1000);
                    }
                }
            }
        }


        //int quantity = 0;
        //for (int i = 0; i < productsInCart; i++)
        //{
        //    foreach (var product in ShoppingCart)
        //    {
        //        if (product.Id == ShoppingCart[i].Id)
        //        {
        //            quantity++;
        //        }
        //    }

        //}


        public void showProductCategories(int category)
        {
            List<Product> products;

            Console.Clear();

            using (var myDb = new MyDbContext())
            {
                products = myDb.Products.Where(x => x.ProductCategory == category).ToList();
            }

            List<string> productNameList = new List<string>();


            int iterator = 1;
            foreach (var product in products)
            {
                if (product.ProductCategory == category)
                {
                    productNameList.Add($" [{iterator.ToString()}] " + product.Name + " " + product.Price.ToString() + " kr");
                    iterator++;
                }

            }
            productNameList.Add(" [X] för att backa");

            var categoriesWindow = new Window("Välj produkt", 15, 10, productNameList);
            categoriesWindow.Left = 35;
            categoriesWindow.Draw();

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    showProductInfo(products[0]);
                    break;
                case ConsoleKey.D2:
                    showProductInfo(products[1]);
                    break;
                case ConsoleKey.D3:
                    showProductInfo(products[2]);
                    break;
                case ConsoleKey.D4:
                    showProductInfo(products[3]);
                    break;
                case ConsoleKey.D5:
                    showProductInfo(products[4]);
                    break;
                case ConsoleKey.X:
                    break;
            }
        }

        public void showProductInfo(Product product)
        {
            Console.Clear();

            List<string> productInfo = new List<string>();
            productInfo.Add(" " + product.Name.ToString());
            productInfo.Add(" " + product.Info.ToString());
            productInfo.Add(" Pris: " + product.Price.ToString() + " kr");
            productInfo.Add((" Passar: " + (MyEnums.Gender)product.Gender).ToString());
            productInfo.Add(" ");
            productInfo.Add(" [P] Lägg till produkten i varukorgen");
            productInfo.Add(" [X] för att backa");

            var productInfoWindow = new Window("Produktinformation", 15, 10, productInfo);
            productInfoWindow.Left = 35;
            productInfoWindow.Draw();


            List<string> shoppingCartText = new List<string> { };

            shoppingCartText.Add("Varukorg");
            shoppingCartText.Add(ShoppingCart.Count.ToString() + " artiklar");

            var windowShoppingCart = new Window("", 2, 5, shoppingCartText);
            windowShoppingCart.Left = 85;
            windowShoppingCart.Draw();

            bool process = true;

            while (process)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.X:
                        process = false;
                        Console.Clear();
                        ShopPage();
                        break;
                    case ConsoleKey.P:

                        shoppingCartText.Clear();
                        ShoppingCart.Add(product);
                        shoppingCartText.Add("Varukorg");
                        shoppingCartText.Add(ShoppingCart.Count.ToString() + " artiklar");

                        windowShoppingCart = new Window("", 2, 5, shoppingCartText);
                        windowShoppingCart.Left = 85;
                        windowShoppingCart.Draw();
                        break;
                }
            }
        }
    }
}
