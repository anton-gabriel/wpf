using SmoothCurvedSegment.Commands;
using System;
using System.Windows;

namespace NegativeCoords.Commands.SelectionCommands
{
    internal sealed class CloseCommandsMenuCommand
        : RelayCommand<RoutedEventArgs>
    {
        #region Constructors
        public CloseCommandsMenuCommand(SelectionViewModel selectionViewModel)
        {
            SelectionViewModel = selectionViewModel ?? throw new ArgumentNullException(nameof(selectionViewModel));
            ExecuteDelegate = CloseCommandsMenu;
        }
        #endregion

        #region Properties
        private SelectionViewModel SelectionViewModel { get; }
        #endregion

        #region Private methods
        private void CloseCommandsMenu(RoutedEventArgs args)
        {
            if (args != null)
            {
                SelectionViewModel.Selection = new Rect();
                SelectionViewModel.Anchor = null;
                args.Handled = true;
            }
        }
        #endregion
    }
}
