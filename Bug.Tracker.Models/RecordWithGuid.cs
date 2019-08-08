using System;

namespace Bug.Tracker.Models
{
    public interface IRecordWithGuid
    {
        public Guid Id { get; set; }
    }
}