using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Tracker.BugListReader
{
    interface IBugListReader
    {
        IEnumerable<IBugItem> GetBugs(BugStatus);
    }
}
