using GraphPlot.Utils.Constants;
using GraphPlot.Utils.Extensions;
using GraphPlot.ViewModel.Contract;
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
        public ResetCameraCommand(ISceneViewModel sceneViewModel)
        {
            SceneViewModel = sceneViewModel ?? throw new ArgumentNullException(nameof(sceneViewModel));
            ExecuteDelegate = ResetCamera;
        }
        #endregion

        #region Properties
        private ISceneViewModel SceneViewModel { get; }
        #endregion

        #region Private methods
        private void ResetCamera(DependencyObject args)
        {
            if (args != null)
            {
                var camera = args.FindChild<Viewport3D>()?.Camera as PerspectiveCamera;
                var position = new Point3DAnimation()
                {
                    From = camera.Position,
                    To = SceneConstants.DefaultCameraPosition,
                    Duration = new Duration(TimeSpan.FromMilliseconds(300))
                }.CreateClock();
                position.Completed += (sender, args) =>
                {
                    camera.BeginAnimation(ProjectionCamera.PositionProperty, null);
                    SceneViewModel.CameraPosition = SceneConstants.DefaultCameraPosition;
                };
                camera.ApplyAnimationClock(ProjectionCamera.PositionProperty, position);
                var direction = new Vector3DAnimation()
                {
                    From = camera.LookDirection,
                    To = SceneConstants.DefaultCameraDirection,
                    Duration = new Duration(TimeSpan.FromMilliseconds(300))
                }.CreateClock();
                direction.Completed += (sender, args) =>
                {
                    camera.BeginAnimation(ProjectionCamera.LookDirectionProperty, null);
                    SceneViewModel.CameraLookDirection = SceneConstants.DefaultCameraDirection;
                };
                camera.ApplyAnimationClock(ProjectionCamera.LookDirectionProperty, direction);
            }
        }
        #endregion
    }
}
