using Bug.Tracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bug.Tracker.UserReader
{
    public interface IUserReader
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
