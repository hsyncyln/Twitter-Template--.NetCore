using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class ReTweet
    {
        public int Id { get; set; }

        public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; }



    }
}
