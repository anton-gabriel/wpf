using GraphPlot.Utils.Extensions;
using GraphPlot.ViewModel.Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace GraphPlot.Commands.SceneCommands
{
    internal sealed class RotateCameraCommand
        : RelayCommand<MouseEventArgs>
    {
        #region Constructors
        public RotateCameraCommand(ISceneViewModel sceneViewModel)
        {
            SceneViewModel = sceneViewModel ?? throw new ArgumentNullException(nameof(sceneViewModel));
            CanExecuteDelegate = CanRotateCamera;
            ExecuteDelegate = RotateCamera;
        }
        #endregion

        #region Properties
        private Point? LastPosition { get; set; }
        private ISceneViewModel SceneViewModel { get; }
        #endregion

        #region Private methods
        private bool CanRotateCamera(MouseEventArgs args)
        {
            return true;
        }
        private void RotateCamera(MouseEventArgs args)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (args.Source is FrameworkElement source)
                {
                    var position = args.GetPosition(source);
                    if (LastPosition.HasValue)
                    {
                        Vector3D first = TransformPoint(position, source.ActualWidth, source.ActualHeight);
                        first.Normalize();
                        Vector3D second = TransformPoint(LastPosition.Value, source.ActualWidth, source.ActualHeight);
                        second.Normalize();
                        var diff = first - second;
                        SceneViewModel.CameraLookDirection += new Vector3D(diff.X, diff.Y, diff.Z);
                    }
                    LastPosition = position;
                }
            }
            else
            {
                LastPosition = null;
            }
        }

        private static Vector3D TransformPoint(Point position, double width, double height)
        {
            double x = (position.X / (width / 2)) - 1;
            double y = 1 - (position.Y / (height / 2));
            double z = 1 - Math.Pow(x, 2) - Math.Pow(y, 2);
            z = z > 0 ? Math.Sqrt(z) : 0;
            return new Vector3D(x, y, z);
        }
        #endregion
    }
}
