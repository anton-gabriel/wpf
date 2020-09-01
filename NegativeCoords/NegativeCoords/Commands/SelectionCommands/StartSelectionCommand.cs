using SmoothCurvedSegment.Commands;
using System.Windows;
using System.Windows.Input;

namespace NegativeCoords.Commands.SelectionCommands
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
                element.CaptureMouse();
                SelectionViewModel.Anchor = args.GetPosition(element);
            }
        }
        #endregion
    }
}
