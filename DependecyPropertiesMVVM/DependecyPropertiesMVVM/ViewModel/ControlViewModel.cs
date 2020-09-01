using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DependecyPropertiesMVVM.ViewModel
{
    internal sealed class ControlViewModel
        : INotifyPropertyChanged
    {
        #region Constructors
        public ControlViewModel()
        {
            TextFromControlViewModel = nameof(TextFromControlViewModel);
        }
        #endregion

        #region Properties
        public string TextFromControlViewModel { get;  set; }
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
