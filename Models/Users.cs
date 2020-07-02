using System;
using System.Collections.Generic;

namespace Twitter.Models
{
    public class Users
    {
        public Users()
        {
            Tweets = new HashSet<Tweet>();
            Follows = new HashSet<Follow>();
            Likes = new HashSet<Like>();
            Messages = new HashSet<Messages>();

        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Phoneumber { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string ProfilePhoto { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
