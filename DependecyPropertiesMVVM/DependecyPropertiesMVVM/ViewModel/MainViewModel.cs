using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DependecyPropertiesMVVM.ViewModel
{
    internal sealed class MainViewModel
        : INotifyPropertyChanged
    {
        #region Constructors
        public MainViewModel()
        {
            TextFromMainViewModel = nameof(TextFromMainViewModel);
        }
        #endregion

        #region Properties
        public string TextFromMainViewModel { get; private set; }
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
