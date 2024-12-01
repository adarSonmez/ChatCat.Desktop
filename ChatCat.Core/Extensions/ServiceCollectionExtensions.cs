using ChatCat.Core.ViewModels.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ChatCat.Core.Extensions;

/// <summary>
/// Extension methods for IServiceCollection to add dependency resolvers.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds core services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection with the core services added.</returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        #region View Model Injections

        services.AddSingleton<ApplicationVM>();
        services.AddSingleton<LoginPageVM>();
        services.AddSingleton<RegisterPageVM>();
        services.AddSingleton<ChatListVM>();
        services.AddSingleton<ChatListItemVM>();
        services.AddSingleton<ChatInputVM>();
        services.AddSingleton<AttachmentMenuVM>();
        services.AddSingleton<MenuItemVM>();
        services.AddSingleton<MessageListVM>();
        services.AddSingleton<MessageListItemVM>();

        #endregion View Model Injections

        return services;
    }
}