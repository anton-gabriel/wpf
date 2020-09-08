using SmoothCurvedSegment.Commands.SelectionCommands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace SmoothCurvedSegment
{
    internal sealed class SelectionViewModel
         : INotifyPropertyChanged
    {
        #region Constructors
        public SelectionViewModel()
        {

        }
        #endregion

        #region Private fields
        private Rect selection;
        #endregion

        #region Properties

        private int zIndex;
        public int ZIndex
        {
            get => zIndex;
            set
            {
                zIndex = value;
                OnPropertyChanged();
            }
        }
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
        public ICommand CloseSelectionCommand => closeSelectionCommand ?? (closeSelectionCommand = new CloseSelectionCommand(this));

        private ICommand openCommandsMenuCommand;
        public ICommand OpenCommandsMenuCommand => openCommandsMenuCommand ?? (openCommandsMenuCommand = new OpenCommandsMenuCommand(this));

        private ICommand closeCommandsMenuCommand;
        public ICommand CloseCommandsMenuCommand => closeCommandsMenuCommand ?? (closeCommandsMenuCommand = new CloseCommandsMenuCommand(this));
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
