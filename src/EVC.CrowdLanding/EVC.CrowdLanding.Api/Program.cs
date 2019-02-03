using EVC.CrowdLanding.Api.Extensions;
using EVC.CrowdLanding.Api.Migrations.Seed;
using EVC.CrowdLanding.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EVC.CrowdLanding.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<CrowdFundingsDbContext, CrowdFundingDbSeed>()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
