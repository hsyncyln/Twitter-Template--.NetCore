using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twitter.Models;

namespace Twitter.Controllers
{

    public class MessageController : Controller
    {
        TwitterContext context = new TwitterContext();

        [HttpPost]
        public IActionResult Index(string username)
        {
            ViewMain model = new ViewMain();
            Users user = new Users();
            user = context.Users.Where(x => x.UserName == username).FirstOrDefault();
            model.User = user;

            model.HashTags = context.HashTags.OrderBy(x => x.TweetHashTag.Count).Take(5).ToList();
            model.Users = context.Users.ToList();

            foreach (Messages message in user.Messages.OrderBy(x=> x.MessageTime))
            {
                    
                Conversation conv = new Conversation();
                conv.OtherPerson = message.User;
                conv.SendMessages.Append(message);
                model.Conversations.Append(conv);
            }

            foreach (Messages message in context.Messages.Where(x=> x.User==user).OrderBy(x => x.MessageTime))
            {
                Conversation conv = new Conversation();
                conv.OtherPerson = message.User;
                conv.TakeMessages.Append(message);
                model.Conversations.Append(conv);
                
            }
              
            return View(model);
        }
    }
}