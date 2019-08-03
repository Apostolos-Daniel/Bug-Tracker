using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;
using System;
using System.Collections.Generic;

namespace Bug.Tracker.BugReader
{
    public interface IBugReader
    {
        IEnumerable<BugItem> GetBugItems(BugStatus status);
    }
}
