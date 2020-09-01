using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TreeViewExplorer.Commands.FolderExplorerCommands;

namespace TreeViewExplorer
{
    [Flags]
    public enum SelectionMode : short
    {
        Invalid = 0,
        Files = 1,
        Directories = 2,
        All = Files | Directories
    }

    internal sealed class FolderExplorerViewModel
        : INotifyPropertyChanged
    {
        #region Constructors
        public FolderExplorerViewModel(bool editable)
        {
            Editable = editable;
            Items = new ObservableCollection<FileSystemInfo>();
            Directories = new HashSet<string>();
            Files = new HashSet<string>();
            RootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SelectionMode = SelectionMode.Files;
            SelectionModes = new List<SelectionMode>() { SelectionMode.Files, SelectionMode.Directories, SelectionMode.All };
            AutoSearch = true;
        }
        #endregion

        #region Private fields
        private bool autoSearch;
        private string title;
        private string filter;
        private string rootDirectory;
        private SelectionMode selectionMode;
        #endregion

        #region Properties
        public bool AutoSearch
        {
            get => autoSearch;
            set
            {
                autoSearch = value;
                Explore(RootDirectory);
            }
        }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public Regex ExtensionRegex { get; } = new Regex(Regex.Escape("."));
        public string ExtensionFilter
        {
            get => filter;
            set
            {
                filter = ExtensionRegex.Replace(value, string.Empty, count: 1);
                Explore(RootDirectory);
            }
        }
        public string RootDirectory
        {
            get => rootDirectory;
            set
            {
                if (Explore(value))
                {
                    rootDirectory = value;
                }
                OnPropertyChanged();
            }
        }
        public SelectionMode SelectionMode
        {
            get => selectionMode;
            set
            {
                selectionMode = value;
                Explore(RootDirectory);
                OnPropertyChanged();
            }
        }
        public bool Editable { get; }

        public IEnumerable<SelectionMode> SelectionModes { get; }
        public FileSystemInfo SelectedItem { get; set; }
        public ObservableCollection<FileSystemInfo> Items { get; private set; }
        public ICollection<string> Directories { get; private set; }
        public ICollection<string> Files { get; private set; }
        public IEnumerable<string> All => Directories.Concat(Files);
        #endregion

        #region Commands
        public ICommand selectItemsCommand;
        public ICommand SelectItemsCommand => selectItemsCommand ?? (selectItemsCommand = new SelectItemsCommand(this));

        private ICommand exploreCommand;
        public ICommand ExploreCommand => exploreCommand ?? (exploreCommand = new ExploreCommand(this));

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new AddCommand());

        private ICommand backCommand;
        public ICommand BackCommand => backCommand ?? (backCommand = new BackCommand());
        #endregion

        #region Private methods
        private bool Explore(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                try
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    var directories = directory.GetDirectories();
                    Clear();
                    directories.ToList().ForEach(Items.Add);
                    if (string.IsNullOrWhiteSpace(ExtensionFilter))
                    {
                        directory.GetFiles().ToList().ForEach(Items.Add);
                    }
                    else
                    {
                        directory.GetFiles().Where(fileInfo => ExtensionRegex.Replace(fileInfo.Extension, string.Empty, count: 1) == ExtensionFilter).ToList().ForEach(Items.Add);
                    }
                    return true;
                }
                catch (Exception exception)
                {
                    Trace.WriteLine($"Exception occured: {exception.Message}");
                    return false;
                }
            }
            return false;
        }
        private void Clear()
        {
            Items.Clear();
            Files.Clear();
            Directories.Clear();
            OnPropertyChanged(nameof(All));
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
