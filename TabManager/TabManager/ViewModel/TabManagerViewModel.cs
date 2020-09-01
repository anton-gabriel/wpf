using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using TabManager.Model;

namespace TabManager.ViewModel
{
    internal sealed class TabManagerViewModel
        : INotifyPropertyChanged
    {
        public TabManagerViewModel()
        {
            Tabs = new ObservableCollection<TableData>()
            {
                new TableData($"Tab {Index}", new List<string>()
                {
                    $"Data {Index}",
                    $"Data {Index}",
                    $"Data {Index}",
                }, "None")
            };
            Index++;
            CreateTabCommand = new RelayCommand<SelectionChangedEventArgs>()
            {
                ExecuteDelegate = CreateTab
            };
            CloseTabCommand = new RelayCommand<TableData>()
            {
                ExecuteDelegate = CloseTab
            };
        }


        private TableData currentTab;
        public TableData CurrentTab
        {
            get => currentTab;
            private set
            {
                currentTab = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TableData> Tabs { get; private set; }


        //for title name
        private int Index { get; set; }
        public ICommand CreateTabCommand { get; private set; }
        public ICommand CloseTabCommand { get; private set; }
        private void CreateTab(SelectionChangedEventArgs args)
        {
            var selected = args.AddedItems?.OfType<string>().FirstOrDefault();
            if (selected != null)
            {
                var tab = new TableData($"Tab from {selected}", new List<string>()
                {
                    $"Data {Index}",
                    $"Data {Index}",
                    $"Data {Index}",
                }, selected);
                Tabs.Add(tab);
                //Set current tab to focus last created tab
                CurrentTab = tab;
                Index++;
            }
        }
        private void CloseTab(TableData args)
        {
            if (Tabs.Count > 1)
            {
                Tabs.Remove(args);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
