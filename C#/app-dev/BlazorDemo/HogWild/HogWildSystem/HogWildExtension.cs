﻿using HogWildSystem.BLL;
using HogWildSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HogWildSystem
{
    public static class HogWildExtension
    {
        // This is an extension method that extends the IServiceCollection interface.
        // It is typically used in ASP.NET Core applications to configure and register services.

        // The method name can be anything, but it must match the name used when calling it in
        // your Program.cs file using builder.Services.XXXX(options => ...).
        public static void AddBackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            // Register the HogWildContext class, which is the DbContext for your application,
            // with the service collection. This allows the DbContext to be injected into other
            // parts of your application as a dependency.
            services.AddTransient<WorkingVersionsService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetRequiredService<HogWildContext>();
                return new WorkingVersionsService(context);
            });

            services.AddTransient<CustomerService>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetRequiredService<HogWildContext>();
                return new CustomerService(context);
            });

            // The 'options' parameter is an Action<DbContextOptionsBuilder> that typically
            // configures the options for the DbContext, including specifying the database
            // connection string.

            services.AddDbContext<HogWildContext>(options);
        }
        
    }
}