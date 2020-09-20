using GraphPlot.View;
using GraphPlot.ViewModel;
using GraphPlot.ViewModel.Contract;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            var provider = services
                .AddTransient<ISceneViewModel, SceneViewModel>()
                .AddTransient<IMainViewModel, MainViewModel>()
                .AddLogging(logging =>
                {
                    logging.AddNLog(@"..\..\..\NLog.config");
                })
                .BuildServiceProvider();
            MainView mainView = new MainView()
            {
                DataContext = provider.GetRequiredService<IMainViewModel>()
            };
            mainView.Show();
        }
    }
}
