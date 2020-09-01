using SmoothCurvedSegment.Utils;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class ReleaseComponentCommand
        : RelayCommand<MouseButtonEventArgs>
    {
        #region Constructors
        public ReleaseComponentCommand(ComponentViewModel componentViewModel)
        {
            ComponentViewModel = componentViewModel ?? throw new System.ArgumentNullException(nameof(componentViewModel));
            ExecuteDelegate = ReleaseComponent;
        }
        #endregion

        #region Properties
        private ComponentViewModel ComponentViewModel { get; }
        #endregion

        #region Private fields
        private void ReleaseComponent(MouseButtonEventArgs args)
        {
            if (ComponentViewModel.IsInDrag)
            {
                if (args.Source is FrameworkElement element)
                {
                    element.ReleaseMouseCapture();
                }
                ComponentViewModel.IsInDrag = false;
            }
            args.Handled = true;
        }
        #endregion
    }
}
