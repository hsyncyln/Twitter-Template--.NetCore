using Microsoft.EntityFrameworkCore;

namespace Twitter.Models
{
    public class TwitterContext : DbContext
    {
        public TwitterContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\MSSQLSERVER01;Database=Twiter;Integrated Security=True");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<HashTag> HashTags {get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<ReTweet> ReTweets { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<TweetHashTagMapping> TweetHashTags { get; set; }
    }
}
