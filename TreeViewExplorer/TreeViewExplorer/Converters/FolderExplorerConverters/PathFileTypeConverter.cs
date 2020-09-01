using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace TreeViewExplorer.Converters.FolderExplorerConverters
{
    [ValueConversion(typeof(string), typeof(string))]
    internal sealed class PathFileTypeConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string path)
            {
                return Directory.Exists(path) ? "Dir" : File.Exists(path) ? Path.GetExtension(path) : string.Empty;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
