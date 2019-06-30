using FSE.Assignment20.MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.Assignment20.MVC.Core
{
    class UserManagement
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
                    Email = user.Email
                });
        }

        public void DeactivateUser(string username)
        {
            _connector.DeactivatePerson(username);
        }
    }
}
