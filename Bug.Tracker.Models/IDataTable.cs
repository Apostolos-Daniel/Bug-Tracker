using Bug.Tracker.Models.Enums;
using System;
using System.Collections.Generic;

namespace Bug.Tracker.Models
{
    public interface IDataTable
    {
        public IEnumerable<string> ColumnNames { get; set; }
        public IEnumerable<IDataRow> DataRows { get; set; }
    }
}