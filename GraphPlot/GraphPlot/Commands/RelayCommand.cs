﻿using System;

namespace GraphPlot.Commands
{
    internal class RelayCommand<T>
        : IRaisableCommand
    {
        #region Properties
        public Predicate<T> CanExecuteDelegate { get; set; }
        public Action<T> ExecuteDelegate { get; set; }
        #endregion

        #region Public methods
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region ICommand
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate == null || CanExecuteDelegate((T)parameter);
        }
        public void Execute(object parameter)
        {
            ExecuteDelegate((T)parameter);
        }
        #endregion
    }
}
