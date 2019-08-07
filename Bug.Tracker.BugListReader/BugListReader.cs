using System;
using System.Collections.Generic;
using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;

namespace Bug.Tracker.BugListReader
{
    public class BugListReader : IBugListReader
    {
        IEnumerable<BugItem> _bugItems = new List<BugItem>() { new BugItem { Title = "Test Title", Description = "TEst description"} };

        public IEnumerable<BugItem> GetBugs(BugStatus status)
        {
            return _bugItems;
        }
    }
}
