using EVC.CrowdLanding.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EVC.CrowdLanding.Api.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext, TContextSeed>(this IWebHost webHost)
            where TContext : DbContext
            where TContextSeed : IContextSeed<TContext>
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetRequiredService<TContext>();
                var seeder = services.GetRequiredService<IContextSeed<TContext>>();

                try
                {
                    var connectionString = context.Database.GetDbConnection().ConnectionString;

                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    context.Database.Migrate();

                    seeder.Seed(context);
                }
                catch (Exception exception)
                {
                    logger.LogError(exception, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                }
            }

            return webHost;
        }
    }
}
