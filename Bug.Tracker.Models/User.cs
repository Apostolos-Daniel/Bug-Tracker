using System;

namespace Bug.Tracker.Models
{
    public class User : IRecordWithGuid
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
