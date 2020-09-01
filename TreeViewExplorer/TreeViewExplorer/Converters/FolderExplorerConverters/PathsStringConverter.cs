using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Data;

namespace TreeViewExplorer.Converters.FolderExplorerConverters
{
    [ValueConversion(typeof(IEnumerable<string>), typeof(string))]
    internal sealed class PathsStringConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<string> paths)
            {
                return string.Join(separator: ", ", paths.Select(path => Path.GetFileName(path)));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
