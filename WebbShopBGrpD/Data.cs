using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopBGrpD.Models;

namespace WebbShopBGrpD
{
    internal class Data
    {
        public static void CreateSuppliers()
        {
            using (var myDb = new MyDbContext())
            {

                myDb.AddRange(new List<ProductSupplier>
                {
                    new ProductSupplier
                    {
                        Name = "Nike",
                        StreetAdress = "Malmvägen 15",
                        City = "Stockholm",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "Adidas",
                        StreetAdress = "Göteborgsvägen 20",
                        City = "Gothenburg",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "Puma",
                        StreetAdress = "Lundgatan 10",
                        City = "Lund",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "Reebok",
                        StreetAdress = "Malmövägen 5",
                        City = "Malmö",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "Under Armour",
                        StreetAdress = "Uppsala Street 8",
                        City = "Uppsala",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "New Balance",
                        StreetAdress = "Linköping Road 12",
                        City = "Linköping",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "Vans",
                        StreetAdress = "Eskilstuna Avenue 3",
                        City = "Eskilstuna",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "Converse",
                        StreetAdress = "Västerås Street 7",
                        City = "Västerås",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "Fila",
                        StreetAdress = "Helsingborg Road 9",
                        City = "Helsingborg",
                        Country = "Sverige"
                    },
                    new ProductSupplier
                    {
                        Name = "ASICS",
                        StreetAdress = "Norrköping Avenue 6",
                        City = "Norrköping",
                        Country = "Sverige"
                    }
                });

                myDb.SaveChanges();

            }
        }
        public static void CreateProducts()
        {

            using (var myDb = new MyDbContext())
            {
                List<ProductSupplier> currentSuppliers = new List<ProductSupplier>(myDb.ProductSuppliers);
                List<ProductCategory> currentCategories = new List<ProductCategory>(myDb.ProductCategories);//Har lagt till denna Mira
                myDb.AddRange(
                new Product
                {
                    Name = "Piké i bomull",
                    Price = 200,
                    Info = "Bomull 92% Polyester 8%",
                    Quantity = 25,
                    Sale = true,
                    FeaturedProduct = true,
                    Gender = 0,
                    Category = currentCategories[0],
                    Supplier = currentSuppliers[0]

                },
                new Product
                {
                    Name = "Florida stretch jeans, slim fit",
                    Price = 450,
                    Info = "72% Bomull, 20% Återvunnen bomull, 4% ELASTOMULTIESTER, 4% Elastan",
                    Quantity = 30,
                    Sale = true,
                    FeaturedProduct = true,
                    Gender = 0,
                    Category = currentCategories[1],
                    Supplier = currentSuppliers[0]

                },
                new Product
                {
                    Name = "Flip flop",
                    Price = 199,
                    Info = "100% Plast",
                    Quantity = 50,
                    Sale = true,
                    FeaturedProduct = true,
                    Gender = 2,
                    Category = currentCategories[2],
                    Supplier = currentSuppliers[0]

                },
                new Product
                {
                    Name = "Bomull Skjorta",
                    Price = 150,
                    Info = "100% bomull",
                    Quantity = 20,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 0,
                    Category = currentCategories[0],
                    Supplier = currentSuppliers[0]
                },
                new Product
                {
                    Name = "Denim Jeans",
                    Price = 250,
                    Info = "90% Bomull 10% Polyester",
                    Quantity = 15,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 1,
                    Category = currentCategories[1],
                    Supplier = currentSuppliers[1]
                },
                new Product
                {
                    Name = "Läderskor",
                    Price = 420,
                    Info = "100% Läder",
                    Quantity = 30,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 2,
                    Category = currentCategories[2],
                    Supplier = currentSuppliers[2]
                },
                new Product
                {
                    Name = "Linnebyxor",
                    Price = 180,
                    Info = "100% Bomull",
                    Quantity = 25,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 0,
                    Category = currentCategories[1],
                    Supplier = currentSuppliers[3]
                },
                new Product
                {
                    Name = "Stickad Tröja",
                    Price = 300,
                    Info = "100% Ull",
                    Quantity = 18,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 1,
                    Category = currentCategories[0],
                    Supplier = currentSuppliers[4]
                },
                new Product
                {
                    Name = "Sportskor",
                    Price = 180,
                    Info = "80% Skinnimitation 20% Läder",
                    Quantity = 20,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 2,
                    Category = currentCategories[2],
                    Supplier = currentSuppliers[5]
                },
                new Product
                {
                    Name = "Jeans Loose Fit",
                    Price = 220,
                    Info = "100% Bomull",
                    Quantity = 22,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 0,
                    Category = currentCategories[1],
                    Supplier = currentSuppliers[6]
                },
                new Product
                {
                    Name = "Luvtröja",
                    Price = 400,
                    Info = "100% Bomull",
                    Quantity = 15,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 1,
                    Category = currentCategories[0],
                    Supplier = currentSuppliers[7]
                },
                new Product
                {
                    Name = "Löparskor",
                    Price = 120,
                    Info = "80% Skinnimitation 20% Läder",
                    Quantity = 30,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 2,
                    Category = currentCategories[2],
                    Supplier = currentSuppliers[8]
                },
                new Product
                {
                    Name = "Kortärmad Skjorta",
                    Price = 160,
                    Info = "100% Bomull",
                    Quantity = 28,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 0,
                    Category = currentCategories[0],
                    Supplier = currentSuppliers[9]
                },
                new Product
                {
                    Name = "Klackskor",
                    Price = 250,
                    Info = "Läder",
                    Quantity = 20,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 1,
                    Category = currentCategories[2],
                    Supplier = currentSuppliers[9]
                },
                new Product
                {
                    Name = "Mamma jeans",
                    Price = 200,
                    Info = "100% Bomull",
                    Quantity = 22,
                    Sale = false,
                    FeaturedProduct = false,
                    Gender = 1,
                    Category = currentCategories[1],
                    Supplier = currentSuppliers[6]
                }
             );

                myDb.SaveChanges();
            }

        }

        public static void CreateCustomers()
        {
            using (var myDb = new MyDbContext())
            {
                myDb.AddRange(
                    new Customer
                    {
                        Name = "Martin Svensson",
                        Age = 25,
                        StreetAdress = "Tunavägen 22",
                        ZIPCode = 61122,
                        City = "Eskilstuna",
                        Country = "Sverige",
                        PhoneNumber = 0700523374,
                        MailAdress = "MartinSvensson@gmail.com",
                        Password = "password"
                    },
                    new Customer
                    {
                        Name = "Anna Andersson",
                        Age = 30,
                        StreetAdress = "Storgatan 15",
                        ZIPCode = 11234,
                        City = "Stockholm",
                        Country = "Sverige",
                        PhoneNumber = 0731122233,
                        MailAdress = "Anna.Andersson@email.com",
                        Password = "secure123"
                    },
                    new Customer
                    {
                        Name = "Erik Andersson",
                        Age = 28,
                        StreetAdress = "Björkgatan 8",
                        ZIPCode = 41155,
                        City = "Gothenburg",
                        Country = "Sverige",
                        PhoneNumber = 0765566778,
                        MailAdress = "Erik.Andersson@hotmail.com",
                        Password = "pass1234"
                    },
                    new Customer
                    {
                        Name = "Sofia Lindqvist",
                        Age = 22,
                        StreetAdress = "Sveavägen 10",
                        ZIPCode = 21145,
                        City = "Malmö",
                        Country = "Sverige",
                        PhoneNumber = 0709876543,
                        MailAdress = "Sofia.Lindqvist@email.com",
                        Password = "securePwd"
                    },
                    new Customer
                    {
                        Name = "David Berggren",
                        Age = 35,
                        StreetAdress = "Götgatan 33",
                        ZIPCode = 55123,
                        City = "Uppsala",
                        Country = "Sverige",
                        PhoneNumber = 0723344556,
                        MailAdress = "David.Berggren@gmail.com",
                        Password = "passWord456"
                    },
                    new Customer
                    {
                        Name = "Maria Karlsson",
                        Age = 27,
                        StreetAdress = "Drottninggatan 5",
                        ZIPCode = 33111,
                        City = "Linköping",
                        Country = "Sverige",
                        PhoneNumber = 0701122334,
                        MailAdress = "Maria.Karlsson@email.com",
                        Password = "mySecurePwd"
                    }
                );

                myDb.SaveChanges();
            }
        }
        public static void CreateCategories()
        {
            using (var myDb = new MyDbContext())
            {
                myDb.AddRange(
                    new ProductCategory
                    {
                        Name = "Tröjor"

                    },
                    new ProductCategory
                    {
                        Name = "Byxor"
                    },
                     new ProductCategory
                     {
                         Name = "Skor"
                     }
                );

                myDb.SaveChanges();
            }
        }
        public static void CreateOrders()
        {
            //public int PaymentOption { get; set; }
            //public int DeliveryOption { get; set; }
            //public int CustomerId { get; set; }

            using (var myDb = new MyDbContext())
            {
                myDb.AddRange(
                    new Order { PaymentOption = 1, DeliveryOption = 2, CustomerId = 1 },
                    new Order { PaymentOption = 2, DeliveryOption = 3, CustomerId = 2 },
                    new Order { PaymentOption = 3, DeliveryOption = 4, CustomerId = 3 },
                    new Order { PaymentOption = 4, DeliveryOption = 5, CustomerId = 4 },
                    new Order { PaymentOption = 1, DeliveryOption = 1, CustomerId = 5 },
                    new Order { PaymentOption = 2, DeliveryOption = 2, CustomerId = 6 },
                    new Order { PaymentOption = 3, DeliveryOption = 3, CustomerId = 1 },
                    new Order { PaymentOption = 4, DeliveryOption = 4, CustomerId = 2 },
                    new Order { PaymentOption = 1, DeliveryOption = 5, CustomerId = 3 },
                    new Order { PaymentOption = 2, DeliveryOption = 1, CustomerId = 4 },
                    new Order { PaymentOption = 3, DeliveryOption = 2, CustomerId = 5 },
                    new Order { PaymentOption = 4, DeliveryOption = 3, CustomerId = 6 },
                    new Order { PaymentOption = 1, DeliveryOption = 4, CustomerId = 1 },
                    new Order { PaymentOption = 2, DeliveryOption = 5, CustomerId = 2 },
                    new Order { PaymentOption = 3, DeliveryOption = 1, CustomerId = 3 },
                    new Order { PaymentOption = 4, DeliveryOption = 2, CustomerId = 4 },
                    new Order { PaymentOption = 1, DeliveryOption = 3, CustomerId = 5 },
                    new Order { PaymentOption = 2, DeliveryOption = 4, CustomerId = 6 },
                    new Order { PaymentOption = 3, DeliveryOption = 5, CustomerId = 1 },
                    new Order { PaymentOption = 4, DeliveryOption = 1, CustomerId = 2 },
                    new Order { PaymentOption = 1, DeliveryOption = 2, CustomerId = 3 },
                    new Order { PaymentOption = 2, DeliveryOption = 3, CustomerId = 4 },
                    new Order { PaymentOption = 3, DeliveryOption = 4, CustomerId = 5 },
                    new Order { PaymentOption = 4, DeliveryOption = 5, CustomerId = 6 },
                    new Order { PaymentOption = 2, DeliveryOption = 2, CustomerId = 1 },
                    new Order { PaymentOption = 3, DeliveryOption = 3, CustomerId = 3 }
                    );

                myDb.SaveChanges();
            }
         }
        public static void CreatePurchasedArticles()
        {
            using (var myDb = new MyDbContext())
            {
                myDb.AddRange(
                    new PurchasedArticles { Quantity = 1, ProductId = 14, OrderId = 1 },
                    new PurchasedArticles { Quantity = 3, ProductId = 2, OrderId = 1 },
                    new PurchasedArticles { Quantity = 2, ProductId = 4, OrderId = 1 },

                    new PurchasedArticles { Quantity = 3, ProductId = 5, OrderId = 2 },
                    new PurchasedArticles { Quantity = 2, ProductId = 8, OrderId = 2 },
                    new PurchasedArticles { Quantity = 4, ProductId = 12, OrderId = 2 },

                    new PurchasedArticles { Quantity = 5, ProductId = 3, OrderId = 3 },
                    new PurchasedArticles { Quantity = 1, ProductId = 11, OrderId = 3 },
                    new PurchasedArticles { Quantity = 3, ProductId = 6, OrderId = 3 },

                    new PurchasedArticles { Quantity = 2, ProductId = 9, OrderId = 4 },
                    new PurchasedArticles { Quantity = 4, ProductId = 14, OrderId = 4 },
                    new PurchasedArticles { Quantity = 5, ProductId = 2, OrderId = 4 },

                    new PurchasedArticles { Quantity = 1, ProductId = 7, OrderId = 5 },
                    new PurchasedArticles { Quantity = 3, ProductId = 10, OrderId = 5 },
                    new PurchasedArticles { Quantity = 2, ProductId = 13, OrderId = 5 },

                    new PurchasedArticles { Quantity = 4, ProductId = 4, OrderId = 6 },
                    new PurchasedArticles { Quantity = 5, ProductId = 1, OrderId = 6 },
                    new PurchasedArticles { Quantity = 1, ProductId = 15, OrderId = 6 },

                    new PurchasedArticles { Quantity = 3, ProductId = 7, OrderId = 7 },
                    new PurchasedArticles { Quantity = 2, ProductId = 11, OrderId = 7 },
                    new PurchasedArticles { Quantity = 4, ProductId = 3, OrderId = 7 },

                    new PurchasedArticles { Quantity = 5, ProductId = 8, OrderId = 8 },
                    new PurchasedArticles { Quantity = 1, ProductId = 14, OrderId = 8 },
                    new PurchasedArticles { Quantity = 3, ProductId = 5, OrderId = 8 },

                    new PurchasedArticles { Quantity = 2, ProductId = 9, OrderId = 9 },
                    new PurchasedArticles { Quantity = 4, ProductId = 13, OrderId = 9 },
                    new PurchasedArticles { Quantity = 5, ProductId = 2, OrderId = 9 },

                    new PurchasedArticles { Quantity = 1, ProductId = 6, OrderId = 10 },
                    new PurchasedArticles { Quantity = 3, ProductId = 10, OrderId = 10 },
                    new PurchasedArticles { Quantity = 2, ProductId = 15, OrderId = 10 },

                    new PurchasedArticles { Quantity = 4, ProductId = 4, OrderId = 11 },
                    new PurchasedArticles { Quantity = 5, ProductId = 1, OrderId = 11 },
                    new PurchasedArticles { Quantity = 1, ProductId = 14, OrderId = 11 },

                    new PurchasedArticles { Quantity = 3, ProductId = 5, OrderId = 12 },
                    new PurchasedArticles { Quantity = 2, ProductId = 8, OrderId = 12 },

                    new PurchasedArticles { Quantity = 4, ProductId = 12, OrderId = 13 },
                    new PurchasedArticles { Quantity = 5, ProductId = 3, OrderId = 13 },

                    new PurchasedArticles { Quantity = 1, ProductId = 11, OrderId = 14 },
                    new PurchasedArticles { Quantity = 3, ProductId = 6, OrderId = 14 },

                    new PurchasedArticles { Quantity = 2, ProductId = 9, OrderId = 15 },
                    new PurchasedArticles { Quantity = 4, ProductId = 14, OrderId = 15 },

                    new PurchasedArticles { Quantity = 5, ProductId = 2, OrderId = 16 },
                    new PurchasedArticles { Quantity = 1, ProductId = 7, OrderId = 16 },

                    new PurchasedArticles { Quantity = 3, ProductId = 10, OrderId = 17 },
                    new PurchasedArticles { Quantity = 2, ProductId = 13, OrderId = 17 },

                    new PurchasedArticles { Quantity = 4, ProductId = 4, OrderId = 18 },
                    new PurchasedArticles { Quantity = 5, ProductId = 1, OrderId = 18 },

                    new PurchasedArticles { Quantity = 1, ProductId = 15, OrderId = 19 },
                    new PurchasedArticles { Quantity = 3, ProductId = 7, OrderId = 19 },

                    new PurchasedArticles { Quantity = 2, ProductId = 11, OrderId = 20 },
                    new PurchasedArticles { Quantity = 4, ProductId = 3, OrderId = 20 },

                    new PurchasedArticles { Quantity = 5, ProductId = 8, OrderId = 21 },
                    new PurchasedArticles { Quantity = 1, ProductId = 14, OrderId = 21 },

                    new PurchasedArticles { Quantity = 3, ProductId = 5, OrderId = 22 },
                    new PurchasedArticles { Quantity = 2, ProductId = 9, OrderId = 22 },

                    new PurchasedArticles { Quantity = 4, ProductId = 13, OrderId = 23 },
                    new PurchasedArticles { Quantity = 5, ProductId = 2, OrderId = 23 },

                    new PurchasedArticles { Quantity = 1, ProductId = 6, OrderId = 24 },
                    new PurchasedArticles { Quantity = 3, ProductId = 10, OrderId = 24 },

                    new PurchasedArticles { Quantity = 2, ProductId = 15, OrderId = 25 },
                    new PurchasedArticles { Quantity = 4, ProductId = 4, OrderId = 25 },

                    new PurchasedArticles { Quantity = 5, ProductId = 1, OrderId = 26 }
                    );
                myDb.SaveChanges();
            }
        }
        public static void CreateData()
        {
            CreateSuppliers();
            CreateCategories();
            CreateProducts();
            CreateCustomers();
            CreateOrders();
            CreatePurchasedArticles();

        }
    }
}
