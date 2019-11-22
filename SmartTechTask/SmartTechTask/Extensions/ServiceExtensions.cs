using Microsoft.Extensions.DependencyInjection;
using SmartTechTask.Services;
using SmartTechTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            return services;
        }


        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddSingleton<IUploadServive, UploadService>();
            return services;
        }

    }
}
