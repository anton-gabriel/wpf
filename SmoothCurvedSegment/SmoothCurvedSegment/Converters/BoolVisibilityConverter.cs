using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmoothCurvedSegment.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    internal sealed class BoolVisibilityConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool visible) ? (visible ? Visibility.Visible : Visibility.Collapsed) : (object)null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
