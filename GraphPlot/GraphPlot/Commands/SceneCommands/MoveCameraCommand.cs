using GraphPlot.ViewModel.Contract;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace GraphPlot.Commands.SceneCommands
{
    internal sealed class MoveCameraCommand
        : RelayCommand<KeyEventArgs>
    {
        #region Constructors
        public MoveCameraCommand(ISceneViewModel sceneViewModel)
        {
            SceneViewModel = sceneViewModel ?? throw new System.ArgumentNullException(nameof(sceneViewModel));
            CanExecuteDelegate = CanMoveCamera;
            ExecuteDelegate = MoveCamera;
        }
        #endregion

        #region Private fields
        private const double offset = 0.1;

        private ISceneViewModel SceneViewModel { get; }
        #endregion

        #region Private methods
        private bool CanMoveCamera(KeyEventArgs args)
        {
            return true;
        }
        private void MoveCamera(KeyEventArgs args)
        {
            SceneViewModel.CameraPosition += args.Key switch
            {
                var key when key == Key.Up || key == Key.W => new Vector3D(0, offset, 0),
                var key when key == Key.Left || key == Key.A => new Vector3D(-offset, 0, 0),
                var key when key == Key.Down || key == Key.S => new Vector3D(0, -offset, 0),
                var key when key == Key.Right || key == Key.D => new Vector3D(offset, 0, 0),
                _ => new Vector3D()
            };
        }
        #endregion
    }
}
