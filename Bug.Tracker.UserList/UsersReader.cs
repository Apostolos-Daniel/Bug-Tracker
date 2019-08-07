using System;
using System.Collections.Generic;
using Bug.Tracker.Models;

namespace Bug.Tracker.UserList
{
    public class UsersReader : IUsersReader
    {
        public IEnumerable<User> GetUsers()
        {
            return new List<User> { new User { Name = "Kenneth" }, new User { Name = "Toli" } };
        }
    }
}
