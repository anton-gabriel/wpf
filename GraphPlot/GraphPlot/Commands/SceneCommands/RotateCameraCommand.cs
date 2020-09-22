using GraphPlot.ViewModel.Contract;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace GraphPlot.Commands.SceneCommands
{
    internal sealed class RotateCameraCommand
        : RelayCommand<MouseEventArgs>
    {
        #region Constructors
        public RotateCameraCommand(ISceneViewModel sceneViewModel)
        {
            SceneViewModel = sceneViewModel ?? throw new System.ArgumentNullException(nameof(sceneViewModel));
            CanExecuteDelegate = CanRotateCamera;
            ExecuteDelegate = RotateCamera;
        }
        #endregion

        #region Properties
        private ISceneViewModel SceneViewModel { get; }
        private Point? LastPosition { get; set; }
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
                var position = args.GetPosition(args.Source as IInputElement);
                if (LastPosition.HasValue)
                {
                    var offset = LastPosition.Value - position;
                    var direction = SceneViewModel.CameraLookDirection;
                    SceneViewModel.CameraLookDirection = new Vector3D(direction.X + offset.X, direction.Y + offset.Y, direction.Z );
                }
                LastPosition = position;
            }
        }
        #endregion
    }
}
