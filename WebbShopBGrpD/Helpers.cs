using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopBGrpD.Models;
using WebbShopBGrpD.Queries;

namespace WebbShopBGrpD
{
    internal class Helpers
    {

        public static void GetQueries()
        {
            string connectionstring = "server=.\\sqlexpress;database=webbshopb;trusted_connection=true;trustservercertificate=true;";



            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Dyraste produkten/produkterna
                var sql1 = "SELECT * FROM Products WHERE Price = (SELECT TOP 1 Price FROM Products ORDER BY Price DESC)";
                var result1 = connection.Query<Product>(sql1);
                foreach (var product in result1)
                {
                    Console.WriteLine("Dyraste produkten eller produkterna är: " + product.Name + ": " + product.Price + "kr.");
                }
                Console.WriteLine("------------------------------------------------------------------------");


                // Hur många som sålts av varje produkt
                var sql2 = @"SELECT P.Id AS ProductId,
                P.Name AS ProductName,
                COALESCE(SUM(PA.Quantity), 0) AS TotalQuantitySold
                FROM Products P
                LEFT JOIN
                PurchasedArticles PA ON P.Id = PA.ProductId
                GROUP BY
                P.Id, P.Name
                ORDER BY TotalQuantitySold DESC";
                var result2 = connection.Query<ProductsSold>(sql2);
                Console.WriteLine("Försäljningssiffror av alla sålda produkter: ");
                foreach (var product in result2)
                {
                    Console.WriteLine(product.ProductName + " " + ": " + product.TotalQuantitySold);
                }
                Console.WriteLine("--------------------------------------------------------------------------");


                // Genomsnittlig ålder på kunder
                var sql3 = "SELECT AVG(Age * 1.0) FROM Customers";
                var result3 = connection.QueryFirstOrDefault<double>(sql3);
                Console.WriteLine("Genomsnittliga ålder på kund som handlar hos oss är : " + Math.Round(result3) + " år.");
                Console.WriteLine("--------------------------------------------------------------------------");


                // Tar fram alla produkter som innehåller bomull
                var sql4 = "SELECT * FROM Products WHERE Info LIKE '%Bomull%' OR Info LIKE '%bomull%'";
                var result4 = connection.Query<Product>(sql4);
                Console.WriteLine("Alla produkter som innehåller bomull: ");
                foreach (var product in result4)
                {
                    Console.WriteLine(product.Name + ": " + product.Info);
                }
               
            }
        }

     




    }
}
