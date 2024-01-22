using Azure;
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


            Menu menu = new Menu();

            menu.StartPage();
            // Fixa admin
            // Fixa Beställningar
        }
    }
}
