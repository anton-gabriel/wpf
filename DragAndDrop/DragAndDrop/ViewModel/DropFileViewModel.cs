using DragAndDrop.Commands;
using System.Windows.Input;

namespace DragAndDrop.ViewModel
{
    internal sealed class DropFileViewModel
        : NotifyPropertyChanged
    {
        #region Constructors
        public DropFileViewModel()
        {

        }
        #endregion

        #region Private fields

        #endregion

        #region Properties

        #endregion

        #region Commands
        private ICommand dropFilleCommand;
        public ICommand DropFileCommand => dropFilleCommand ?? (dropFilleCommand = new DropFileCommand());


        private ICommand pasteCommand;
        public ICommand PasteCommand => pasteCommand ?? (pasteCommand = new PasteCommand());
        #endregion
    }
}
