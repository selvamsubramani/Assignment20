using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.Assignment20.MVC.Core
{
    public class UserTweet
    {
        public User User { get; set; }
        public List<User> Followers { get; set; }
        public List<User> Following { get; set; }
        public List<Tweet> Tweets { get; set; }
        public Tweet CurrentTweet { get; set; }
        public List<Follow> UserListToFollow { get; set; }
        public UserTweet()
        {
            User = new User();
            Followers = new List<User>();
            Following = new List<User>();
            Tweets = new List<Tweet>();
            CurrentTweet = new Tweet();
        }
    }

    public class Tweet
    {
        public int TweetId { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public bool IsAllowed { get; set; }
    }

}
