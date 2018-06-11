using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
     *  This class is used to create new users.
     */
     [Serializable]
    public class User : Board
    {
        public string email { get; private set; }
        private string firstName;
        private string lastName;
        private DateTime birthDate;

        /*
         *  User class constructor.
         *  Creates a new user with standard input information.
         */
        public User(string email, string firstName, string lastName, DateTime birthDate)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        // Method for editting user information:
        public void EditUserInformation(string email, string firstName, string lastName, DateTime birthDate)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;

        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }

    }
}
