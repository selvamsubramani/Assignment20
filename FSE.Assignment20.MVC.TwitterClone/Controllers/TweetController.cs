using FSE.Assignment20.MVC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FSE.Assignment20.MVC.TwitterClone.Controllers
{
    public class TweetController : Controller
    {
        private const string CurrentTweet = "CurrentTweet";
        private const string UserListToFollow = "UserListToFollow";
        private const string UserId = "UserId";
        public ActionResult Index()
        {
            //if (TempData.ContainsKey(UserId))
            //{                
            //    Session[UserId] = TempData[UserId];
            //}
            var userId = Session[UserId].ToString();
            var model = new TweetManagement().GetUserTweet(userId);
            if (TempData.Any())
            {
                if (TempData.ContainsKey(CurrentTweet))
                {
                    model.CurrentTweet = TempData[CurrentTweet] as Tweet;
                    //TempData.Remove(CurrentTweet);
                }
                if (TempData.ContainsKey(UserListToFollow))
                {
                    model.UserListToFollow = TempData[UserListToFollow] as List<Follow>;
                    //TempData.Remove(UserListToFollow);
                }
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
            //TempData[UserId] = userId;
            //return RedirectToAction("Index", new { id = userId });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection, string submit)
        {
            var id = collection["TweetId"];
            var userId = collection["UserName"];
            if (submit == "Edit")
            {
                TempData[CurrentTweet] = new TweetManagement().GetTweet(Convert.ToInt32(id));

                //return RedirectToAction("Index", new { id = userId });
            }
            else
            {
                new TweetManagement().DeleteTweet(Convert.ToInt32(id));
                //return RedirectToAction("Index", new { id = userId });
            }
            //TempData[UserId] = userId;
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProfile(string id)
        {
            var user = new UserManagement().GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            new UserManagement().DeactivateUser(collection["UserName"]);
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            var userId = collection[0];
            var name = collection[1];

            var list = new UserManagement().SearchUserToFollow(userId, name);
            if (list != null)
                TempData[UserListToFollow] = list;

            //TempData[UserId] = userId;
            //return RedirectToAction("Index", new { id = userId });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Follow(string submit)
        {
            var userId = Session[UserId].ToString();
            var followingId = Request.Form["Username"].ToString();
            if (Request.Form[1].Equals("Follow"))
                new UserManagement().FollowUser(userId, followingId);
            else
                new UserManagement().UnFollowUser(userId, followingId);
            //return RedirectToAction("Index", new { id = userId });
            return RedirectToAction("Index");
        }
    }
}