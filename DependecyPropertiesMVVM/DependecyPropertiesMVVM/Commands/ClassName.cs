using System;

namespace DependecyPropertiesMVVM.Commands
{

    internal sealed class DrawCommand : RelayCommand<object>
    {
        #region Constructors
        public DrawCommand(ViewModel.ControlViewModel controlViewModel)
        {
            controlViewModel = controlViewModel ?? throw new System.ArgumentNullException(nameof(controlViewModel));
            CanExecuteDelegate = CanExecuteMethod;
            ExecuteDelegate = ExecuteMethod;
        }
        #endregion

        #region Properties
        private ViewModel.ControlViewModel controlViewModel { get; }
        #endregion

        #region Private fields
        private bool CanExecuteMethod(object args)
        {
            throw new NotImplementedException();
        }
        private void ExecuteMethod(object args)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
