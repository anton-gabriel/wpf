using SmoothCurvedSegment.Commands;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NegativeCoords.Commands.SelectionCommands
{

    internal sealed class OpenCommandsMenuCommand
        : RelayCommand<FrameworkElement>
    {
        #region Constructors
        public OpenCommandsMenuCommand(SelectionViewModel selectionViewModel)
        {
            SelectionViewModel = selectionViewModel ?? throw new ArgumentNullException(nameof(selectionViewModel));
            CanExecuteDelegate = CanOpenCommandMenu;
            ExecuteDelegate = OpenCommandMenu;
        }
        #endregion

        #region Properties
        private SelectionViewModel SelectionViewModel { get; }
        #endregion

        #region Private methods
        private bool CanOpenCommandMenu(FrameworkElement args)
        {
            return args != null && !SelectionViewModel.Selection.Size.IsEmpty;
        }
        private void OpenCommandMenu(FrameworkElement args)
        {
            if (SelectionViewModel.Anchor != null &&  args != null)
            {
                if(args.ContextMenu != null && SelectionViewModel.Selection.Width > 10)
                {
                    args.ContextMenu.IsOpen = true;
                }
            }
        }
        #endregion
    }
}
