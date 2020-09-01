using System;
using System.Collections.Generic;

namespace TabManager.Model
{
    internal sealed class TableData
    {
        public TableData(string name, ICollection<string> values, string parentName)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Values = values ?? throw new ArgumentNullException(nameof(values));
            ParentName = parentName ?? throw new ArgumentNullException(nameof(parentName));
        }

        public string ParentName { get; private set; }
        public string Name { get; private set; }
        public ICollection<string> Values { get; private set; }
    }
}
