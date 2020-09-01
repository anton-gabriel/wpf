using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TreeViewExplorer.Commands.FolderExplorerCommands
{
    internal sealed class BackCommand
        : RelayCommand<FrameworkElement>
    {
        #region Constructors
        public BackCommand()
        {
            ExecuteDelegate = Forward;
        }

        #endregion

        #region Private methods
        private void Forward(FrameworkElement args)
        {
            if (args is TextBox textBox)
            {
                string path = textBox.Text;
                if (!string.IsNullOrWhiteSpace(path))
                {
                    textBox.Text = Path.GetFullPath(Path.Combine(path, @"..\"));
                }
            }
        }
        #endregion
    }
}
