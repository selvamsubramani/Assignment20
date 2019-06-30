using FSE.Assignment20.MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.Assignment20.MVC.Core
{
    class TweetManagement
    {
        private TwitterConnector _connector;

        public TweetManagement() : this(TwitterConnector.Instance) { }
        public TweetManagement(TwitterConnector connector)
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
    }
}
