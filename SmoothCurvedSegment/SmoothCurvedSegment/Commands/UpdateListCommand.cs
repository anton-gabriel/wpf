using System;
using System.Linq;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class UpdateListCommand
        : RelayCommand<object>
    {
        #region Constructors
        public UpdateListCommand(DataListViewModel dataListViewModel)
        {
            DataListViewModel = dataListViewModel ?? throw new ArgumentNullException(nameof(dataListViewModel));
            ExecuteDelegate = param => UpdateList();
        }
        #endregion

        #region Properties
        private DataListViewModel DataListViewModel { get; }
        #endregion

        #region Private methods

        private void UpdateList()
        {
            DataListViewModel.Data.Ports.FirstOrDefault().Name = "Used";
        }
        #endregion
    }
}
