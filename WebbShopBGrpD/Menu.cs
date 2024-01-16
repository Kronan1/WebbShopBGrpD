using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebbShopBGrpD.Models;
using WindowDemo;

namespace WebbShopBGrpD
{
    internal class Menu
    {
        public List<Product> ShoppingCart { get; set; }
        public List<string> ShoppingCartText { get; set; }
        public double TotalSum { get; set; }
        public Dictionary<Product, int> AmountPerProduct { get; set; }

        public Menu()
        {
            ShoppingCart = new List<Product>();
            ShoppingCartText = new List<string>();
            TotalSum = 0;
            AmountPerProduct = new Dictionary<Product, int>();
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

                bool active = true;
                while (active)
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
                            Console.Clear();
                            Admin admin = new Admin();
                            admin.AdminPage();
                            break;

                        case ConsoleKey.A:
                            ShoppingCart.Add(featuredProducts[0]);
                            Console.Clear();
                            StartPage();
                            break;
                        case ConsoleKey.S:
                            ShoppingCart.Add(featuredProducts[1]);
                            Console.Clear();
                            StartPage();
                            break;
                        case ConsoleKey.D:
                            ShoppingCart.Add(featuredProducts[2]);
                            Console.Clear();
                            StartPage();
                            break;


                    }

                }


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

            string goTo = "Error";
            while (process)
            {

                ConsoleKeyInfo input = Console.ReadKey(true);

                
                switch (input.Key)
                {
                    case ConsoleKey.Q:
                        Console.Clear();
                        goTo = "StartPage";
                        process = false;
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
                        ShowProductCategories(1);
                        break;
                    case ConsoleKey.B:
                        ShowProductCategories(2);
                        break;
                    case ConsoleKey.S:
                        ShowProductCategories(3);
                        break;
                    case ConsoleKey.Z:
                        Console.Clear();
                        ShowSearchProduts();
                        break;
                }
            }

            switch (goTo)
            {
                case "StartPage":
                    break;
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

                foreach (var product in ShoppingCart)
                {
                    if (!AmountPerProduct.ContainsKey(product))
                    {
                        AmountPerProduct.Add(product, 0);
                    }

                }
                foreach (var product in AmountPerProduct)
                {
                    AmountPerProduct[product.Key] += 1;
                }

                //foreach (Product product in shoppingCartFilter)
                //{
                //    foreach (var product2 in ShoppingCart)
                //    {
                //        if (product2.Id == product.Id)
                //        {
                //            productDictionary[product] += 1;

                //        }
                //    }
                //}

                List<string> shoppingCartText = new List<string>();

                double totalSum = 0;
                int iterator = 1;
                foreach (var product in AmountPerProduct)
                {
                    shoppingCartText.Add($" [{iterator}] " + product.Key.Name + " Antal " + product.Value.ToString() + " : " + (shoppingCartFilter[iterator - 1].Price * product.Value) + " kr");
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
                else if (input.Key == ConsoleKey.K)
                {
                    Purchase();
                    Console.Clear();
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


        public void ShowProductCategories(int category)
        {
            List<Product> products;

            Console.Clear();

            using (var myDb = new MyDbContext())
            {
                products = myDb.Products.Where(x => x.Category.Id == category).ToList();
                //products = myDb.ProductCategories.Where(x => x.pr == category).ToList();
            }

            List<string> productNameList = new List<string>();


            int iterator = 1;
            foreach (var product in products)
            {
                    productNameList.Add($" [{iterator.ToString()}] " + product.Name + " " + product.Price.ToString() + " kr");
                    iterator++;
            }
            productNameList.Add(" [X] för att backa");

            var categoriesWindow = new Window("Välj produkt", 15, 10, productNameList);
            categoriesWindow.Left = 35;
            categoriesWindow.Draw();

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    ShowProductInfo(products[0]);
                    break;
                case ConsoleKey.D2:
                    ShowProductInfo(products[1]);
                    break;
                case ConsoleKey.D3:
                    ShowProductInfo(products[2]);
                    break;
                case ConsoleKey.D4:
                    ShowProductInfo(products[3]);
                    break;
                case ConsoleKey.D5:
                    ShowProductInfo(products[4]);
                    break;
                case ConsoleKey.X:
                    Console.Clear();
                    ShopPage();
                    break;
            }
        }

        public void ShowProductInfo(Product product)
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

        public Customer ValidateCustomer()
        {
            Console.Clear();
            List<string> inputAlternatives = new List<string>();

            inputAlternatives.Add(" [E] För existerande kund");
            inputAlternatives.Add(" [A] För ny kund");

            var customerOptionWindow = new Window("Leverans alternativ", 15, 10, inputAlternatives);
            customerOptionWindow.Left = 45;
            customerOptionWindow.Draw();

            Customer customer = new();
            while (customer.Id == 0)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.E:
                        customer = ExistingCustomer();
                        break;
                    case ConsoleKey.A:
                        customer = NewCustomer();
                        break;
                }
            }

            return customer;
            
        }

        public Customer ExistingCustomer()
        {
            Console.WriteLine("Epost: ");
            Customer customer = new Customer();
            var email = Console.ReadLine();

            string connectionString = "Server=.\\SQLExpress;Database=WebbShopB;Trusted_Connection=True;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = "SELECT * FROM Customer WHERE MailAdress = @email";

                customer = connection.QuerySingleOrDefault<Customer>(sql);
            }


            Console.Clear();
            if (customer != null) 
            {
                return customer;
            }
            else
            {
                Console.WriteLine("Ingen kund med den mailadressen finns registrerad.");
                Thread.Sleep(1000);
                Console.Clear();
            }

            return customer;
        }

        public Customer NewCustomer()
        {
            Console.Clear();

            Console.Write("Namn: ");
            var name = Console.ReadLine();
            Console.Clear();

            Console.Write("Adress: ");
            var address = Console.ReadLine();
            Console.Clear();

            int zipCode = 0;
            do
            {
                Console.Write("Postnummer");
                if (!int.TryParse(Console.ReadLine(), out zipCode))
                {
                    Console.WriteLine(" Ett nummer mellan 10000 och 99999");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (zipCode < 10000 || zipCode > 99999);
            Console.Clear();

            Console.Write("Stad: ");
            var city = Console.ReadLine();
            Console.Clear();

            Console.Write("Land: ");
            var country = Console.ReadLine();
            Console.Clear();

            int phoneNumber = 0;
            do
            {
                Console.Write("Mobilnummer: ");
                if (!int.TryParse(Console.ReadLine(), out phoneNumber))
                {
                    Console.WriteLine("Enbart siffror");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (phoneNumber < 1);
            Console.Clear();

            Console.Write("Epost: ");
            var email = Console.ReadLine();
            Console.Clear();

            int age = 0;
            do
            {
                Console.Write("Ålder: ");
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Enbart siffror");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (phoneNumber < 1);
            Console.Clear();

            Console.WriteLine("Lösenord: ");
            var password = Console.ReadLine();
            Console.Clear();

            Customer customer = new();
            try
            {
                customer.Name = name;
                customer.StreetAdress = address;
                customer.ZIPCode = zipCode;
                customer.City = city;
                customer.Country = country;
                customer.PhoneNumber = phoneNumber;
                customer.MailAdress = email;
                customer.Age = age;
                customer.Password = password;

                using (var myDb = new MyDbContext())
                {
                    myDb.Customers.Add(customer);

                    myDb.SaveChanges();

                    customer = myDb.Customers.OrderByDescending(c => c.Id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }


            return customer;
        }

        public void Purchase()
        {

            var deliveryOption = DeliveryMenu();
            var paymentOption = PaymentMenu();
            var customer = ValidateCustomer();

            List<string> customerInfo = new();
            customerInfo.Add(" Namn: " + customer.Name);
            customerInfo.Add(" Adress: " + customer.StreetAdress);
            customerInfo.Add(" Leverans: " + deliveryOption);
            customerInfo.Add(" Betalningsmetod: " + paymentOption);
            customerInfo.Add(" Pris: " + ((TotalSum + (int)deliveryOption) * 1.25).ToString());
            customerInfo.Add(" ");
            customerInfo.Add(" [K] Slutför köp");
            customerInfo.Add(" [X] Avbryt köp");

            var customerWindow = new Window("Kund", 15, 5, customerInfo);
            customerWindow.Left = 45;
            customerWindow.Draw();

            bool process = true;
            while (process)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.K:
                        using (var myDb = new MyDbContext())
                        {
                            List<PurchasedArticles> purchasedArticlesList = new();
                            Dictionary<Product, int> productDict = new();
                            Order order = new Order();
                            foreach (var product in ShoppingCart)
                            {
                                if (productDict.ContainsKey(product))
                                {
                                    productDict[product] += 1;
                                }
                                else
                                {
                                    productDict.Add(product, 1);
                                }
                                
                            }

                            foreach (var product in myDb.Products)
                            {
                                foreach (var product2 in productDict)
                                {
                                    if (product.Name == product2.Key.Name)
                                    {
                                        product.Quantity -= product2.Value;
                                    }
                                }
                            }

                            PurchasedArticles purchasedArticles = new();
                            foreach (var product in productDict)
                            {
                                purchasedArticles.Product = product.Key;
                                purchasedArticles.Quantity = product.Value;
                                purchasedArticles.Order = order;
                                purchasedArticlesList.Add(purchasedArticles);
                            }

                            
                            order.Customer = customer;
                            order.DeliveryOption = (int)deliveryOption;
                            order.PaymentOption = (int)paymentOption;
                            order.PurchasedArticles = purchasedArticlesList;

                            //order.PurchasedArticles = ShoppingCart; Behöver fixa med purchasedArticles
                            //myDb.Orders.Add();
                        }
                        break;
                    case ConsoleKey.X:
                        string connectionString = "Server=.\\SQLExpress;Database=WebbShopB;Trusted_Connection=True;TrustServerCertificate=True;";

                        int customerId = customer.Id;
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            var sql = "DELETE FROM Customer WHERE Id = @customerId";

                            customer = connection.QuerySingleOrDefault<Customer>(sql);
                        }
                        process = false;
                        break;
                }
            }

            ShopPage();

        }

        public MyEnums.DeliveryOption DeliveryMenu()
        {
            Console.Clear();
            List<string> deliveryInfo = new();
            int iterator = 1;
            foreach (var deliveryOption in Enum.GetValues(typeof(MyEnums.DeliveryOption)))
            {
                deliveryInfo.Add($" [{iterator}] {deliveryOption} = {(int)deliveryOption} kr");
                iterator++;
            }

            var deliveryWindow = new Window("Leverans alternativ", 15, 10, deliveryInfo);
            deliveryWindow.Left = 45;
            deliveryWindow.Draw();

            bool process = true;
            MyEnums.DeliveryOption selectedDelivery = MyEnums.DeliveryOption.Postnord;
            while (process)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        selectedDelivery = MyEnums.DeliveryOption.Postnord;
                        process = false;
                        break;
                    case ConsoleKey.D2:
                        selectedDelivery = MyEnums.DeliveryOption.Dhl;
                        process = false;
                        break;
                    case ConsoleKey.D3:
                        selectedDelivery = MyEnums.DeliveryOption.Schenker;
                        process = false;
                        break;
                    case ConsoleKey.D4:
                        selectedDelivery = MyEnums.DeliveryOption.Bring;
                        process = false;
                        break;
                    case ConsoleKey.D5:
                        selectedDelivery = MyEnums.DeliveryOption.EarlyBird;
                        process = false;
                        break;
                }
            }

            Console.Clear();
            return selectedDelivery;
        }

        public MyEnums.PaymentOption PaymentMenu()
        {
            Console.Clear();

            List<string> paymentInfo = new();
            int iterator = 1;
            foreach (var paymentOption in Enum.GetValues(typeof(MyEnums.PaymentOption)))
            {
                paymentInfo.Add($" [{iterator}] {paymentOption}");
                iterator++;
            }


            var deliveryWindow = new Window("Betalnings alternativ", 15, 10, paymentInfo);
            deliveryWindow.Left = 45;
            deliveryWindow.Draw();


            bool process = true;
            MyEnums.PaymentOption selectedPayment = MyEnums.PaymentOption.Klarna;
            while (process)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        selectedPayment = MyEnums.PaymentOption.Klarna;
                        process = false;
                        break;
                    case ConsoleKey.D2:
                        selectedPayment = MyEnums.PaymentOption.Swish;
                        process = false;
                        break;
                    case ConsoleKey.D3:
                        selectedPayment = MyEnums.PaymentOption.Kreditkort;
                        process = false;
                        break;
                    case ConsoleKey.D4:
                        selectedPayment = MyEnums.PaymentOption.Faktura;
                        process = false;
                        break;
                }
            }


            Console.Clear();

            return selectedPayment;
            
        }

        public void CreateShoppingCartList()
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
                shoppingCartText.Add($" [{iterator}] " + product.Key.Name + " Antal " + product.Value.ToString() + " : " + (shoppingCartFilter[iterator - 1].Price * product.Value) + " kr");
                totalSum += (shoppingCartFilter[iterator - 1].Price * product.Value);
                iterator++;
            }

            TotalSum = totalSum;
            ShoppingCartText = shoppingCartText;
        }

        public void ShowSearchProduts()
        {
            List<string> searchedproduct = new List<string> { "                                                " };
            bool process = true;
            while (process)
            {

                var searchWindow = new Window("Sök produkter", 15, 10, searchedproduct);
                searchWindow.Left = 45;
                searchWindow.Draw();

                Console.SetCursorPosition(46, 11);
                try
                {
                    var search = Console.ReadLine()?.Substring(0, 3).ToLower();
                    using (var myDb = new MyDbContext())
                    {

                        Product? product = myDb.Products.FirstOrDefault(p => p.Name.ToLower().StartsWith(search));

                        if (product != null)
                        {
                            ShowProductInfo(product);
                        }
                        else
                        {
                            Console.SetCursorPosition(46, 11);
                            Console.WriteLine("0 träffar, åter till shopsida [X]");

                            ConsoleKeyInfo respons = Console.ReadKey(true);

                            if (respons.KeyChar == 'x')
                            {
                                process = false;
                                Console.Clear();
                                ShopPage();
                                break;
                            }
                            else
                            {
                                ShowSearchProduts();
                            }

                        }

                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    var searchWindow2 = new Window("Sök produkter", 15, 10, searchedproduct);
                    searchWindow2.Left = 45;
                    searchWindow2.Draw();
                    Console.SetCursorPosition(46, 11);
                    Console.WriteLine("Skriv in minst tre bokstäver");
                    Thread.Sleep(1000);
                    Console.Clear();
                    ShopPage();
                }

            }
        }

        // public void UpdateShoppingCart
    }
}
