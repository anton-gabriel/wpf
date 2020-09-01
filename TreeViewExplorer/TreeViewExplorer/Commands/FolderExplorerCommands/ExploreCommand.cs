using System.IO;
using System.Windows.Input;

namespace TreeViewExplorer.Commands.FolderExplorerCommands
{
    internal sealed class ExploreCommand
        : RelayCommand<MouseButtonEventArgs>
    {
        #region Constructors
        public ExploreCommand(FolderExplorerViewModel folderExplorerViewModel)
        {
            FolderExplorerViewModel = folderExplorerViewModel ?? throw new System.ArgumentNullException(nameof(folderExplorerViewModel));
            ExecuteDelegate = param => Explore();
        }
        #endregion

        #region Properties
        private FolderExplorerViewModel FolderExplorerViewModel { get; }
        #endregion

        #region Private methods
        private void Explore()
        {
            if (FolderExplorerViewModel.SelectedItem != null)
            {
                var path = FolderExplorerViewModel.SelectedItem.FullName;
                if (Directory.Exists(path))
                {
                    FolderExplorerViewModel.RootDirectory = path;
                }
            }
        }
        #endregion
    }
}
