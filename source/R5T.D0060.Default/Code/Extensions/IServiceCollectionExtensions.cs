﻿using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.D0060
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CurrentDirectoryPathProvider"/> implementation of <see cref="ICurrentDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCurrentDirectoryPathProvider(this IServiceCollection services)
        {
            services.AddSingleton<ICurrentDirectoryPathProvider, CurrentDirectoryPathProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="CurrentDirectoryPathProvider"/> implementation of <see cref="ICurrentDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICurrentDirectoryPathProvider> AddCurrentDirectoryPathProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<ICurrentDirectoryPathProvider>(() => services.AddCurrentDirectoryPathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FileSystemOperator"/> implementation of <see cref="IFileSystemOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFileSystemOperator(this IServiceCollection services)
        {
            services.AddSingleton<IFileSystemOperator, FileSystemOperator>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FileSystemOperator"/> implementation of <see cref="IFileSystemOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFileSystemOperator> AddFileSystemOperatorAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IFileSystemOperator>(() => services.AddFileSystemOperator());
            return serviceAction;
        }
    }
}
