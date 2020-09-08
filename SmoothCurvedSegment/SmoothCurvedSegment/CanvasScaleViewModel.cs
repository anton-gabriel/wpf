using SmoothCurvedSegment.Commands;
using SmoothCurvedSegment.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SmoothCurvedSegment
{
    internal sealed class CanvasScaleViewModel
         : INotifyPropertyChanged
    {
        #region Constructors
        public CanvasScaleViewModel()
        {
            Components = new ObservableCollection<ComponentViewModel>
            {
                new ComponentViewModel(new Model.Component()
                {
                    Margin = new Thickness(30,20,0,0),
                    Height = 10,
                    Width = 10,
                })
                {
                    Color = new BrushConverter().ConvertFrom("#f0f0f0") as SolidColorBrush,
                    ZIndex = 2,
                },
                new ComponentViewModel(new Model.Component()
                {
                    Margin = new Thickness(50,20,0,0),
                    Height = 10,
                    Width = 10
                })
                {
                    Color = new BrushConverter().ConvertFrom("#0f0f0f") as SolidColorBrush,
                    ZIndex = 1
                }
            };
            ScaleTransform = new ScaleTransform();
            SelectionViewModel = new SelectionViewModel();
        }
        #endregion

        #region Properties
        public SelectionViewModel SelectionViewModel { get; private set; }
        public ObservableCollection<ComponentViewModel> Components { get; private set; }
        public ScaleTransform ScaleTransform { get; set; }
        public IDictionary<string, string> Properties { get; private set; } = new Dictionary<string, string>()
        {
            ["Name"] = "Test",
            ["Id"] = "123435",
            ["Data"] = "TestData"
        };

        #endregion

        #region Commands
        private ICommand zoomCommand;
        public ICommand ZoomCommand => zoomCommand ?? (zoomCommand = new ZoomCommand(this));

        private ICommand addComponentCommand;
        public ICommand AddComponentCommand => addComponentCommand ?? (addComponentCommand = new AddComponentCommand(this));

        private ICommand openFileDialogCommand;
        public ICommand OpenFileDialogCommand => openFileDialogCommand ?? (openFileDialogCommand = new OpenFileDialogCommand(this));

        private ICommand openFolderDialog;
        public ICommand OpenFolderDialog => openFolderDialog ?? (openFolderDialog = new OpenFolderDialog(this));

        private ICommand testCommand;
        public ICommand TestCommand => testCommand ?? (testCommand = new RelayCommand<ExecutedRoutedEventArgs>()
        {
            ExecuteDelegate = Test
        });

        private ICommand testCommandInner;
        public ICommand TestCommandInner => testCommandInner ?? (testCommandInner = new RelayCommand<ExecutedRoutedEventArgs>()
        {
            ExecuteDelegate = TestInner
        });


        private void Test(ExecutedRoutedEventArgs ceva)
        {
            $"Arguments:".Dump();
            $" Param: {ceva.Parameter?.ToString()}".Dump();
            $" Handled: {ceva.Handled}".Dump();
            $" OriginalSource: {ceva.OriginalSource?.ToString()}".Dump();
            $" Source: {ceva.Source?.ToString()}".Dump();
        }
        private void TestInner(ExecutedRoutedEventArgs ceva)
        {
            $"Inner arguments:".Dump();
            $" Param: {ceva.Parameter?.ToString()}".Dump();
            $" Handled: {ceva.Handled}".Dump();
            $" OriginalSource: {ceva.OriginalSource?.ToString()}".Dump();
            $" Source: {ceva.Source?.ToString()}".Dump();
            RoutedCommands.SelectComponentCommand2.Execute(ceva, ceva.Source as IInputElement);
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
