using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SmoothCurvedSegment.Converters
{
    [ValueConversion(typeof(IList<Point>), typeof(Geometry))]
    internal sealed class BezierCurveCollectionGeometryConverter
        : IValueConverter
    {
        private const int MinSize = 4;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is null) && value is IList<Point> data)
            {
                if (data.Count() < MinSize)
                {
                    return null;
                }

                ICollection<PathSegment> segments = new LinkedList<PathSegment>();
                for (int index = 0; index <= data.Count - MinSize; index += 1)
                {
                    segments.Add(new BezierSegment(point1: data[index + 1], point2: data[index + 2], point3: data[index + 3], true));

                }
                return new PathGeometry()
                {
                    Figures = new PathFigureCollection()
                    {
                        new PathFigure()
                        {
                            StartPoint = data.First(),
                            Segments = new PathSegmentCollection(segments)
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
