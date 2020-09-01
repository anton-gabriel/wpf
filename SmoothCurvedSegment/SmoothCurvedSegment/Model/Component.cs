using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SmoothCurvedSegment.Model
{
    internal sealed class Component
        : INotifyPropertyChanged
    {
        #region Private fields
        private double width;
        private double height;
        private Thickness thickness;
        #endregion

        #region Properties
        public Thickness Margin
        {
            get => thickness;
            set
            {
                thickness = value;
                OnPropertyChanged();
            }
        }
        public double Width
        {
            get => width;
            set
            {
                width = value;
                OnPropertyChanged();
            }
        }
        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged();
            }
        }
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
