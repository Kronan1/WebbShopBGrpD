using Azure;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WebbShopBGrpD.Models;
using WindowDemo;

namespace WebbShopBGrpD
{

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sv-SE");

            // Kör en gång för att skapa data
            //Data.CreateData(); 


            //string connectionString = "Server=.\\SQLExpress;Database=WebbShopB;Trusted_Connection=True;TrustServerCertificate=True;";

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    var sql = "SELECT AVG()";

                
            //}


            Menu menu = new Menu();

            menu.StartPage();
            // Fixa admin
            // Fixa Beställningar
        }
    }
}
