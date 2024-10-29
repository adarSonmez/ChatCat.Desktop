using ChatCat.Core.Extensions;
using ChatCat.Core.Utils.IoC;
using ChatCat.Desktop.Extensions;
using ChatCat.Desktop.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace ChatCat.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        #region Constructors

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddCoreServices();
                    services.AddDesktopServices();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .Build();
        }

        #endregion Constructors

        #region Application Lifecycle

        /// <inheritdoc/>
        protected override async void OnStartup(StartupEventArgs e)
        {
            DependencyResolver.SetServiceProvider(_host.Services);

            await _host.StartAsync();

            Current.MainWindow = _host.Services.GetRequiredService<MainWindow>();
            Current.MainWindow.Show();

            base.OnStartup(e);
        }

        /// <inheritdoc/>
        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }

        #endregion Application Lifecycle
    }
}