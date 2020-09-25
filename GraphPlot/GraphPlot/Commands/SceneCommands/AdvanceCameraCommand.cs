using GraphPlot.ViewModel.Contract;
using System.Windows.Input;
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
        private const double factor = 0.1;
        #endregion

        #region Properties
        private ISceneViewModel SceneViewModel { get; }
        #endregion

        #region Private methods
        private bool CanAdvanceCamera(MouseWheelEventArgs args)
        {
            return args.Delta < 0 ?
                 (SceneViewModel.CameraPosition.X < double.MaxValue &&
                  SceneViewModel.CameraPosition.Y < double.MaxValue &&
                  SceneViewModel.CameraPosition.Z < double.MaxValue)
                : SceneViewModel.CameraPosition.Y > factor * SceneViewModel.CameraLookDirection.Y;
        }
        private void AdvanceCamera(MouseWheelEventArgs args)
        {
            //direction: Consider camera direction when advance the camera position
            //position: Factor d.p. with position (if close to zero decrease slowly)
            var direction = SceneViewModel.CameraLookDirection;
            var position = SceneViewModel.CameraPosition;
            if (args.Delta > 0)
            {
                SceneViewModel.CameraPosition += new Vector3D(direction.X * factor, direction.Y * factor, direction.Z * factor);
            }
            else if (args.Delta < 0)
            {
                SceneViewModel.CameraPosition -= new Vector3D(direction.X * factor, direction.Y * factor, direction.Z * factor);
            }
        }
        #endregion
    }
}
