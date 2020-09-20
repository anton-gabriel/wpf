using GraphPlot.ViewModel.Contract;
using Microsoft.Extensions.Logging;
using System;

namespace GraphPlot.ViewModel
{
    internal sealed class MainViewModel
        : BaseViewModel, IMainViewModel
    {
        #region Constructors
        public MainViewModel(ISceneViewModel sceneViewModel, ILogger<MainViewModel> logger)
        {
            SceneViewModel = sceneViewModel ?? throw new ArgumentNullException(nameof(sceneViewModel));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Logger.LogInformation("MainViewModel built");
        }
        #endregion

        #region Private fields
        #endregion

        #region Properties
        public ISceneViewModel SceneViewModel { get; }
        private ILogger<MainViewModel> Logger { get; }
        #endregion

        #region Commands

        #endregion
    }
}
