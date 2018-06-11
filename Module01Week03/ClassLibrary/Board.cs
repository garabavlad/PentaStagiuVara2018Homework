using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
     *  This is the central class where are kept all the users and all 
     *  the messages.
     */
    public class Board
    {
        // List for keeping all the posts in this collection.
        private List<Post> postList = new List<Post>();
        // List for keeping all the users in this collection.
        private List<User> userList = new List<User>();

        // Method for adding a new user in User List.
        public void AddUser(string email, string firstName, string lastName, DateTime birthDate)
        {
            User newUser = new User(email,firstName,lastName,birthDate);
            userList.Add(newUser);
        }
        // @Overload
        public void AddUser(User newUser)
        {
            userList.Add(newUser);
        }



        // Method for adding a new post in Post List.
        public void AddPost(string message, User author)
        {
            DateTime postTime = DateTime.Now;
            Post newPost = new Post(postTime,message,author);
            postList.Add(newPost);
            postList.Sort();
        }

        //  Method for displaying all posts.
        public void ShowBoard()
        {
            postList.Sort();
            foreach(var el in postList)
            {
                Console.WriteLine("\n" + el.author + " wrote on " + el.postTime +
                    "\n" + el.text);
            }
        }
    }
}
