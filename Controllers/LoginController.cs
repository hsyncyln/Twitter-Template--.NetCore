using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Twitter.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Twitter.Controllers
{
    public class LoginController : Controller
    {
        TwitterContext context = new TwitterContext();

        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }

        public ActionResult SignUp()
        {
            return RedirectToAction("SignUp", "Index");
        }
        public ActionResult PasswordReset()
        {
            return RedirectToAction("PasswordReset", "Index");
        }

        [HttpGet]
        public ActionResult SignIn()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string username_or_email, string password)
        {

            var list = context.Users.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].UserName == username_or_email || list[i].Email == username_or_email)
                {
                    if (list[i].Password == password)
                    {
                        TempData["id"] = list[i].Id;

                        return RedirectToAction("Index", "Main", new { list[i].Id });
                    }
                }
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
