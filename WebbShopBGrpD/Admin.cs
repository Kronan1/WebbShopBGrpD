using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopBGrpD.Models;
using WindowDemo;

namespace WebbShopBGrpD
{
    internal class Admin
    {
        public void AdminPage()
        {

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
                    break;
                case "Kunder":
                    List<string> message = new();
                    List<Customer> customerList = new();
                    List<string> customersData = new();
                    List<string> currentCustomer = new();

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
                    customersData.Add(" [P] för att lägga till en ny kund]");
                    customersData.Add(" [X] för att backa");

                    Console.Clear();
                    var customerWindow = new Window("Kunder", 2, 5, customersData);
                    customerWindow.Left = 45;
                    customerWindow.Draw();



                    int selector = 0;

                    while (true)
                    {
                        input = Console.ReadKey(true);
                        switch (input.Key)
                        {
                            case ConsoleKey.P:
                                Console.Clear();
                                AddNewCustomer();
                                break;
                            case ConsoleKey.K:
                                Console.Clear();
                                selectCustomer(customerList, selector);
                                break;
                            case ConsoleKey.A:
                                Console.Clear();
                                selector--;
                                if (selector < 0)
                                {
                                    selector = customerList.Count - 1;
                                }
                                selectCustomer(customerList, selector);

                                break;
                            case ConsoleKey.D:
                                Console.Clear();
                                selector++;
                                if (selector > customerList.Count - 1)
                                {
                                    selector = 0;
                                }
                                selectCustomer(customerList, selector);
                                break;
                            case ConsoleKey.O:
                                Console.Clear();
                                EditCustomer(customerList, selector);
                                break;

                            case ConsoleKey.X:
                                return;
                        }

                    }

                case "StartPage":
                    Menu menu = new Menu();
                    menu.StartPage();
                    break;
            }
        }

        public void selectCustomer(List<Customer> customerList, int selector)
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
            currentCustomer.Add("Antalet ordrar: " + customerList[selector].Orders.Count().ToString());
            currentCustomer.Add("");
            currentCustomer.Add(" [A] för att gå till föregående kund");
            currentCustomer.Add(" [D] för att gå till nästa kund");

            var customerViewWindow = new Window("Vald kund", 2, 5, currentCustomer);
            customerViewWindow.Left = 45;
            customerViewWindow.Draw();

        }

        public void EditCustomer(List<Customer> customerList, int selector)
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
                string input;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Vänligen ange nytt namn för kunden");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Vänligen ange ny adress för kunden");
                customer.StreetAdress = Console.ReadLine();
                Console.WriteLine("Vänligen ange ett nytt postnummer för kunden");
                customer.ZIPCode = int.Parse(Console.ReadLine());
                Console.WriteLine("Vänligen ange ett nytt stadsnamn för kunden");
                customer.City = Console.ReadLine();
                Console.WriteLine("Vänligen ange ny ålder för kunden");
                customer.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Vänligen ange ett nytt land för kunden");
                customer.Country = Console.ReadLine();
                Console.WriteLine("Vänligen ange ett nytt telefonnummer för kunden");
                customer.PhoneNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Vänligen ange en ny mail-adress för kunden");
                customer.MailAdress = Console.ReadLine();
                Console.WriteLine("Vänligen ange ett nytt lösenord för kunden");
                customer.Password = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Felaktig inmatning, försök igen");
                Thread.Sleep(1000);
                Console.Clear();
                EditCustomer(customerList, selector);
            }
        }

        public void AddNewCustomer()
        {
            List<string> editPageList = new List<string>()
            {
                "Vänligen ange kundinformation för kunden du önskar att lägga till."
            };

            var addNewCustomerWindow = new Window("Lägg till en ny kund", 2, 5, editPageList);
            addNewCustomerWindow.Left = 25;
            addNewCustomerWindow.Draw();

            Console.SetCursorPosition(25, 10);
            Console.WriteLine("Vänligen ange uppgifter för kunden.");

            //Kod för skapande av ny kund

        }
    }
}
