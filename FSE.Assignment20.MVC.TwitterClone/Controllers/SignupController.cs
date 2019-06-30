using FSE.Assignment20.MVC.Core;
using System.Web.Mvc;

namespace FSE.Assignment20.MVC.TwitterClone.Controllers
{
    public class SignupController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            new UserManagement().AddUser(
                new User
                {
                    Username = collection["Username"],
                    Password = collection["Password"],
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"]
                });
            return RedirectToAction("Index", "Login");
        }
    }
}