using SmoothCurvedSegment.Commands;
using SmoothCurvedSegment.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SmoothCurvedSegment
{
    internal sealed class DataListViewModel
        : INotifyPropertyChanged
    {
        #region Constructors
        public DataListViewModel()
        {
            Data = new Data();
        }
        #endregion

        #region Properties
        public Data Data { get; private set; }
        #endregion

        #region Commands
        private ICommand updateListCommand;
        public ICommand UpdateListCommand => updateListCommand ?? (updateListCommand = new UpdateListCommand(this));
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
