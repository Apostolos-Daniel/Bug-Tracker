using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bug.Tracker.BugReader
{
    public interface IBugReader
    {
        Task<IEnumerable<BugItem>> GetBugItems(BugStatus status);
    }
}
