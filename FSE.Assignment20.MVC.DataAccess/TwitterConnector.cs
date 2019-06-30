﻿using System;
using System.Linq;
namespace FSE.Assignment20.MVC.DataAccess
{
    public class TwitterConnector
    {
        private TwitterDatabaseModel _model = null;
        public TwitterConnector(TwitterDatabaseModel model)
        {
            _model = model;
        }
        public TwitterConnector() : this(new TwitterDatabaseModel()) { }
        private static readonly Lazy<TwitterConnector> lazy = new Lazy<TwitterConnector>(
            () => new TwitterConnector(new TwitterDatabaseModel()));
        public static TwitterConnector Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public Person GetPerson(string userId)
        {
            return _model.People.FirstOrDefault(p => p.UserId == userId && p.Active);
        }

        public void AddPerson(Person person)
        {
            _model.People.Add(person);
            _model.SaveChanges();
        }

        public void DeactivatePerson(string userId)
        {
            var person = GetPerson(userId);
            if (person != null)
            {
                person.Active = false;
                _model.SaveChanges();
            }
        }

        public void AddFollower(Person person, Person follow)
        {
            person.Following.Add(follow);
            _model.SaveChanges();
        }
    }
}