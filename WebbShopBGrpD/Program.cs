using Azure;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
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


            Helpers.GetQueries();



            Menu menu = new Menu();

            menu.StartPage();
           
        }
    }
}
