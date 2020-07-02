using System.Collections.Generic;

namespace Twitter.Models
{
    public class ViewMain
    {
        public Users User { get; set; }
        public List<TweetDetail> TweetDetails { get; set; }
        public List<HashTag> HashTags { get; set; }
        public List<Users> Users { get; set; }
        public List<Follow> Follows { get; set; }
        public List<Follow> Followers { get; set; }
 
        public List<Conversation> Conversations { get; set; }
 
        public ViewMain()
        {
            TweetDetails = new List<TweetDetail>();
            HashTags = new List<HashTag>();
            Users = new List<Users>();
            Follows = new List<Follow>();
            Followers = new List<Follow>();
            Conversations = new List<Conversation>();
        }
    }
}
