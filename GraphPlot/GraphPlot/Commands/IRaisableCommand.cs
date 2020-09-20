using System.Windows.Input;

namespace GraphPlot.Commands
{
    public interface IRaisableCommand
        : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
