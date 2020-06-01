using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleApp.Api.Middlewears;
using SimpleApp.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Api.Common
{
    public static class Extensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secrete = configuration["AppSettings:TokenSecrete"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                    opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(secrete.ToBytes())
                        };
                    }
                );
            return services;
        }

        public static byte[] ToBytes(this string str)
        {            
            return Encoding.ASCII.GetBytes(str);
        }

        public static IApplicationBuilder UseCustomExceptionHanlder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddlewear>();
        }


    }
}
