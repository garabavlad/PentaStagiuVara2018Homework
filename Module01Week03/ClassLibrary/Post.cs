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
    [Serializable]
    class Post : Board, IEquatable<Post>, IComparable<Post>
    {
        public DateTime postTime { get; private set; }
        public string text { get; private set; }
        public User author { get; private set; }
        private bool changed = false;

        /*
         *  Post class constructor.
         *  Creates a new Post with standard input information.
         */
        public Post(DateTime TimeWhenPosted, string Message, User Author)
        {
            this.postTime = TimeWhenPosted;
            this.text = Message;
            this.author = Author;
        }

        /*
         *  Method used for editing post:
         */
        public void EditPost(string newText)
        {
            changed = true;
            this.text = newText;
        }

        /*
         *  Overriding default Methods:
         *  Also adding methods for IComparable & IEquatable.
         *  It is used to sort the list of these objects.
         */
        public override string ToString()
        {
            return "Message: " + text;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Post objAsPost = obj as Post;
            if (objAsPost == null) return false;
            else return Equals(objAsPost);
        }

        // Default comparer for Part type.
        public int CompareTo(Post comparePost)
        {
            // A null value means that this object is greater.
            if (comparePost == null)
                return 1;

            else
                return this.postTime.CompareTo(comparePost.postTime);
        }

        public bool Equals(Post other)
        {
            if (other == null) return false;
            return (this.postTime.Equals(other.postTime));
        }
    }
}
