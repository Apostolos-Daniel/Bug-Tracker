using Bug.Tracker.Models.Enums;
using System;

namespace Bug.Tracker.Models
{
    public class BugItem
    {
        public BugItem()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            AssignedTo = "Kenneth";
            Status = BugStatus.open;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string AssignedTo { get; set; }
        public BugStatus Status { get; set; }
    }
}