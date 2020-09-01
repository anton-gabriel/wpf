using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TreeViewExplorer.Commands.FolderExplorerCommands
{
    internal sealed class SelectItemsCommand
        : RelayCommand<SelectionChangedEventArgs>
    {
        #region Constructors
        public SelectItemsCommand(FolderExplorerViewModel folderExplorerViewModel)
        {
            FolderExplorerViewModel = folderExplorerViewModel ?? throw new System.ArgumentNullException(nameof(folderExplorerViewModel));
            ExecuteDelegate = SelectItems;
            Files = new LinkedList<FileInfo>();
        }

        #endregion

        #region Properties
        private FolderExplorerViewModel FolderExplorerViewModel { get; }
        private LinkedList<FileInfo> Files { get; set; }
        #endregion

        #region Private methods
        private void SelectItems(SelectionChangedEventArgs args)
        {
            args.AddedItems?.OfType<FileSystemInfo>().ToList().ForEach(selected =>
            {
                Add(selected);
            });
            args.RemovedItems?.OfType<FileSystemInfo>().ToList().ForEach(unselected =>
            {
                Remove(unselected);
            });
            FolderExplorerViewModel.OnPropertyChanged(name: nameof(FolderExplorerViewModel.All));
        }

        private void Add(FileSystemInfo selected)
        {
            string path = selected.FullName;
            if (Directory.Exists(path))
            {
                if (FolderExplorerViewModel.SelectionMode.HasFlag(SelectionMode.Directories))
                {
                    FolderExplorerViewModel.Directories.Add(selected.FullName);
                }
                if (FolderExplorerViewModel.AutoSearch)
                {
                    var files = FindFiles(path, $"*.{FolderExplorerViewModel.ExtensionFilter}");
                    foreach (var file in files)
                    {
                        FolderExplorerViewModel.Files.Add(file);
                    }
                }
            }
            else if (File.Exists(path))
            {
                if (!string.IsNullOrWhiteSpace(FolderExplorerViewModel.ExtensionFilter))
                {
                    if (FolderExplorerViewModel.ExtensionRegex.Replace(selected.Extension, string.Empty, count: 1)
                     == FolderExplorerViewModel.ExtensionFilter)
                    {
                        FolderExplorerViewModel.Files.Add(selected.FullName);
                    }
                }
                else
                {
                    FolderExplorerViewModel.Files.Add(selected.FullName);
                }
            }
        }

        private void Remove(FileSystemInfo selected)
        {
            string path = selected.FullName;
            if (Directory.Exists(path))
            {
                FolderExplorerViewModel.Directories.Remove(selected.FullName);
                if (FolderExplorerViewModel.AutoSearch)
                {
                    var files = FindFiles(path, $"*.{FolderExplorerViewModel.ExtensionFilter}");
                    foreach (var file in files)
                    {
                        FolderExplorerViewModel.Files.Remove(file);
                    }
                }
            }
            else if (File.Exists(path))
            {
                FolderExplorerViewModel.Files.Remove(selected.FullName);
            }
        }

        private IEnumerable<string> FindFiles(string path, string pattern)
        {
            Files.Clear();
            FindFiles(new DirectoryInfo(path), pattern);
            IEnumerable<string> files = Files.Select(fileInfo => fileInfo.FullName);
            return files;
        }

        private void FindFiles(DirectoryInfo directory, string pattern)
        {
            try
            {
                Parallel.ForEach(directory.EnumerateFiles(pattern), file =>
                {
                    lock (Files)
                    {
                        Files.AddFirst(file);
                    }
                });
            }
            catch
            {
                return;
            }
            Parallel.ForEach(directory.EnumerateDirectories(), dir => FindFiles(dir, pattern));
        }
        #endregion
    }
}
