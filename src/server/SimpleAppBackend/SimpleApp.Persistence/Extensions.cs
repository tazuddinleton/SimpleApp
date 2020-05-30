using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleAppDbContext>(optionBuilder => {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("simple"), 
                    config => config.MigrationsAssembly("SimpleApp.Persistence"));
                
            });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
