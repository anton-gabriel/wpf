using NegativeCoords.Commands.SelectionCommands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace NegativeCoords
{
    internal sealed class SelectionViewModel
        : INotifyPropertyChanged
    {
        #region Constructors
        public SelectionViewModel()
        {

        }
        #endregion

        #region Properties
        public Point? Anchor { get; set; }
        public Rect Selection
        {
            get => selection;
            set
            {
                selection = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private ICommand startSelectionCommand;
        public ICommand StartSelectionCommand => startSelectionCommand ?? (startSelectionCommand = new StartSelectionCommand(this));

        private ICommand drawSelectionCommand;
        public ICommand DrawSelectionCommand => drawSelectionCommand ?? (drawSelectionCommand = new DrawSelectionCommand(this));

        private ICommand closeSelectionCommand;
        private Rect selection;

        public ICommand CloseSelectionCommand => closeSelectionCommand ?? (closeSelectionCommand = new CloseSelectionCommand(this));
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
