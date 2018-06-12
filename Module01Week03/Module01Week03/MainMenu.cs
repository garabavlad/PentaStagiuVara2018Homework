using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Module01Week03
{
    class MainMenu
    {
        public bool isExitSelected { get; private set; } = false;
        // mainBoard istance is used as the main app system.
        private Board mainBoard;
        private User loggedUser = null;

        // Constructor:
        public MainMenu()
        {
            try
            {
                // Deserializing the board from the last session.
                mainBoard = BoardSerializator.DeserializeBoard();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("" + e);
            }

            if(mainBoard == null)
                mainBoard = new Board();

        }

        // Method for displaying menu:
        public void DisplayMainMenu()
        {
            Console.WriteLine("\nMain menu:" +
                "\nEnter 1 to log in." +
                "\nEnter 2 to sign up." +
                "\nEnter 3 to enter as guest (can't post messages)." +
                "\nEnter 4 to exit program." +
                "");
        }

        // Method for getting user desired option and executing it:
        public void GetUserOption()
        {
            Console.WriteLine("Choice:");
            try
            {
                int userInput = Int32.Parse(Console.ReadLine());
                DoOption(userInput);
            }
            catch (FormatException excep)
            {
                Console.WriteLine(excep);
            }
        }

        private void DoOption(int option)
        {
            switch (option)
            {
                // Login
                case 1:
                    LoginOption();
                    break;

                // Sign up
                case 2:
                    SignUpOption();
                    break;

                // As guest
                case 3:
                    AsGuestOption();
                    break;

                // Exit
                case 4:
                    ExitOption();
                    break;

                default:
                    Console.WriteLine("No such option.");
                    break;

            }
        }

        /*
         * Switch case options:
         */
        private void LoginOption()
        {
            Console.WriteLine("Enter your email:");
            string email;
            email = Console.ReadLine();

            User foundUser = mainBoard.FindUser(email);
            if (foundUser != null)
            {
                loggedUser = foundUser;
                UserMenu userMenu = new UserMenu(mainBoard, loggedUser);
                while (!userMenu.isExitSelected)
                {
                    userMenu.GetUserOption();
                }
            }
            else
            {
                loggedUser = null;
                Console.WriteLine("User not found!");
            }

        }
        private void SignUpOption()
        {
            string email, fname, lname;
            int year, month, day;
            DateTime bdate;

            Console.WriteLine("\nEnter your information:\nEmail:");
            email = Console.ReadLine();

            Console.WriteLine("First name:");
            fname = Console.ReadLine();

            Console.WriteLine("Last name");
            lname = Console.ReadLine();

            try
            {
                Console.WriteLine("Birth year:");
                year = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Birth month:");
                month = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Birth day:");
                day = Int32.Parse(Console.ReadLine());

                bdate = new DateTime(year, month, day);
            }
            catch (FormatException excep)
            {
                Console.WriteLine(excep);
                return;
            }

            User newUser = new User(email, fname, lname, bdate);
            mainBoard.AddUser(newUser);
            loggedUser = newUser;

            // Implementing a new User Menu;
            UserMenu userMenu = new UserMenu(mainBoard, loggedUser);
            while (!userMenu.isExitSelected)
            {
                userMenu.GetUserOption();
            }
        }
        private void AsGuestOption()
        {
            UserMenu userMenu = new UserMenu(mainBoard, null);
            while (!userMenu.isExitSelected)
            {
                userMenu.GetUserOption();
            }
        }
        private void ExitOption()
        {
            isExitSelected = true;

            // Serialize instance:
            BoardSerializator boardSerializator = new BoardSerializator();
            boardSerializator.SerializeBoard(mainBoard);
        }
    }
}
