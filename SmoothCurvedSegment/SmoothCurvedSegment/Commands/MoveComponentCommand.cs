using SmoothCurvedSegment.Utils;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class MoveComponentCommand
        : RelayCommand<MouseEventArgs>
    {
        #region Constructors
        public MoveComponentCommand(ComponentViewModel componentViewModel)
        {
            ComponentViewModel = componentViewModel ?? throw new System.ArgumentNullException(nameof(componentViewModel));
            ExecuteDelegate = MoveComponent;
        }
        #endregion

        #region Properties
        private ComponentViewModel ComponentViewModel { get; }
        #endregion

        #region Private fields
        private void MoveComponent(MouseEventArgs args)
        {
            if (args.Source is FrameworkElement sender)
            {
                if ((args.LeftButton == MouseButtonState.Pressed) && ComponentViewModel.IsInDrag)
                {
                    var parent = sender.FindParent<Grid>();
                    if (parent != null)
                    {
                        var position = args.GetPosition(parent);
                        double xOffset = position.X - ComponentViewModel.AnchorPoint.X;
                        double yOffset = position.Y - ComponentViewModel.AnchorPoint.Y;
                        var margin = ComponentViewModel.Model.Margin;
                        if ((margin.Left + xOffset > 0) &&
                            (margin.Top + yOffset > 0))
                        {
                            ComponentViewModel.Model.Margin = new Thickness(margin.Left + xOffset, margin.Top + yOffset, margin.Right, margin.Bottom);
                            ComponentViewModel.AnchorPoint = position;
                        }
                    }
                }
            }
            args.Handled = true;
        }
        #endregion
    }
}
