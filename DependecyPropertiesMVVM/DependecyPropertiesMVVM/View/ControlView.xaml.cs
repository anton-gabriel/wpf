using DependecyPropertiesMVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace DependecyPropertiesMVVM.View
{
    /// <summary>
    /// Interaction logic for ControlView.xaml
    /// </summary>
    public partial class ControlView : UserControl
    {
        #region Dependency properties
        public static readonly DependencyProperty TextInControlProperty =
           DependencyProperty.Register(nameof(TextInControl), typeof(string), typeof(ControlView));
        #endregion

        #region Properties
        public string TextInControl
        {
            get => ViewModel.TextFromControlViewModel;
            set => ViewModel.TextFromControlViewModel = value;
        }
        #endregion

        private ControlViewModel ViewModel { get; } = new ControlViewModel();

        public ControlView()
        {
            InitializeComponent();
        }
    }
}
