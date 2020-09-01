using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TreeViewExplorer.Converters.FolderExplorerConverters
{
    [ValueConversion(typeof(string), typeof(ImageSource))]
    internal sealed class PathIconConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string path && !string.IsNullOrWhiteSpace(path))
                {
                    if (Directory.Exists(path))
                    {
                        return DirectoryIcon;
                    }
                    using (System.Drawing.Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(path))
                    {
                        return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(sysicon.Handle, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #region Properties
        public DrawingImage DirectoryIcon { get; set; }
        #endregion

    }
}
