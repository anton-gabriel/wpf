using GraphPlot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GraphPlot.ViewModel
{
    internal sealed class MainViewModel 
        : BaseViewModel
    {
        #region Constructors
        public MainViewModel()
        {

        }
        #endregion

        #region Private fields

        #endregion

        #region Properties

        #endregion

        #region Commands
        private ICommand testCommand;
        public ICommand TestCommand => testCommand ??= new RelayCommand<object>() { ExecuteDelegate = param => Console.WriteLine("Test")};        
        #endregion
    }
}
