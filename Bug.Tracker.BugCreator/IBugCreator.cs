using Bug.Tracker.Models;
using System;
using System.Threading.Tasks;

namespace Bug.Tracker.BugCreator
{
    public interface IBugCreator
    {
        Task<BugItem> CreateBug(string title, string description);
    }
}
