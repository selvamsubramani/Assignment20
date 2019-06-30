using FSE.Assignment20.MVC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ModelState.AddModelError(string.Empty, "Login failed. Please provide valid username & password");
            return View("Index", new Login());
        }
    }
}