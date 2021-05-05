using System;
using Microsoft.Extensions.DependencyInjection;
using task.business;
using task.datasource;
using task.Model;

namespace task.dependencies
{
    public static class StartupExtension
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<ILevelService, LevelService>();
            return services;
        }
    }
}