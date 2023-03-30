using System;
using Microsoft.Extensions.DependencyInjection;
using Permission.Services.Services;

namespace Permission.Services.IoC
{
    public static class ServicesRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IPermissionTypeService, PermissionTypeService>();
        }
    }
}

