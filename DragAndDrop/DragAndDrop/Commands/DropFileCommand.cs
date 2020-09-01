using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DragAndDrop.Commands
{
    internal sealed class DropFileCommand
        : RelayCommand<DragEventArgs>
    {
        #region Constructors
        public DropFileCommand()
        {
            ExecuteDelegate = DropFile;
        }
        #endregion

        #region Private fields
        private void DropFile(DragEventArgs args)
        {
            if (args.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = args.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;
                if (args.Source is Panel panel && panel != null)
                {
                    foreach (var file in files)
                    {
                        panel.Children.Add(new Label() { Content = file, Margin = new Thickness(5) });
                    }
                }

            }

            if (args.Data.GetDataPresent(DataFormats.Text))
            {
                var text = args.Data.GetData(DataFormats.Text) as string;
                if (args.Source is Panel panel && panel != null)
                {
                    panel.Children.Add(new Label() { Content = text, Margin = new Thickness(5), Foreground = Brushes.CornflowerBlue });
                }
            }
        }
        #endregion
    }
}
