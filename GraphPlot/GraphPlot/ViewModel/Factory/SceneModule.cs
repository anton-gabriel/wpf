using GraphPlot.ViewModel.Contract;
using System;
using System.ComponentModel;

namespace GraphPlot.ViewModel.Factory
{
    internal sealed class SceneModule
        : IControlModule
    {
        public SceneModule(ISceneViewModel sceneViewModel)
        {
            SceneViewModel = sceneViewModel ?? throw new ArgumentNullException(nameof(sceneViewModel));
        }

        public ISceneViewModel SceneViewModel { get; }

        #region IControlModule
        public string Name => "Scene";
        public ControlModuleType Type => ControlModuleType.Scene;
        public INotifyPropertyChanged Context => SceneViewModel;
        #endregion
    }
}
