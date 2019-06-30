using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.Assignment20.MVC.Core
{
    class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}
