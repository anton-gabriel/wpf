using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace GraphPlot.Converters
{
    internal sealed class MoveCameraParameterConverter
        : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return/* (values[0] as PerspectiveCamera, (Key)values[1]);*/ values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
