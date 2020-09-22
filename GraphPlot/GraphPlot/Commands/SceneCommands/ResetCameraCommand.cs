using GraphPlot.Utils.Extensions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace GraphPlot.Commands.SceneCommands
{
    internal sealed class ResetCameraCommand
        : RelayCommand<DependencyObject>
    {
        #region Constructors
        public ResetCameraCommand()
        {
            ExecuteDelegate = ResetCamera;
        }
        #endregion

        #region Private methods
        private void ResetCamera(DependencyObject args)
        {
            if (args != null)
            {
                var camera = args.FindChild<Viewport3D>()?.Camera as PerspectiveCamera;
                camera.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation()
                {
                    From = camera.Position,
                    To = new Point3D(0, 2, 5),
                    Duration = new Duration(TimeSpan.FromMilliseconds(300))
                });
                camera.BeginAnimation(ProjectionCamera.LookDirectionProperty, new Vector3DAnimation()
                {
                    From = camera.LookDirection,
                    To = new Vector3D(0, -0.4, -1),
                    Duration = new Duration(TimeSpan.FromMilliseconds(300))
                });
            }
            Trace.WriteLine("Add class for above constants.");
        }
        #endregion
    }
}
