using SmoothCurvedSegment.Commands;
using System.Windows;
using System.Windows.Input;

namespace SmoothCurvedSegment.Commands.SelectionCommands
{
    internal sealed class CloseSelectionCommand
        : RelayCommand<MouseButtonEventArgs>
    {
        #region Constructors
        public CloseSelectionCommand(SelectionViewModel selectionViewModel)
        {
            SelectionViewModel = selectionViewModel ?? throw new System.ArgumentNullException(nameof(selectionViewModel));
            ExecuteDelegate = CloseSelection;
        }
        #endregion

        #region Properties
        private SelectionViewModel SelectionViewModel { get; }
        #endregion

        #region Private methods
        private void CloseSelection(MouseButtonEventArgs args)
        {
            if (args.Source is UIElement element)
            {
                element.ReleaseMouseCapture();
                //var anchor = SelectionViewModel.Anchor;
                //var area = SelectionViewModel.Selection;
                //search in component lists and select components that have margin in (anchor + area.toplef, anchor + area.bottomright) area
                SelectionViewModel.Anchor = null;
            }
            args.Handled = true;
        }
        #endregion
    }
}
