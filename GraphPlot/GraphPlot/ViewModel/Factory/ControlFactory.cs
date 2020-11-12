using GraphPlot.ViewModel.Contract;
using System;
using System.Linq;
using System.Collections.Generic;

namespace GraphPlot.ViewModel.Factory
{
    internal sealed class ControlFactory
        : IControlFactory
    {
        #region Constructors
        public ControlFactory(IEnumerable<IControlModule> modules)
        {
            var m = modules;
             var t = modules.ToDictionary(module => module.Name);
            ModuleCreator = new Dictionary<ControlModuleType, Func<IControlModule>>
            {
                [ControlModuleType.Scene] = () => new SceneModule()
            };
        }
        #endregion

        #region Properties
        public Dictionary<ControlModuleType, Func<IControlModule>> ModuleCreator { get; set; }
        #endregion

        public IControlModule CreateModule(ControlModuleType type)
        {
            return ModuleCreator[type]();
        }
    }
}
