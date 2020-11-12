using System.ComponentModel;

namespace GraphPlot.ViewModel.Contract
{
    public interface IMainViewModel
        : INotifyPropertyChanged
    {
        ISceneViewModel SceneViewModel { get; }
    }
}
