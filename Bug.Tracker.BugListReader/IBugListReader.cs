using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Tracker.BugListReader
{
    public interface IBugListReader
    {
        public IEnumerable<BugItem> GetBugs(BugStatus status);
    }
}
