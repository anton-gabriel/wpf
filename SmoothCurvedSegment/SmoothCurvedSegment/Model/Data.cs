using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SmoothCurvedSegment.Model
{
    internal sealed class Data
    {
        #region Constructors
        public Data()
        {
            Ports = ImmutableHashSet.CreateRange(new List<Port>
            {
                new Port() { Name = "Port1" },
                new Port() { Name = "Port2" },
                new Port() { Name = "Port3" },
                new Port() { Name = "Port4" },
            });
            Properties = new ObservableHashSet<string>();
        }
        #endregion


        #region Properties
        public string Name { get; private set; }
        public IEnumerable<string> Properties { get; private set; }
        public IEnumerable<Port> Ports { get; private set; }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
