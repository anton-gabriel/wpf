using GraphPlot.View;
using GraphPlot.ViewModel;
using GraphPlot.ViewModel.Contract;
using GraphPlot.ViewModel.Factory;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using System.Windows;

namespace GraphPlot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string LoggerConfigFile = @"..\..\..\NLog.config";

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            var provider = services
                .AddTransient<IMainViewModel, MainViewModel>()
                .AddTransient<IControlModule, SceneModule>()
                .AddTransient<ISceneViewModel, SceneViewModel>()
                .AddSingleton<IControlFactory, ControlFactory>()
                .AddLogging(logging =>
                {
                    logging.AddNLog(LoggerConfigFile);
                })
                .BuildServiceProvider();
            MainView mainView = new MainView()
            {
                DataContext = provider.GetRequiredService<IMainViewModel>()
            };
            var t = provider.GetRequiredService<IControlFactory>();
            mainView.Show();
        }
    }
}
