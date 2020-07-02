using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Twitter.Models;

namespace Twitter.Controllers
{
    public class SignUpController : Controller
    {
        TwitterContext context = new TwitterContext();
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string isim, string email, string password, string username)
        {
            if (email.Contains("@"))
            {
                int control = context.Users.Where(x => x.UserName == username).Count();

                if (control == 0)
                {
                    Users user = new Users();
                    user.CreateDate = DateTime.Now;
                    user.Email = email;
                    user.UserName = username;

                    string ad, soyad;
                    if (isim.Contains(" "))
                    {
                        int index = isim.IndexOf(" ");
                        ad = isim.Substring(0, index);
                        soyad = isim.Substring(index + 1);
                    }
                    else
                    {
                        ad = isim;
                        soyad = null;
                    }
                    user.FirstName = ad;
                    user.LastName = soyad;
                    user.Password = password;

                    context.Users.Add(user);
                    context.SaveChanges();

                    return RedirectToAction( "Index","Login");
                }

            }
            return RedirectToAction( "Index","Signup");
        }
    }
}