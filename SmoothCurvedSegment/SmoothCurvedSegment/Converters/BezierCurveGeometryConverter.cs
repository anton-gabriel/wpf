using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SmoothCurvedSegment.Converters
{
    [ValueConversion(typeof((Point, Point, Point, Point)), typeof(Geometry))]
    internal sealed class BezierCurveGeometryConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is null) && value is ValueTuple<Point, Point, Point, Point> data)
            {
                var (start, first, second, third) = data;
                return new PathGeometry()
                {
                    Figures = new PathFigureCollection()
                    {
                        new PathFigure()
                        {
                            StartPoint = start,
                            Segments = new PathSegmentCollection()
                            {
                                new BezierSegment(first, second, third, true)
                            }
                        }
                    }
                };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
