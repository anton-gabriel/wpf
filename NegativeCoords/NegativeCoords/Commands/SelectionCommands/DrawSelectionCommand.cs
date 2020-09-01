using SmoothCurvedSegment.Commands;
using System.Windows;
using System.Windows.Input;

namespace NegativeCoords.Commands.SelectionCommands
{
    internal sealed class DrawSelectionCommand
        : RelayCommand<MouseEventArgs>
    {
        #region Constructors
        public DrawSelectionCommand(SelectionViewModel selectionViewModel)
        {
            SelectionViewModel = selectionViewModel ?? throw new System.ArgumentNullException(nameof(selectionViewModel));
            ExecuteDelegate = DrawSelection;
        }
        #endregion

        #region Properties
        private SelectionViewModel SelectionViewModel { get; }
        #endregion

        #region Private methods
        private void DrawSelection(MouseEventArgs args)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed
             && args.Source is IInputElement element)
            {
                var anchor = SelectionViewModel.Anchor;
                if (anchor.HasValue)
                {
                    SelectionViewModel.Selection = new Rect(anchor.Value, args.GetPosition(element));
                }
            }
        }
        #endregion
    }
}
