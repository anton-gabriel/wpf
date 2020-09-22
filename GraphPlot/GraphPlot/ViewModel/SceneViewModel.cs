using GraphPlot.Commands;
using GraphPlot.Commands.SceneCommands;
using GraphPlot.ViewModel.Contract;
using System.Windows.Media.Media3D;

namespace GraphPlot.ViewModel
{
    internal sealed class SceneViewModel
        : BaseViewModel, ISceneViewModel
    {
        #region Constructors
        public SceneViewModel()
        {

        }
        #endregion

        #region Private fields

        #endregion

        #region Properties

        private Point3D cameraPosition = new Point3D(0, 2, 5);
        public Point3D CameraPosition
        {
            get => cameraPosition;
            set
            {
                cameraPosition = value;
                OnPropertyChanged();
            }
        }

        private Vector3D cameraLookDirection = new Vector3D(0, -0.4, -1);
        public Vector3D CameraLookDirection
        {
            get => cameraLookDirection;
            set
            {
                cameraLookDirection = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private IRaisableCommand moveCameraCommand;
        public IRaisableCommand MoveCameraCommand => moveCameraCommand ??= new MoveCameraCommand(this);

        private IRaisableCommand rotateCameraCommand;
        public IRaisableCommand RotateCameraCommand => rotateCameraCommand ??= new RotateCameraCommand(this);

        private IRaisableCommand advanceCameraCommand;
        public IRaisableCommand AdvanceCameraCommand => advanceCameraCommand ??= new AdvanceCameraCommand(this);
        #endregion
    }
}
