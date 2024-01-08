using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace WebbShopBGrpD
{
    internal class Menu
    {
        public static void MenuBar()
        {
            List<string> topText = new List<string> { "# Fina butiken #", "Allt inom kläder" };
            var windowTop = new Window("", 2, 1, topText);
            windowTop.Left = 45;
            windowTop.Draw();

            //List<string> navigationText = new List<string> { "[1] = Start", "[2] = Shop", "[3] = Varukorg", "[4] = Admin" };
            List<string> navigationText = new List<string> { "[1] = Start [2] = Shop [3] = Varukorg [4] = Admin" };
            var windowNavigation = new Window("", 2, 5, navigationText);
            windowNavigation.Left = 28;
            windowNavigation.Draw();


        }
        
    }
}
