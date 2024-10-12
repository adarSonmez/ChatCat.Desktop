using System.Windows;
using ChatCat.Core.Extensions;
using ChatCat.Core.Utils.IoC;
using ChatCat.Desktop.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ChatCat.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
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

                    ConfigureDesktopServices(services);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .Build();
        }

        /// <inheritdoc/>
        protected override async void OnStartup(StartupEventArgs e)
        {
            DependencyResolver.SetServiceProvider(_host.Services);

            await _host.StartAsync();

            Current.MainWindow = new MainWindow();
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

        /// <summary>
        /// Configures the desktop services.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureDesktopServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindowVM>();
        }
    }
}