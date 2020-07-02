using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class TweetDetail
    {
        public Tweet Tweet { get; set; }
        public List<Like> Likes { get; set; }
        public  List<ReTweet> ReTweets{ get; set; }

        public TweetDetail()
        {
            Likes = new List<Like>();
            ReTweets = new List<ReTweet>();
        }
    }
}
