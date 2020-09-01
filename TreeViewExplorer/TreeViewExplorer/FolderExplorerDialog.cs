using System.Collections.Generic;

namespace TreeViewExplorer
{
    public sealed class FolderExplorerDialog
    {
        #region Constructors
        public FolderExplorerDialog(bool editable = default)
        {
            FolderExplorerView = new FolderExplorerView(editable);
        }
        #endregion

        #region Properties
        private FolderExplorerView FolderExplorerView { get; }
        public IEnumerable<string> Files => FolderExplorerView.Files;
        public IEnumerable<string> Directories => FolderExplorerView.Directories;
        public IEnumerable<string> All => FolderExplorerView.All;

        public string Title
        {
            get => FolderExplorerView.Title;
            set => FolderExplorerView.Title = value;
        }
        public string Filter
        {
            get => FolderExplorerView.ExtensionFilter;
            set => FolderExplorerView.ExtensionFilter = value;
        }

        public string RootDirectory
        {
            get => FolderExplorerView.RootDirectory;
            set => FolderExplorerView.RootDirectory = value;
        }

        public SelectionMode SelectionMode
        {
            get => FolderExplorerView.SelectionMode;
            set => FolderExplorerView.SelectionMode = value;
        }
        #endregion

        #region Public methods
        public bool? ShowDialog()
        {
            return FolderExplorerView.ShowDialog();
        }
        public void Show()
        {
            FolderExplorerView.Show();
        }
        #endregion
    }
}
