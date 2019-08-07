using Bug.Tracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bug.Tracker.UserUpdater
{
    public interface IUserUpdater
    {
        Task<User> UpdateUserName(Guid userId, string name);
    }
}
