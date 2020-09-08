using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NegativeCoords
{

    internal sealed class MainViewModel
        : INotifyPropertyChanged
    {
        #region Constructors
        public MainViewModel()
        {
            SelectionViewModel = new SelectionViewModel();
        }
        #endregion

        #region Private fields

        #endregion

        #region Properties
        public SelectionViewModel SelectionViewModel { get; private set; }
        #endregion

        #region Commands

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
