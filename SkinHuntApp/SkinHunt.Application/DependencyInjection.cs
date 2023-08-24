﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkinHunt.Application.Common.Interfaces;
using SkinHunt.Application.Services;
using System.Reflection;

namespace SkinHunt.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Add Database connection
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbContext>(options => options.UseSqlServer(connection));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IDbInitializer, DbInitializer>();

            return services;
        }
    }
}
