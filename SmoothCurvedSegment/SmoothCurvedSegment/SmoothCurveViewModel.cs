using SmoothCurvedSegment.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SmoothCurvedSegment
{
    internal sealed class SmoothCurveViewModel
        : INotifyPropertyChanged
    {
        #region Constructors
        public SmoothCurveViewModel()
        {
            CalculatePoints(new Point(10, 110), new Point(700, 400));
        }
        #endregion

        #region Private fields
        private string fps;
        private (Point, Point, Point, Point) points;
        private IList<Point> pointsCollection;
        #endregion

        #region Properties
        public (Point, Point, Point, Point) Points
        {
            get => points;
            private set
            {
                points = value;
                OnPropertyChanged();
            }
        }
        public IList<Point> PointsCollection
        {
            get => pointsCollection;
            set
            {
                pointsCollection = value;
                OnPropertyChanged();
            }
        }
        public string Fps
        {
            get => fps;
            set
            {
                fps = value;
                OnPropertyChanged();
            }
        }
        public Geometry Dots { get; private set; }
        #endregion

        #region Commands
        private ICommand drawCommand;
        public ICommand DrawCommand => drawCommand ?? (drawCommand = new DrawCommand(this));
        #endregion

        #region Private methods
        private void CalculatePoints(Point source, Point target)
        {
            Vector start = (Vector)source;
            Vector third = (Vector)target;
            Vector middle = third.Lerp(start, factor: 0.5);
            Vector first = new Vector(third.X, start.Y);
            Vector second = new Vector(start.X, third.Y);

            Dots = new GeometryGroup()
            {
                Children = new GeometryCollection()
                {
                    new EllipseGeometry((Point)start, radiusX: 1, radiusY: 1),
                    new EllipseGeometry((Point)first, radiusX: 1, radiusY: 1),
                    new EllipseGeometry((Point)second, radiusX: 1, radiusY: 1),
                    new EllipseGeometry((Point)third, radiusX: 1, radiusY: 1),
                    new EllipseGeometry((Point)middle, radiusX: 1, radiusY: 1)
                }
            };

            Points = ((Point)start, (Point)first, (Point)second, (Point)third);
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
