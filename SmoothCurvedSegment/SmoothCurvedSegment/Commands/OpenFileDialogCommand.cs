using Microsoft.Win32;
using SmoothCurvedSegment.Utils;
using System.Linq;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class OpenFileDialogCommand
        : RelayCommand<object>
    {
        #region Constructors
        public OpenFileDialogCommand(CanvasScaleViewModel canvasScaleViewModel)
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
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.FileNames.ToList().ForEach(file => file.Dump());
            }
        }
        #endregion
    }
}
