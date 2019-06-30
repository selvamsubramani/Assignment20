using FSE.Assignment20.MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.Assignment20.MVC.Core
{
    public class TweetManagement
    {
        private TwitterConnector _connector;

        public TweetManagement() : this(TwitterConnector.Instance) { }
        public TweetManagement(TwitterConnector connector)
        {
            _connector = connector;
        }

        public UserTweet GetUserTweet(string userId)
        {
            UserTweet result = new UserTweet();
            var person = _connector.GetPerson(userId);
            if (person != null)
            {
                result.User = new User
                {
                    Username = person.UserId,
                    Email = person.Email,
                    Password = person.Password,
                    FirstName = person.FullName
                };

                result.Followers = GetUsers(person.Followers).ToList();

                result.Following = GetUsers(person.Following).ToList();

                result.Tweets.AddRange(GetTweetByUserId(userId));
                result.Following.ForEach(x =>
                {
                    result.Tweets.AddRange(GetTweetByUserId(x.Username));
                });
                result.Tweets = result.Tweets.OrderByDescending(x => x.TweetId).ToList();

                result.CurrentTweet.UserName = userId;
                result.CurrentTweet.FullName = person.FullName;
            }
            return result;
        }
        public Tweet GetTweet(int id)
        {
            var tweet = _connector.GetTweet(id);
            if (tweet != null)
            {
                return
                new Tweet
                {
                    TweetId = tweet.TweetId,
                    Created = tweet.Created,
                    Message = tweet.Message,
                    UserName = tweet.UserId,
                    FullName = tweet.Person.FullName
                };

            }
            return new Tweet();
        }

        private IEnumerable<Tweet> GetTweetByUserId(string userId)
        {
            return
            _connector.GetTweets(userId).Select(x => new Tweet
            {
                TweetId = x.TweetId,
                Message = x.Message,
                Created = x.Created,
                UserName = x.UserId,
                FullName = x.Person.FullName,
                IsAllowed = x.UserId == userId
            });
        }

        private IEnumerable<User> GetUsers(ICollection<Person> persons)
        {
            return
                persons.Select(x => new User
                {
                    Username = x.UserId,
                    Email = x.Email,
                    Password = x.Password,
                    FirstName = x.FullName
                });
        }

        public void AddTweet(string userId, string message)
        {
            _connector.AddTweet(userId, message);
        }

        public void UpdateTweet(int id, string message)
        {
            _connector.UpdateTweet(id, message);

        }
        public void DeleteTweet(int id)
        {
            _connector.DeleteTweet(id);
        }
    }
}
