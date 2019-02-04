using EVC.CrowdLanding.Api.Migrations.Seed;
using EVC.CrowdLanding.Data;
using EVC.CrowdLanding.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SiemensGamesa.NAMC.StitchingTool.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace EVC.CrowdLanding.Api
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CrowdfundingsDbConnection");

            services.AddDbContext<CrowdFundingsDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("EVC.CrowdLanding.Api"))
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Crowd funding of Investments API",
                    Version = "v1",
                    Description = "Crowd funding of Investments API"
                });
            });

            services.AddCors(corsOptions => corsOptions.AddPolicy(
                "Default",
                corsPolicyBuilder => corsPolicyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

            services.AddScoped<DbContext, CrowdFundingsDbContext>();
            services.AddScoped<IContextSeed<CrowdFundingsDbContext>, CrowdFundingDbSeed>();
            services.AddScoped<IFundingService, FundingService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, DbContextUnitOfWork>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Default");

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stitching Tool API V1");
                c.RoutePrefix = "swagger/ui";
            });
        }
    }
}
