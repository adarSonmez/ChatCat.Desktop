using Microsoft.Extensions.DependencyInjection;

namespace ChatCat.Core.Utils.IoC
{
    /// <summary>
    /// Provides a service locator for resolving dependencies.
    /// </summary>
    public static class DependencyResolver
    {
        private static IServiceProvider _serviceProvider = null!;

        /// <summary>
        /// Configures the dependency resolver with the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Resolves a service of the specified type from the dependency resolver.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <returns>The service instance, or null if not found.</returns>
        public static T? Resolve<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }

        /// <summary>
        /// Resolves a service of the specified type from the dependency resolver.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns>The service instance, or null if not found.</returns>
        public static object? Resolve(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}