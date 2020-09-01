using System.Windows;

namespace TreeViewExplorer.Commands.FolderExplorerCommands
{
    internal sealed class AddCommand
        : RelayCommand<Window>
    {
        #region Constructors
        public AddCommand()
        {
            ExecuteDelegate = Select;
        }
        #endregion

        #region Private methods
        private void Select(Window window)
        {
            window.Close();
        }
        #endregion
    }
}
