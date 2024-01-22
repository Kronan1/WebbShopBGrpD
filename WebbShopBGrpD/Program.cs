using Azure;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WebbShopBGrpD.Models;
using WebbShopBGrpD.Queries;
using WindowDemo;

namespace WebbShopBGrpD
{

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sv-SE");

            // Kör en gång för att skapa data
            // Data.CreateData();
            // Console.ReadLine();


            string connectionstring = "server=.\\sqlexpress;database=webbshopb;trusted_connection=true;trustservercertificate=true;";


            // Most expensive product
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Dyraste produkten/produkterna
                var sql1 = "SELECT * FROM Products WHERE Price = (SELECT TOP 1 Price FROM Products ORDER BY Price DESC)";
                var result1 = connection.QuerySingleOrDefault<Product>(sql1);

                // Hur många som sålts av varje produkt
                var sql2 = "SELECT ProductId, " +
                    "SUM (Quantity) AS 'TotalQuantitySold'" +
                    " FROM PurchasedArticles " +
                    "group by ProductId " +
                    "ORDER by TotalQuantitySold DESC";
                var result2 = connection.Query<ProductsSold>(sql2);

                // Genomsnittlig ålder på kunder
                var sql3 = "SELECT AVG(Age * 1.0) FROM Customers";
                var result3 = connection.QueryFirstOrDefault<double>(sql3);

                // Tar fram alla produkter som innehåller bomull
                var sql4 = "SELECT * FROM Products WHERE Info LIKE '%Bomull%' OR Info LIKE '%bomull%'";
                var result4 = connection.Query<Product>(sql4);

                int test = 0;
            }


            Menu menu = new Menu();

            menu.StartPage();
            // Fixa admin
            // Fixa Beställningar
        }
    }
}
