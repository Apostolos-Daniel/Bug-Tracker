using Bug.Tracker.Models;
using System;

namespace Bug.Tracker.BugCreator
{
    public interface IBugCreator
    {
        BugItem CreateBug(string title, string description);
    }
}
