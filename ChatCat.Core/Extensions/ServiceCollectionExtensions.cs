﻿using ChatCat.Core.ViewModels.Concrete.Application;
using ChatCat.Core.ViewModels.Concrete.Auth;
using ChatCat.Core.ViewModels.Concrete.Chat;
using Microsoft.Extensions.DependencyInjection;

namespace ChatCat.Core.Extensions
{
    /// <summary>
    /// Extension methods for IServiceCollection to add dependency resolvers.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds core services to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            #region View Model Injections

            services.AddSingleton<ApplicationVM>();
            services.AddSingleton<LoginPageVM>();
            services.AddSingleton<RegisterPageVM>();
            services.AddSingleton<ChatPageVM>();
            services.AddSingleton<ChatListVM>();
            services.AddSingleton<ChatPageVM>();

            #endregion View Model Injections

            return services;
        }
    }
}