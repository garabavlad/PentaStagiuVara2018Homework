using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary
{
    /*
     *  This is the central class where are kept all the users and all 
     *  the messages.
     */
     [Serializable]
    public class Board
    {
        // List for keeping all the posts in this collection.
        private List<Post> postList;
        // List for keeping all the users in this collection.
        private List<User> userList;

        // Events:
        // Event handler for new messages:
        public delegate void NewMessageEventHandler(object source, EventArgs args);
        public event NewMessageEventHandler NewPostedMessage;
        // Event handler for new users:
        private event EventHandler NewUserEvent;


        // Class constructor:
        public Board()
        {
            postList = new List<Post>();
            userList = new List<User>();
        }

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
            NewUserAnnouncement();
        }


        // Method for adding a new post in Post List.
        public void AddPost(string message, User author)
        {
            DateTime postTime = DateTime.Now;
            Post newPost = new Post(postTime,message,author);
            postList.Add(newPost);
            OnNewPost(author);
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

        // Method for checking if user exists (used for login):
        public User FindUser(User checkedUser)
        {
            return FindUser(checkedUser.email);
        }

        // @Overload
        public User FindUser(string email)
        {
            return userList.Find(usr => usr.email == email);
        }

        // Method for serialization istance:
        public static Board Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("BoardDB.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Board obj = null;
            try
            {
                obj = (Board)formatter.Deserialize(stream);
            }
            catch(SerializationException e)
            {
                Console.WriteLine(e);
            }
            stream.Close();
            return obj;
        }

        // Method for deserialization istance:
        public void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("BoardDB.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        // Method to fire when new message was posted:
        protected virtual void OnNewPost(User sender)
        {
            NewPostedMessage?.Invoke(sender, EventArgs.Empty);
        }
        // Method to fire when new user was posted:
        private void NewUserAnnouncement()
        {
            if(NewUserEvent != null)
            {
                NewUserEvent(this, EventArgs.Empty);
            }
        }

        // Method to announce all users about new message:
        public void AnnounceNewPost(User sender)
        {
            foreach(var user in userList)
            {
                if(user != sender)
                {
                    user.NewMessages++;
                }
            }
        }
    }
}
