using SmoothCurvedSegment.Utils;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class CatchComponentCommand
        : RelayCommand<MouseButtonEventArgs>
    {
        #region Constructors
        public CatchComponentCommand(ComponentViewModel componentViewModel)
        {
            ComponentViewModel = componentViewModel ?? throw new System.ArgumentNullException(nameof(componentViewModel));
            ExecuteDelegate = CatchComponent;
        }
        #endregion

        #region Properties
        private ComponentViewModel ComponentViewModel { get; }
        #endregion

        #region Private fields
        private void CatchComponent(MouseButtonEventArgs args)
        {
            if (args.Source is FrameworkElement sender)
            {
                var parent = sender.FindParent<Grid>();
                if (parent != null)
                {
                    ComponentViewModel.AnchorPoint = args.GetPosition(parent);
                    sender.CaptureMouse();
                    ComponentViewModel.IsInDrag = true;
                }
                RoutedCommands.SelectComponentCommand.Execute(ComponentViewModel.Model, sender);
            }
            args.Handled = true;
        }
        #endregion
    }
}
