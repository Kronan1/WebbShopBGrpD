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
        public void CreateSuppliers()
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
        public void CreateProducts()
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
                }
             );

                myDb.SaveChanges();
            }

        }

        public void CreateCustomers()
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
                    }
                );

                myDb.SaveChanges();
            }
        }
        public void CreateCategories()
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

        public void CreateData()
        {
            CreateSuppliers();
            CreateCategories();
            CreateProducts();
            CreateCustomers();
            
        }
    }
}
