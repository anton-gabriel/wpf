namespace GraphPlot.ViewModel.Factory
{
    public enum ControlModuleType
    {
        Invalid = 0,
        Scene
    }

    public interface IControlFactory
    {
        IControlModule CreateModule(ControlModuleType type);
    }
}
