using FSE.Assignment20.MVC.Core;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FSE.Assignment20.MVC.TwitterClone.Controllers
{
    public class TweetController : Controller
    {
        public ActionResult Index(string id)
        {
            var model = new TweetManagement().GetUserTweet(id);
            if (TempData.Any())
            {
                model.CurrentTweet = TempData.First().Value as Tweet;
                TempData.Clear();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult PostUpdate(FormCollection collection)
        {
            var userId = collection["UserName"];
            var message = collection["Message"];
            var id = collection["TweetId"];
            if (id == "0")
                new TweetManagement().AddTweet(userId, message);
            else
                new TweetManagement().UpdateTweet(Convert.ToInt32(id), message);
            return RedirectToAction("Index", new { id = userId });
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection, string submit)
        {
            var id = collection["TweetId"];
            var userId = collection["UserName"];
            if (submit == "Edit")
            {
                TempData[id] = new TweetManagement().GetTweet(Convert.ToInt32(id));
                return RedirectToAction("Index", new { id = userId });
            }
            else
            {
                new TweetManagement().DeleteTweet(Convert.ToInt32(id));
                return RedirectToAction("Index", new { id = userId });
            }
        }
    }
}