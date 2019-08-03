using System;
using System.Collections.Generic;
using System.Text;
using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;

namespace Bug.Tracker.BugReader
{
    public class BugReader : IBugReader
    {
        public IEnumerable<BugItem> GetBugItems(BugStatus status)
        {
            return new List<BugItem> { new BugItem { Title = "Bug 1", Description = "Bug 1 description" } };
        }
    }
}
