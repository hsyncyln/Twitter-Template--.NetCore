using System;
using System.Collections.Generic;

namespace Twitter.Models
{
    public class HashTag
    {
        public HashTag()
        {
            TweetHashTag = new HashSet<TweetHashTagMapping>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime ShareDate { get; set; }
        public string TopicPlace { get; set; }
        public virtual ICollection<TweetHashTagMapping> TweetHashTag { get; set; }

    }
}
