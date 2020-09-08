using SmoothCurvedSegment.Commands;
using System.Windows;
using System.Windows.Input;

namespace SmoothCurvedSegment.Commands.SelectionCommands
{
    internal sealed class StartSelectionCommand
        : RelayCommand<MouseButtonEventArgs>
    {
        #region Constructors
        public StartSelectionCommand(SelectionViewModel selectionViewModel)
        {
            SelectionViewModel = selectionViewModel ?? throw new System.ArgumentNullException(nameof(selectionViewModel));
            ExecuteDelegate = StartSelection;
        }

        #endregion

        #region Properties
        private SelectionViewModel SelectionViewModel { get; }
        #endregion

        #region Private methods
        private void StartSelection(MouseButtonEventArgs args)
        {
            if (args.Source is UIElement element)
            {
                SelectionViewModel.Selection = new Rect();
                SelectionViewModel.ZIndex = -1;
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    SelectionViewModel.ZIndex = 10;
                    element.CaptureMouse();
                    SelectionViewModel.Anchor = args.GetPosition(element);
                }
            }
            args.Handled = true;
        }
        #endregion
    }
}
