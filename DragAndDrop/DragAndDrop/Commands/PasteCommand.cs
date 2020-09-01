using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DragAndDrop.Commands
{
    internal sealed class PasteCommand
        : RelayCommand<Panel>
    {
        #region Constructors
        public PasteCommand()
        {
            ExecuteDelegate = AddPasteHandler;
        }
        #endregion

        #region Private fields
        private void AddPasteHandler(Panel args)
        {
            var data = Clipboard.GetDataObject();
            if (data.GetDataPresent(DataFormats.Bitmap))
            {
                var image = data.GetData(DataFormats.Bitmap) as BitmapSource;
                if (args != null)
                {
                    args.Children.Add(new Image() { Source = image });
                }
            }
        }
        #endregion
    }
}
