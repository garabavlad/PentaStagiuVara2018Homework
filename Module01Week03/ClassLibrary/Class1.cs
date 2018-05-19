using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
    *  This class is used to create a new post (message) which will be shown
    * into the Board class.
    */
    class Post : Board
    {
        private readonly DateTime PostTime;
        private readonly string Text;
        private readonly User Author;

        /*
         *  Post class constructor.
         *  Creates a new Post with standard input information.
         */
        public Post(DateTime TimeWhenPosted, string Message, User Author)
        {
            this.PostTime = TimeWhenPosted;
            this.Text = Message;
            this.Author = Author;
        }
    }

    /*
     *  This is the central class where are kept all the users and all 
     *  the messages.
     */
    class Board
    {
        // Keeping all the messages in this collection.
        private List<Post> PostList = new List<Post>();
        // Keeping all the users in this collection.
        private List<User> UserList = new List<User>();

        public void AddUser(User NewUser)
        {
            //UserList.Add(NewUser);
        }

        public void AddPost(Post NewPost)
        {

        }

        //  Method for displaying all messages.
        public void ShowBoard()
        {

        }
    }

    /*
     *  This class is used to create new users.
     *  Warning: Users are not automatically included in the board class.
     *  This should be done with Board.AddUser() Method.
     */
    class User : Board
    {
        /*  Temporarily made readonly variables. TO CHANGE after implementing EditUserInformation method.*/
        private readonly string Email;
        private readonly string FirstName;
        private readonly string LastName;
        private readonly DateTime BirthDate;

        /*
         *  User class constructor.
         *  Creates a new user with standard input information.
         */
        public User(string Email, string FirstName, string LastName, DateTime BirthDate)
        {
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
        }

        // Method for editting user information.
        public void EditUserInformation(string Email, string FirstName, string LastName, DateTime BirthDate)
        {

        }
    }
}
