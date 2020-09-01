using Microsoft.WindowsAPICodePack.Dialogs;
using SmoothCurvedSegment.Utils;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class OpenFolderDialog
       : RelayCommand<object>
    {
        #region Constructors
        public OpenFolderDialog(CanvasScaleViewModel canvasScaleViewModel)
        {
            CanvasScaleViewModel = canvasScaleViewModel;
            ExecuteDelegate = param => OpenDialog();
        }
        #endregion

        #region Properties
        private CanvasScaleViewModel CanvasScaleViewModel { get; }
        #endregion

        #region Private fields
        private void OpenDialog()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Multiselect = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                dialog.FileNames.Dump();
            }
        }
        #endregion
    }
}
