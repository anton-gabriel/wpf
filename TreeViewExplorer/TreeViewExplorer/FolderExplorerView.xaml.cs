using System.Collections.Generic;
using System.Windows;

namespace TreeViewExplorer
{
    /// <summary>
    /// Interaction logic for FolderExplorerView.xaml
    /// </summary>
    public partial class FolderExplorerView : Window
    {
        #region Constructors
        public FolderExplorerView(bool editable = default)
        {
            InitializeComponent();
            Context = new FolderExplorerViewModel(editable);
            DataContext = Context;
        }
        #endregion

        #region Properties
        private FolderExplorerViewModel Context { get; }

        public IEnumerable<string> Files => Context.Files;
        public IEnumerable<string> Directories => Context.Directories;
        public IEnumerable<string> All => Context.All;

        public new string Title
        {
            get => Context.Title;
            set => Context.Title = value;
        }
        public string ExtensionFilter
        {
            get => Context.ExtensionFilter;
            set => Context.ExtensionFilter = value;
        }

        public string RootDirectory
        {
            get => Context.RootDirectory;
            set => Context.RootDirectory = value;
        }

        public SelectionMode SelectionMode
        {
            get => Context.SelectionMode;
            set => Context.SelectionMode = value;
        }
        #endregion
    }
}
