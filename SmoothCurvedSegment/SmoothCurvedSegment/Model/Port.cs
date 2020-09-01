using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmoothCurvedSegment.Model
{
    internal sealed class Port
        : INotifyPropertyChanged
    {
        #region Constructors
        public Port()
        {
            Name = string.Empty;
        }
        #endregion

        #region Private fields
        private string name;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Used));
            }
        }
        public bool Used => !Name.Contains("Used");
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
