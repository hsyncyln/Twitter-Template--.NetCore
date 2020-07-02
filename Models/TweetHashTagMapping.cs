using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class TweetHashTagMapping
    {
        [Key]
        public int MappingId { get; set; }
        public int HashTagId { get; set; }
        public virtual HashTag HashTag { get; set; }

        public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; }
    }
}
