using System.Collections.Generic;

namespace Bug.Tracker.Models
{
    public interface IDataRow
    {
        public IEnumerable<string> Values { get; }
    }
}