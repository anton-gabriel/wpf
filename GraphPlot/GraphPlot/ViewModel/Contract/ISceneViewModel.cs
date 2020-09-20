using GraphPlot.Commands;
using System.Windows.Input;

namespace GraphPlot.ViewModel.Contract
{
    public interface ISceneViewModel
    {
        IRaisableCommand TestCommand { get; }
    }
}
