using System;
using System.Collections.Generic;

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
        private event EventHandler NewAddedUser;


        // Class constructor:
        public Board()
        {
            postList = new List<Post>();
            userList = new List<User>();
        }

        // Handling class indexer operator:
        public Post this[int i]
        {
            get { return postList[i]; }
        }

        // Method for adding a new user in User List.
        public void AddUser(string email, string firstName, string lastName, DateTime birthDate)
        {
            User newUser = new User(email,firstName,lastName,birthDate);
            userList.Add(newUser);
            NewAddedUser += PostNewUserAdded;
            OnNewUser(newUser);
        }
        // @Overload
        public void AddUser(User newUser)
        {
            userList.Add(newUser);
            NewAddedUser += PostNewUserAdded;
            OnNewUser(newUser);
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
                if (el.author != null)
                {
                    Console.WriteLine("\n>" + el.author + " wrote on " + el.postTime +
                        ":" + el.text);
                }
                else
                {
                    Console.WriteLine("\n>System (" + el.postTime + "): " + el.text);
                }
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

        
        // Method to fire when new message was posted:
        protected virtual void OnNewPost(User sender)
        {
            NewPostedMessage?.Invoke(sender, EventArgs.Empty);
        }
        
        // Method to fire when new user joined the board:
        protected virtual void OnNewUser(User newUser)
        {
            if(NewAddedUser != null)
            {
                NewAddedUser(newUser, EventArgs.Empty);
            }
        }


        // Method to announce all users about new message:
        // (used for NewPostedMessage event)
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

        // Method to post a new message when a new user joins the board:
        // (used for NewAddedUser event)
        private void PostNewUserAdded(object sender,EventArgs args)
        {
            User newUser = (User)sender;
            this.AddPost(newUser.ToString() + " has joined the board!", null);
            NewAddedUser -= PostNewUserAdded;
        }

        // Method to reset new messages a user sees after it check new messages:
        public void ResetNewMessages(User looker)
        {
            looker.NewMessages = 0;
        }
    }
}
