using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module01Week03
{
    class UserMenu
    {
        void DisplayUserMenu()
        {
            Console.WriteLine("\nUser menu:" +  
                "\nEnter 1 to view the board." +
                "\nEnter 2 to post a message." +
                "\nEnter 3 to edit profile." +
                "\nEnter 4 to log out." +
                "");
        }
    }
}
