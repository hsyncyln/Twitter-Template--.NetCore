using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twitter.Models;

namespace Twitter.Controllers
{
    public class ProfileController : Controller
    {
        TwitterContext context = new TwitterContext();

        [HttpPost]
        public IActionResult Index(string username)
        {
            ViewMain model = new ViewMain();
            Users user = new Users();
            user = context.Users.Where(x => x.UserName == username).FirstOrDefault();
            model.User = user;

            var Tweets = context.Tweets.Where(x=> x.UserId==user.Id).OrderByDescending(x => x.ShareDate).ToList();
            model.HashTags = context.HashTags.OrderBy(x => x.TweetHashTag.Count).Take(5).ToList();
            model.Users = context.Users.ToList();

            model.Follows = user.Follows.ToList();  //Takip Edilenler
            model.Followers = context.Follows.Where(x => x.User == user).ToList();  //Takip edenler

            var notfriend = model.Followers.Except(model.Follows).Take(2);  //Önerilen kişiler
            foreach(Follow fw in notfriend)
            {
                model.Users.Add(fw.User);
            }
            

            foreach (Tweet tweet in Tweets)
            {

                var likes = context.Likes.Where(x => x.TweetId == tweet.id).ToList();
                var retweets = context.ReTweets.Where(x => x.TweetId == tweet.id).ToList();

                TweetDetail detail = new TweetDetail();
                detail.Tweet = tweet;
                detail.Likes = likes;
                detail.ReTweets = retweets;

                model.TweetDetails.Add(detail);
            }
            return View(model);
        }
    }
}