using GraphPlot.Utils.Extensions;
using GraphPlot.ViewModel.Contract;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
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
        #endregion

        #region Properties
        private ISceneViewModel SceneViewModel { get; }
        #endregion

        #region Private methods
        private bool CanMoveCamera(KeyEventArgs args)
        {
            return true;
        }
        private void MoveCamera(KeyEventArgs args)
        {
            if (args.Source is DependencyObject source)
            {
                var camera = source.FindChild<Viewport3D>()?.Camera;
                if (Keyboard.IsKeyUp(args.Key))
                {
                    camera.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation() { By = new Point3D(0, 0, 0) });
                }
                else
                {
                    var translation = args.Key switch
                    {
                        var key when key == Key.Up || key == Key.W => new Point3D(0, offset, 0),
                        var key when key == Key.Left || key == Key.A => new Point3D(-offset, 0, 0),
                        var key when key == Key.Down || key == Key.S => new Point3D(0, -offset, 0),
                        var key when key == Key.Right || key == Key.D => new Point3D(offset, 0, 0),
                        _ => new Point3D()
                    };
                    camera.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation()
                    {
                        By = translation,
                        SpeedRatio = 1,
                    }, HandoffBehavior.Compose);
                }
            }
        }
        #endregion
    }
}
