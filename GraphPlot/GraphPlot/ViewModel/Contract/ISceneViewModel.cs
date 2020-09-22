using GraphPlot.Commands;
using System.Windows.Media.Media3D;

namespace GraphPlot.ViewModel.Contract
{
    public interface ISceneViewModel
    {
        #region Properties
        Point3D CameraPosition { get; set; }
        Vector3D CameraLookDirection { get; set; }
        #endregion

        #region Commands
        IRaisableCommand MoveCameraCommand { get; }
        IRaisableCommand AdvanceCameraCommand { get; }
        IRaisableCommand RotateCameraCommand { get; }
        IRaisableCommand ResetCameraCommand { get; }
        #endregion
    }
}
