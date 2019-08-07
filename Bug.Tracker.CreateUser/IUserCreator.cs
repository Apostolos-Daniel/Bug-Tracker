using Bug.Tracker.Models;
using System;
using System.Threading.Tasks;

namespace Bug.Tracker.CreateUser
{
    public interface IUserCreator
    {
        Task<User> CreateUser(string name);
    }
}
