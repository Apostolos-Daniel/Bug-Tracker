using Bug.Tracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Tracker.BugCreator
{
    public class BugCreator : IBugCreator
    {
        public BugCreator()
        {
        }

        public BugItem CreateBug(string title, string description)
        {
            // create new bug
            var newBugItem = new BugItem
            {
                Title = title,
                Description = description
            };

            // add it to the database and return

            return newBugItem;
        }
    }
}
