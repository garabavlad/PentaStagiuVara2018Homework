using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Module01Week03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a new board:
            Board mainBoard = new Board();

            //Creating a new user and adding it to out :
            User admin = new User("admin@company.com", "Dan", "Remmy", new DateTime(1966, 5, 22));
            mainBoard.AddUser(admin);

            //Creating new posts:
            mainBoard.AddPost("First post", admin);
            mainBoard.AddPost("Second post", admin);
            mainBoard.AddPost("A post from 2000", admin);
            mainBoard.AddPost("A post from 2010", admin);

            // Displaying:
            mainBoard.ShowBoard();
        }
    }
}
