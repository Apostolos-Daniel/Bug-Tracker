using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;
using System;
using System.Threading.Tasks;

namespace Bug.Tracker.BugUpdater
{
    public interface IBugUpdater
    {
        Task<BugItem> UpdateStatus(Guid bugItemId, BugStatus status, string userId);
    }
}
