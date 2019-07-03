using FSE.Assignment20.MVC.Core;
using System.Web.Mvc;

namespace FSE.Assignment20.MVC.TwitterClone.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var login = new Login
            {
                Username = collection["Username"],
                Password = collection["Password"]
            };
            TempData.Clear();
            if (new UserManagement().ValidateUser(login))
            {
                Session["UserId"] = login.Username;
                return RedirectToAction("Index", "Tweet");
            }

            ModelState.AddModelError(string.Empty, "Login failed. Please provide valid username & password");
            return View("Index", login);
        }
    }
}