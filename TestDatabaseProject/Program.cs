using FSE.Assignment20.MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabaseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person
            {
                UserId = "user01",
                Password = "user01",
                FullName = "test user01",
                Email = "user01@twitter.com",
                Active = true,
                Joined = DateTime.Now
            };
            Person p2 = new Person
            {
                UserId = "user02",
                Password = "user02",
                FullName = "test user02",
                Email = "user02@twitter.com",
                Active = true,
                Joined = DateTime.Now
            };
            Person p3 = new Person
            {
                UserId = "user03",
                Password = "user03",
                FullName = "test user03",
                Email = "user03@twitter.com",
                Active = true,
                Joined = DateTime.Now
            };
            TwitterConnector.Instance.AddPerson(p1);
            TwitterConnector.Instance.AddPerson(p2);
            TwitterConnector.Instance.AddPerson(p3);

            TwitterConnector.Instance.AddFollower(p1, p2);
            TwitterConnector.Instance.AddFollower(p1, p3);
            TwitterConnector.Instance.AddFollower(p2, p3);

            Console.Read();
        }
    }
}
