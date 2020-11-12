using System.ComponentModel;

namespace GraphPlot.ViewModel.Factory
{
    public interface IControlModule
    {
        public string Name { get; }
        public ControlModuleType Type { get; }
        public INotifyPropertyChanged Context { get; }
    }
}
