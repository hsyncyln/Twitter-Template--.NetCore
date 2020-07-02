using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Twitter.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Twitter.Controllers
{
    public class MainController : Controller
    {
        TwitterContext context = new TwitterContext();
        // GET: /<controller>/
        public IActionResult Index(int id)
        {

            ViewMain model = new ViewMain();
            model.User = context.Users.Find(id);
            var Tweets = context.Tweets.OrderByDescending(x => x.ShareDate).ToList();
            model.HashTags = context.HashTags.OrderBy(x=> x.TweetHashTag.Count).Take(5).ToList();
            model.Users = context.Users.ToList();

            foreach (Tweet tweet in Tweets) {

                var likes=context.Likes.Where(x => x.TweetId == tweet.id).ToList();
                var retweets=context.ReTweets.Where(x => x.TweetId == tweet.id).ToList();

                TweetDetail detail = new TweetDetail();
                detail.Tweet = tweet;
                detail.Likes = likes;
                detail.ReTweets= retweets;

                model.TweetDetails.Add(detail);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveTweet(string tweet_text, string user_id)
        {
            int id = Convert.ToInt32(user_id);
            Tweet tweet = new Tweet();
            tweet.UserId = id;
            tweet.ShareDate = DateTime.Now;
            tweet.Comment = tweet_text;

            context.Tweets.Add(tweet);
            context.SaveChanges();

            return RedirectToAction("Index", new { id });
        }

        [HttpPost]
        public void AddFollow(string followuserid,string userid)
        {
            
            int followid = Convert.ToInt32(followuserid);
            int id = Convert.ToInt32(userid);
                
            if(context.Users.Find(id).Follows.Where(x=> x.MainUserId == followid).Count() == 0) { 
                Follow follow = new Follow();
                follow.MainUserId = followid;
                follow.FollowDate = DateTime.Now;
                follow.User = context.Users.Find(id);
                context.Users.Find(id).Follows.Add(follow);
                context.SaveChanges();
            }
        }                                                                                                                                                                               
    }
}
