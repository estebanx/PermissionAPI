using System;
using Microsoft.Extensions.DependencyInjection;
using Permission.Models.Entities;
using Permission.Models.Repositories;

namespace Permission.Models.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryBase<Permission.Models.Entities.Permission>, RepositoryBase<Permission.Models.Entities.Permission>>();
            services.AddTransient<IRepositoryBase<PermissionType>, RepositoryBase<PermissionType>>();
        }
    }
}

