using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebbShopBGrpD.Models;
using WindowDemo;
using static WebbShopBGrpD.MyEnums;

namespace WebbShopBGrpD
{
    internal class Admin
    {
        List<Product> allProducts;
        List<Order> allOrders;
        List<ProductCategory> categoryList;
        public void AdminPage()
        {

            using (var myDb = new MyDbContext())
            {
                allProducts = myDb.Products.ToList();
                allOrders = myDb.Orders.ToList();
            }

            Menu menu = new Menu();

            List<string> adminPageList = new List<string>()
            {
                "Vänligen ange val gällande administration.",
                " [1] Produkter",
                " [2] Kunder",
                " [X] för att backa"
            };

            var adminPageWindow = new Window("Administratörsida", 2, 5, adminPageList);
            adminPageWindow.Left = 45;
            adminPageWindow.Draw();

            string goTo = "";
            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    goTo = "Produkter";
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    goTo = "Kunder";
                    break;
                case ConsoleKey.X:
                    Console.Clear();
                    goTo = "StartPage";
                    break;
            }

            switch (goTo)
            {
                case "Produkter":
                    ProductAdmin();
                    break;
                case "Kunder":
                    CustomerAdmin();
                    break;

                case "StartPage":
                    menu.StartPage();
                    break;
            }

            Console.Clear();
            AdminPage();
        }


        public void CustomerAdmin()
        {
           
            List<Customer> customerList = new();
            List<string> customersData = new();
           

            using (var myDb = new MyDbContext())
            {
                customerList = myDb.Customers.ToList();
            }

            foreach (Customer targetCustomer in customerList)
            {
                customersData.Add("[Kundnummer " + targetCustomer.Id.ToString() + "] Namn: " + targetCustomer.Name);
                customersData.Add("");
            }

            customersData.Add(" [K] för att se kundinformation");
            customersData.Add(" [O] för att ändra kundinformation");
            customersData.Add(" [H] för att se kundens beställningar");
            customersData.Add(" [X] för att backa");

            Console.Clear();
            var customerWindow = new Window("Kunder", 2, 5, customersData);
            customerWindow.Left = 45;
            customerWindow.Draw();

            int selector = 0;

            while (true)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);
                switch (input.Key)
                {

                    case ConsoleKey.K:
                        Console.Clear();
                        SelectCustomer(customerList, selector);
                        break;
                    case ConsoleKey.H:
                        Console.Clear();
                        List<PurchasedArticles> customerHistory = GetHistory(selector + 1);
                        List<string> messageBox = GetOrderList(customerHistory);
                        var receiptWindow = new Window("Kundens beställningar", 2, 5, messageBox);
                        receiptWindow.Left = 45;
                        receiptWindow.Draw();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        selector--;
                        if (selector < 0)
                        {
                            selector = customerList.Count - 1;
                        }
                        SelectCustomer(customerList, selector);
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        selector++;
                        if (selector > customerList.Count - 1)
                        {
                            selector = 0;
                        }
                        SelectCustomer(customerList, selector);
                        break;
                    case ConsoleKey.O:
                        Console.Clear();
                        Customer editedCustomer = EditCustomer(customerList, selector); //Ändra i databas
                        break;
                    case ConsoleKey.X:
                        return;

                }

            }

        }

        public void SelectCustomer(List<Customer> customerList, int selector)
        {
            List<string> currentCustomer = new List<string>();
            currentCustomer.Add("Kundnummer: " + customerList[selector].Id.ToString());
            currentCustomer.Add("Namn: " + customerList[selector].Name);
            currentCustomer.Add("Adress: " + customerList[selector].StreetAdress);
            currentCustomer.Add("Postnummer: " + customerList[selector].ZIPCode.ToString());
            currentCustomer.Add("Stad: " + customerList[selector].City);
            currentCustomer.Add("Ålder: " + customerList[selector].Age.ToString());
            currentCustomer.Add("Land: " + customerList[selector].Country);
            currentCustomer.Add("Telefonnummer: " + customerList[selector].PhoneNumber.ToString());
            currentCustomer.Add("Mailadress: " + customerList[selector].MailAdress);
            currentCustomer.Add("Lösenord: " + customerList[selector].Password);
            int orderCount = GetOrders(customerList[selector].Id).Count;
            currentCustomer.Add("Antalet ordrar: " + orderCount);
            currentCustomer.Add("");
            currentCustomer.Add(" [O] för att ändra uppgifter för denna kund");
            currentCustomer.Add(" [A] för att gå till föregående kund");
            currentCustomer.Add(" [D] för att gå till nästa kund");
            currentCustomer.Add(" [X] för att backa");

            var customerViewWindow = new Window("Vald kund", 2, 5, currentCustomer);
            customerViewWindow.Left = 45;
            customerViewWindow.Draw();

        }

        public Customer EditCustomer(List<Customer> customerList, int selector)
        {
            List<string> message = new List<string>()
            {
                "Du ändrar för närvarande information för kunden " + customerList[selector].Name + " med kundnummer: " + customerList[selector].Id.ToString(),
                "Lämna blankt för ingen ändring"
            };

            Customer customer = customerList[selector];

            var customerEditWindow = new Window("Ändring av kunddata", 2, 5, message);
            customerEditWindow.Left = 15;
            customerEditWindow.Draw();

            try
            {
                string input = "";
                int intInput;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Vänligen ange nytt namn för kunden.");
                if (InputCheckString(out input))
                {
                    customer.Name = input;
                }
                Console.WriteLine("Vänligen ange ny adress för kunden.");
                if (InputCheckString(out input))
                {
                    customer.StreetAdress = input;
                }
                Console.WriteLine("Vänligen ange ett nytt postnummer för kunden.");
                if (InputCheckInt(out intInput))
                {
                    customer.ZIPCode = intInput;
                }
                Console.WriteLine("Vänligen ange ett nytt stadsnamn för kunden.");
                if (InputCheckString(out input))
                {
                    customer.City = input;
                }
                Console.WriteLine("Vänligen ange ny ålder för kunden.");
                if (InputCheckInt(out intInput))
                {
                    customer.Age = intInput;
                }
                Console.WriteLine("Vänligen ange ett nytt land för kunden.");
                if (InputCheckString(out input))
                {
                    customer.Country = input;
                }
                Console.WriteLine("Vänligen ange ett nytt telefonnummer för kunden.");
                if (InputCheckInt(out intInput))
                {
                    customer.PhoneNumber = intInput;
                }
                Console.WriteLine("Vänligen ange en ny mail-adress för kunden.");
                if (InputCheckString(out input))
                {
                    customer.MailAdress = input;
                }
                Console.WriteLine("Vänligen ange ett nytt lösenord för kunden.");
                if (InputCheckString(out input))
                {
                    customer.Password = input;
                }

                return customer;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Ett fel har uppstått, vänligen försök igen.");
                Thread.Sleep(2000);
                Console.Clear();
                return EditCustomer(customerList, selector);
            }
        }

        public void ProductAdmin()
        {
            Console.Clear();
            List<string> messageBox = new List<string>
                    {
                        "Vänligen välj bland en av kategorierna:",
                        " [C] för att bläddra bland kategorierna",
                        " [P] för att lägga till en ny produkt",
                        " [K] för att lägga till en ny produktkategori",
                        " [X] för att backa"
                    };
            var customerWindow = new Window("Kunder", 2, 5, messageBox);
            customerWindow.Left = 45;
            customerWindow.Draw();

            ConsoleKeyInfo input;
            input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.C:
                    int cinput = 0;
                    List<string> categoryMessage = new List<string>();
                    Console.Clear();
                    using (MyDbContext myDb = new MyDbContext())
                    {
                        int iterator = 1;
                        foreach (var item in myDb.ProductCategories)
                        {
                            categoryMessage.Add($" [{iterator}] " + item.Name);
                            iterator++;
                        }
                    }
                    var categoryWindow = new Window("Val av kategori", 2, 5, categoryMessage);
                    categoryWindow.Left = 35;
                    categoryWindow.Draw();

                    List<string> messageText = new List<string>()
                    {
                        "Vänligen ange vilken kategori du önskar att visa genom att ange en siffra."
                    };

                    var messageWindow = new Window("Val av kategori", 2, 0, messageText);
                    messageWindow.Left = 35;
                    messageWindow.Draw();
                    Console.SetCursorPosition(35, 20);
                    cinput = CInputCheckInt(out cinput);
                    ProductCategory(cinput);
                    break;
                case ConsoleKey.P:
                    Product newProduct = AddNewProduct();
                    using (var myDb = new MyDbContext())
                    {
                        myDb.Add(newProduct);
                        myDb.SaveChanges();
                    }
                    break;
                case ConsoleKey.K:
                    Console.Clear();
                    string sinput = "";
                    List<string> message = new List<string>()
                    {
                        "Vänligen ange namnet för produktkategorin du önskar att lägga till.",
                    };
                    var customerEditWindow = new Window("Tillägg av produktkategori", 2, 5, message);
                    customerEditWindow.Left = 25;
                    customerEditWindow.Draw();

                    Console.SetCursorPosition(0, 10);
                    ProductCategory newCategory = new ProductCategory();

                    CInputCheck(out sinput);
                    newCategory.Name = sinput;

                    using (var myDb = new MyDbContext())
                    {
                        myDb.ProductCategories.Add(newCategory);
                        myDb.SaveChanges();
                    }
                    break;
                case ConsoleKey.X:
                    return;
            }
        }

        public void ProductCategory(int category)
        {
            List<string> message = new();
            List<Product> productsList = new();
            List<string> productData = new();
            List<string> currentProduct = new();
            List<ProductSupplier> supplierList = new();



            using (var myDb = new MyDbContext())
            {
                productsList = myDb.Products.Where(x => x.Category.Id == category).ToList();
                categoryList = myDb.ProductCategories.ToList();
                supplierList = myDb.ProductSuppliers.ToList();

            }


            List<Product> categorizedProducts = new();

            foreach (Product product in productsList)
            {
                foreach (ProductCategory category1 in categoryList)
                {
                    if (category1.Id == category)
                    {
                        categorizedProducts.Add(product);
                    }
                }

            }


            foreach (Product targetProduct in categorizedProducts)
            {
                productData.Add("[Produktnummer " + targetProduct.Id.ToString() + "] Produktnamn: " + targetProduct.Name);
                productData.Add("");
            }

            productData.Add(" [K] för att se produktinformation");
            productData.Add(" [O] för att ändra produktinformation");
            productData.Add(" [X] för att backa");


            Console.Clear();
            var customerWindow = new Window(((categoryList[category - 1].Name)).ToString(), 2, 5, productData);
            customerWindow.Left = 45;
            customerWindow.Draw();

            int selector = 0;

            while (true)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);
                switch (input.Key)
                {

                    case ConsoleKey.K:
                        Console.Clear();
                        SelectProduct(categorizedProducts, selector);
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        selector--;
                        if (selector < 0)
                        {
                            selector = categorizedProducts.Count - 1;
                        }
                        SelectProduct(categorizedProducts, selector);

                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        selector++;
                        if (selector > categorizedProducts.Count - 1)
                        {
                            selector = 0;
                        }
                        SelectProduct(categorizedProducts, selector);
                        break;
                    case ConsoleKey.O:
                        Console.Clear();
                        Product editedProduct = EditProduct(categorizedProducts, selector);
                        break;

                    case ConsoleKey.X:
                        return;

                }

            }
        }

        public void SelectProduct(List<Product> productList, int selector)
        {
            List<string> currentCustomer = new List<string>();
            currentCustomer.Add("Produktnummer: " + productList[selector].Id.ToString());
            currentCustomer.Add("Produktnamn: " + productList[selector].Name);
            currentCustomer.Add("Pris: " + productList[selector].Price.ToString());
            currentCustomer.Add("Info: " + productList[selector].Info);
            currentCustomer.Add("Saldo: " + productList[selector].Quantity.ToString());
            currentCustomer.Add("Kategori: " + productList[selector].Category.Name.ToString());
            currentCustomer.Add("Supplier: " + productList[selector].Supplier.Name.ToString());


            if (productList[selector].Sale)
            {
                currentCustomer.Add("Rea: Ja");
            }
            else
            {
                currentCustomer.Add("Rea: Nej");
            }
            if (productList[selector].FeaturedProduct)
            {
                currentCustomer.Add("Utvald: Ja");
            }
            else
            {
                currentCustomer.Add("Utvald: Nej");
            }

            currentCustomer.Add("Kön: " + Enum.GetName(typeof(MyEnums.Gender), productList[selector].Gender));
            currentCustomer.Add(" [O] för att ändra uppgifter för denna produkt");
            currentCustomer.Add(" [A] för att gå till föregående produkt");
            currentCustomer.Add(" [D] för att gå till nästa produkt");
            currentCustomer.Add(" [X] för att backa");

            var customerViewWindow = new Window("Vald produkt", 2, 5, currentCustomer);
            customerViewWindow.Left = 45;
            customerViewWindow.Draw();

        }

        public Product EditProduct(List<Product> productList, int selector)
        {
            List<string> message = new List<string>()
            {
                "Du ändrar för närvarande information för produkten " + productList[selector].Name + " med produktnummer: " + productList[selector].Id.ToString(),
                "Lämna blankt för ingen ändring."
            };

            Product product = productList[selector];

            var customerEditWindow = new Window("Ändring av produktdata", 2, 5, message);
            customerEditWindow.Left = 15;
            customerEditWindow.Draw();

            try
            {
                string input = "";
                int intInput;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Vänligen ange ett nytt namn för produkten.");
                if (InputCheckString(out input))
                {
                    product.Name = input;
                }
                Console.WriteLine("Vänligen ange ett nytt pris för produkten.");
                if (InputCheckInt(out intInput))
                {
                    product.Price = intInput;
                }
                Console.WriteLine("vänligen ange ny information om produkten.");
                if (InputCheckString(out input))
                {
                    product.Info = input;
                }
                Console.WriteLine("Vänligen ange nytt saldo för produkten.");
                if (InputCheckInt(out intInput))
                {
                    product.Quantity = intInput;
                }
                Console.WriteLine("Vänligen ange om produkten är på rea, '1' för ja, '0' för nej.");
                if (InputCheckInt(out intInput))
                {
                    if (intInput == 1)
                    {
                        product.Sale = true;
                    }
                    else if (intInput == 0)
                    {
                        product.Sale = false;
                    }
                }
                Console.WriteLine("Vänligen ange om produkten är på en utvald produkt, '1' för ja, '0' för nej.");
                if (InputCheckInt(out intInput))
                {
                    if (intInput == 1)
                    {
                        product.FeaturedProduct = true;
                    }
                    else if (intInput == 0)
                    {
                        product.FeaturedProduct = false;
                    }
                }

                Console.WriteLine("Vänligen ange passande kön för produkten, '0' för man, '1' för kvinna, och '2' för unisex.");
                if (InputCheckInt(out intInput))
                {
                    switch (intInput)
                    {
                        case 0:
                            product.Gender = 0;
                            break;
                        case 1:
                            product.Gender = 1;
                            break;
                        case 2:
                            product.Gender = 2;
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine("Vänligen ange leverantören för produkten.");
                if (InputCheckInt(out intInput))
                {
                    if (intInput < 11)
                    {
                        product.Supplier.Id = intInput;
                    }
                }

                return product;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Ett fel har uppstått, vänligen försök igen.");
                Thread.Sleep(2000);
                Console.Clear();
                return EditProduct(productList, selector);
            }
        }

        public Product AddNewProduct()
        {
            Product product = new Product();

            List<string> editPageList = new List<string>()
            {
                "Vänligen ange kundinformation för produkten du önskar att lägga till."
            };

            var addNewCustomerWindow = new Window("Lägg till en ny kund", 2, 5, editPageList);
            addNewCustomerWindow.Left = 25;
            addNewCustomerWindow.Draw();

            Console.SetCursorPosition(25, 10);
            try
            {
                string input = "";
                int intInput;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Vänligen ange ett namn för produkten.");
                product.Name = CInputCheck(out input);
                Console.WriteLine("Vänligen ange ett pris för produkten.");
                product.Price = CInputCheckInt(out intInput);
                Console.WriteLine("vänligen ange information om produkten.");
                product.Info = CInputCheck(out input);
                Console.WriteLine("Vänligen ange saldo för produkten.");
                product.Quantity = CInputCheckInt(out intInput);
                Console.WriteLine("Vänligen ange om produkten är på rea, '1' för ja, '0' för nej.");
                bool condition = false;
                while (!condition)
                {
                    int checker = CInputCheckInt(out intInput);
                    if (checker < 2 && checker >= 0)
                    {
                        if (intInput == 1)
                        {
                            product.Sale = true;
                        }
                        else
                        {
                            product.Sale = false;
                        }

                        condition = true;
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange endast 1 eller 0, '1' för ja, '0' för nej.");
                    }
                }

                Console.WriteLine("Vänligen ange om produkten är på en utvald produkt, '1' för ja, '0' för nej.");
                condition = false;
                while (!condition)
                {
                    int checker = CInputCheckInt(out intInput);
                    if (checker < 2 && checker >= 0)
                    {
                        if (intInput == 1)
                        {
                            product.FeaturedProduct = true;
                        }
                        else
                        {
                            product.FeaturedProduct = false;
                        }

                        condition = true;
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange endast 1 eller 0, '1' för ja, '0' för nej.");
                    }
                }


                Console.WriteLine("Vänligen ange passande kön för produkten, '0' för man, '1' för kvinna, och '2' för unisex.");
                condition = false;
                int checker2 = CInputCheckInt(out intInput);
                while (!condition)
                {
                    if (checker2 < 3 && checker2 >= 0)
                    {
                        switch (intInput)
                        {
                            case 0:
                                product.Gender = 0;
                                break;
                            case 1:
                                product.Gender = 1;
                                break;
                            case 2:
                                product.Gender = 2;
                                break;
                        }
                        condition = true;
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange endast 0, 1, eller 2, '0' för man, '1' för kvinna, och '2' för unisex.");
                    }
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Ett fel har uppstått, vänligen försök igen.");
                Thread.Sleep(2000);
                Console.Clear();
            
            }

            return product;
        }

        // Returnerar en lista med alla kundens artiklar
        public static List<PurchasedArticles> GetHistory(int customerId)
        {
            List<PurchasedArticles> history;
            List<PurchasedArticles> filteredHistory = new();
            List<Order> orders;
            List<Order> filteredOrderList = new();
            using (var MyDb = new MyDbContext())
            {
                history = MyDb.PurchasedArticles.ToList();
                orders = MyDb.Orders.ToList();
            }
            foreach (var order in orders)
            {
                if (order.CustomerId == customerId)
                {
                    filteredOrderList.Add(order);
                }
            }

            foreach (var order in filteredOrderList)
            {
                foreach (var post in history)
                {
                    if (post.OrderId == order.Id)
                    {
                        filteredHistory.Add(post);
                    }
                }
            }

            return filteredHistory;
        }

        // Returnerar en lista med alla kundens ordrar
        public static List<Order> GetOrders(int customerId)
        {
            List<Order> orders;
            List<Order> filteredOrders = new();
            using (var MyDb = new MyDbContext())
            {
                orders = MyDb.Orders.ToList();
            }

            foreach (var order in orders)
            {
                if (order.CustomerId == customerId)
                {
                    filteredOrders.Add(order);
                }
            }

            return filteredOrders;
        }

        public List<string> GetOrderList(List<PurchasedArticles> history)
        {
            string productName = "";
            int orderNumber = 0;
            int orderSum = 0;
            var deliveryOption = Enum.GetValues(typeof(MyEnums.DeliveryOption)).Cast<MyEnums.DeliveryOption>().ToArray();
            List<int> deliveryPrices = new();
            foreach (var item in Enum.GetValues(typeof(MyEnums.DeliveryOption)))
            {
                deliveryPrices.Add((int) item);
            }
            var paymentOptions = Enum.GetValues(typeof(MyEnums.PaymentOption)).Cast<MyEnums.PaymentOption>().ToArray();
            List<string> messageList = new List<string>();

            for (int i = 0; i < history.Count; i++)
            { 
                if (!(orderNumber == history[i].OrderId))
                {
                    if (!(orderSum == 0))
                    {
                        messageList.Add("Leveransalterantiv: " + deliveryOption[allOrders[orderNumber].DeliveryOption]);
                        messageList.Add("Betalningssätt: " + paymentOptions[allOrders[orderNumber].PaymentOption]);
                        orderSum += deliveryPrices[allOrders[orderNumber].PaymentOption];
                        messageList.Add("Summa: " + orderSum * 1.25 + " kr");
                        messageList.Add("");
                    }
                    orderNumber = history[i].OrderId;
                    orderSum = 0;
                    messageList.Add("Ordernummer: " + orderNumber);
                }
                foreach (var item in allProducts)
                {
                    if (history[i].ProductId == item.Id)
                    {
                        productName = item.Name;
                        orderSum += (int)(item.Price * history[i].Quantity);
                    }
                }
                messageList.Add("Produktnamn : " + productName + " x" + history[i].Quantity.ToString());
                
            }

            return messageList;
        }

        public bool InputCheckString(out string input)
        {
            try
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Felaktig inmatning, vänligen försök igen.");
                Thread.Sleep(2000);
                input = "";
                return InputCheckString(out input);
            }
        }

        public bool InputCheckInt(out int input)
        {
            try
            {

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch
            {
                Console.WriteLine("Felaktig inmatning, vänligen försök igen.");
                Thread.Sleep(2000);
                return InputCheckInt(out input);
            }

        }

        public string CInputCheck(out string input)
        {
            try
            {
                input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Felaktigt värde");
                    input = Console.ReadLine();
                }
                return input;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fel har uppstått, vänligen försök igen.");
                return CInputCheck(out input);
            }
        }

        public int CInputCheckInt(out int input)
        {
            try
            {
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Felaktig inmatning, vänligen ange endast siffror.");
                    Thread.Sleep(2000);
                }
                return input;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fel har uppstått, vänligen försök igen.");
                return CInputCheckInt(out input);
            }
        }

    }
}

