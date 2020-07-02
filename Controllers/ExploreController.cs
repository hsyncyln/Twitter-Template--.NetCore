using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twitter.Models;

namespace Twitter.Controllers
{
    public class ExploreController : Controller
    {
        TwitterContext context = new TwitterContext();

        [HttpPost]
        public IActionResult Index(string username)
        {
            ViewMain model = new ViewMain();
            Users user = new Users();
            user = context.Users.Where(x => x.UserName == username).FirstOrDefault();
            model.User = user;
            model.Users = context.Users.ToList();
            model.HashTags = context.HashTags.OrderBy(x => x.TweetHashTag.Count).Take(5).ToList();

            return View(model);
        }
    }
}