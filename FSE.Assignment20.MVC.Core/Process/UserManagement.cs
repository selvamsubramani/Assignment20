using FSE.Assignment20.MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.Assignment20.MVC.Core
{
    public class UserManagement
    {
        private TwitterConnector _connector;

        public UserManagement() : this(TwitterConnector.Instance) { }
        public UserManagement(TwitterConnector connector)
        {
            _connector = connector;
        }

        public bool ValidateUser(Login userCredential)
        {
            var person = _connector.GetPerson(userCredential.Username);
            if (person != null)
            {
                return person.Password == userCredential.Password.EncryptedPassword();
            }
            return false;
        }

        public void AddUser(User user)
        {
            _connector.AddPerson(
                new Person
                {
                    UserId = user.Username,
                    Password = user.Password.EncryptedPassword(),
                    FullName = user.FullName,
                    Email = user.Email,
                    Active = true,
                    Joined = DateTime.Now
                });
        }

        public void DeactivateUser(string username)
        {
            _connector.DeactivatePerson(username);
        }

        public User GetUser(string userId)
        {
            var person = _connector.GetPerson(userId);
            if (person != null)
            {
                return
                    new User
                    {
                        Username = person.UserId,
                        FirstName = person.FullName,
                        Email = person.Email,
                        Password = person.Password
                    };
            }
            return new User { };
        }

        public List<Follow> SearchUserToFollow(string userId, string name)
        {
            var followers = _connector.SearchFollowers(name);
            if (followers.Any(x => x.UserId != userId))
            {
                return followers.Where(x => x.UserId != userId)
                    .Select(x => new Follow
                    {
                        Username = x.UserId,
                        Fullname = x.FullName,
                        ActionName = x.Followers.Any(y => y.UserId == userId) ? "UnFollow" : "Follow"
                    }).ToList();
            }
            return null;
        }

        public void FollowUser(string userId, string followingId)
        {
            var currentUser = _connector.GetPerson(userId);
            var followingUser = _connector.GetPerson(followingId);
            if (currentUser != null && followingId != null)
            {
                _connector.AddFollower(currentUser, followingUser);
            }
        }

        public void UnFollowUser(string userId, string followingId)
        {
            var currentUser = _connector.GetPerson(userId);
            var followingUser = _connector.GetPerson(followingId);
            if (currentUser != null && followingId != null)
            {
                _connector.RemoveFollower(currentUser, followingUser);
            }
        }
    }
}
