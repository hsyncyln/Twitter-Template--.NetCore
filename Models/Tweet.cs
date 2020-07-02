using System;
using System.Collections.Generic;

namespace Twitter.Models
{
    public class Tweet
    {
        public Tweet()
        {
            TweetHashTag = new HashSet<TweetHashTagMapping>();
            Likes= new HashSet<Like>();

        }
        public int id { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
        public DateTime ShareDate { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<TweetHashTagMapping> TweetHashTag { get; set; }
        public virtual ICollection<ReTweet> ReTweets { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
