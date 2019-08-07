using System;

namespace Bug.Tracker.Models
{
    public class User// : RecordWithGuid
    {
        public User(Guid id)
        {
            Id = id;
        }

        public User()
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
