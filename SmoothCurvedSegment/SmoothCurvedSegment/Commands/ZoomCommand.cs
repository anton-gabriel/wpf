using System.Windows.Input;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class ZoomCommand
        : RelayCommand<MouseWheelEventArgs>
    {
        #region Constructors
        public ZoomCommand(CanvasScaleViewModel canvasScaleViewModel)
        {
            CanvasScaleViewModel = canvasScaleViewModel ?? throw new System.ArgumentNullException(nameof(canvasScaleViewModel));
            ExecuteDelegate = Zoom;
        }
        #endregion

        #region Private fields
        private double zoomFactor = 1;// AssemblerConstants.CanvasInitialZoom;
        #endregion

        #region Properties
        private CanvasScaleViewModel CanvasScaleViewModel { get; }
        private double ZoomFactor
        {
            get => zoomFactor;
            set
            {
                if ((value > 0.5/* AssemblerConstants.CanvasMinZoom*/) &&
                    (value < 2.0/*AssemblerConstants.CanvasMaxZoom*/))
                {
                    zoomFactor = value;
                }
            }
        }
        #endregion

        #region Private methods
        private void Zoom(MouseWheelEventArgs args)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (args.Delta > 0)
                {
                    Zoom(factor: 0.1);
                }
                else if (args.Delta < 0)
                {
                    Zoom(factor: -0.1);
                }
                args.Handled = true;
            }
        }

        private void Zoom(double factor)
        {
            ZoomFactor += factor;
            CanvasScaleViewModel.ScaleTransform.ScaleX = ZoomFactor;
            CanvasScaleViewModel.ScaleTransform.ScaleY = ZoomFactor;
            CanvasScaleViewModel.OnPropertyChanged(name: nameof(CanvasScaleViewModel.ScaleTransform));
        }
        #endregion
    }
}
