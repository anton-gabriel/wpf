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
        private ISceneViewModel SceneViewModel { get; }
        #endregion

        #region Private methods
        private bool CanAdvanceCamera(MouseWheelEventArgs args)
        {
            return true;
        }
        private void AdvanceCamera(MouseWheelEventArgs args)
        {
            //Calculate frequency and adapt offset
            var direction = SceneViewModel.CameraLookDirection;
            if (args.Delta > 0)
            {
                SceneViewModel.CameraPosition += new Vector3D(direction.X * offset, direction.Y * offset, direction.Z * offset);
            }
            else if (args.Delta < 0)
            {
                SceneViewModel.CameraPosition -= new Vector3D(direction.X * offset, direction.Y * offset, direction.Z * offset);
            }
        }
        #endregion
    }
}
