using Bug.Tracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Tracker.UserList
{
    public interface IUsersReader
    {
        IEnumerable<User> GetUsers();
    }
}
