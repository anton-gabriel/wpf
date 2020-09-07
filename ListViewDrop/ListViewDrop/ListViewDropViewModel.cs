using System.Collections.ObjectModel;

namespace ListViewDrop
{
    internal sealed class ListViewDropViewModel
        : NotifyPropertyChanged
    {
        #region Constructors
        public ListViewDropViewModel()
        {
            Paths = new ObservableCollection<string>()
            {
                "Path1",
                "Path2"
            };
        }
        #endregion

        #region Private fields

        #endregion

        #region Properties
        public ObservableCollection<string> Paths { get; private set; }
        #endregion

        #region Commands

        #endregion
    }
}
