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
            if (args.Delta > 0)
            {
                SceneViewModel.CameraPosition = new Point3D(position.X, position.Y, position.Z - offset);
            }
            else if (args.Delta < 0)
            {
                SceneViewModel.CameraPosition = new Point3D(position.X, position.Y, position.Z + offset);
            }
            System.Console.WriteLine(SceneViewModel.CameraPosition);
        }
        #endregion
    }
}
