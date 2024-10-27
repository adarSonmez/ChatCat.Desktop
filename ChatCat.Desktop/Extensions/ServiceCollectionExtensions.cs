using ChatCat.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ChatCat.Desktop.Extensions
{
    /// <summary>
    /// Extension methods for IServiceCollection to add dependency resolvers.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds desktop services to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddDesktopServices(this IServiceCollection services)
        {
            #region View Model Injections

            services.AddSingleton<MainWindowVM>();

            #endregion View Model Injections

            return services;
        }
    }
}