using System.Windows;
using System.Windows.Controls;

namespace TreeViewExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            FolderExplorerDialog dialog = new FolderExplorerDialog(editable: false)
            {
                RootDirectory = @"D:\TreeViewStructure",
                Filter = @".txt",
                Title = "File explorer",
                SelectionMode = SelectionMode.Files
            };
            dialog.ShowDialog();
            var data = dialog.Files;
        }
    }
}
