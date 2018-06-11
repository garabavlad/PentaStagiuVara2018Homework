using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module01Week03
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creating a new MainMenu instance:
            MainMenu mainMenu = new MainMenu();

            // Getting user input & executing options:
            while(!mainMenu.isExitSelected)
            {
                mainMenu.DisplayMainMenu();
                mainMenu.GetUserOption();
            }

        }
    }
}
