using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleApp.Persistence.Repositories;
using SimpleApp.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {            
            services.AddScoped<IDashboardService, DashboardService>();
            return services;
        }

        public static string ToSHA256(this string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
