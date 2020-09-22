using GraphPlot.Utils.Extensions;
using GraphPlot.ViewModel.Contract;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace GraphPlot.Commands.SceneCommands
{
    internal sealed class AdvanceCameraCommand
        : RelayCommand<MouseWheelEventArgs>
    {
        #region Constructors
        public AdvanceCameraCommand(ISceneViewModel sceneViewModel)
        {
            SceneViewModel = sceneViewModel ?? throw new System.ArgumentNullException(nameof(sceneViewModel));
            CanExecuteDelegate = CanAdvanceCamera;
            ExecuteDelegate = AdvanceCamera;
        }
        #endregion

        #region Private fields
        private const double offset = 0.1;
        #endregion

        #region Properties
        private ISceneViewModel SceneViewModel { get; }
        #endregion

        #region Private methods
        private bool CanAdvanceCamera(MouseWheelEventArgs args)
        {
            return true;
        }
        private void AdvanceCamera(MouseWheelEventArgs args)
        {
            var position = SceneViewModel.CameraPosition;
            if (args.Source is DependencyObject source)
            {
                var camera = source.FindChild<Viewport3D>()?.Camera;
                if (args.Delta > 0)
                {
                    camera.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation()
                    {
                        By = new Point3D(0, 0, -offset),
                        SpeedRatio = 1,
                    }, HandoffBehavior.Compose);
                }
                else if (args.Delta < 0)
                {
                    camera.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation()
                    {
                        By = new Point3D(0, 0, offset),
                        SpeedRatio = 1,
                    }, HandoffBehavior.Compose);
                }
            }
        }
        #endregion
    }
}
