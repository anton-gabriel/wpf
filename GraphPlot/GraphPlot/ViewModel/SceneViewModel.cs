using GraphPlot.Commands;
using GraphPlot.ViewModel.Contract;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphPlot.ViewModel
{
    internal sealed class SceneViewModel
        : BaseViewModel, ISceneViewModel
    {
        #region Constructors
        public SceneViewModel()
        {
            
        }
        #endregion

        #region Private fields

        #endregion

        #region Properties

        #endregion

        #region Commands
        private IRaisableCommand testCommand;
        public IRaisableCommand TestCommand => testCommand ??= new RelayCommand<object>() { ExecuteDelegate = param => Console.WriteLine("Test") };
        #endregion
    }
}
