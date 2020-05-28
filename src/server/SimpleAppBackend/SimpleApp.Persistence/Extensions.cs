using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleAppDbContext>(optBuilder => {
                optBuilder.UseSqlServer(configuration.GetConnectionString("simple"), b => b.MigrationsAssembly("SimpleApp.Persistence"));
                
            });
            return services;
        }
    }
}
