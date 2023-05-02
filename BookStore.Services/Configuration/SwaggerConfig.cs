using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BookStore.Services.Configuration
{
    public static class SwaggerConfig
    {
        public static void SwaggerConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Book Store REST API",
                    Description = "An ASP.NET Core Web API for managing Book Store Integration",
                });
            });
        }
    }
}

