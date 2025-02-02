using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Cache.AzureDataTables;
using ServiceBricks.Work;
using ServiceBricks.Work.AzureDataTables;

namespace ServiceBricks.Xunit
{
    public class StartupAzureDataTables : ServiceBricks.Startup
    {
        public StartupAzureDataTables(IConfiguration configuration) : base(configuration)
        {
        }

        public virtual void ConfigureDevelopmentServices(IServiceCollection services)
        {
            base.CustomConfigureServices(services);
            services.AddSingleton(Configuration);
            services.AddServiceBricks(Configuration);
            services.AddServiceBricksCacheAzureDataTables(Configuration);
            services.AddServiceBricksWorkAzureDataTables(Configuration);

            // Remove all background tasks/timers for unit testing

            // Register TestManager

            services.AddScoped<ITestManager<ProcessDto>, ProcessTestManagerAzureDataTables>();

            services.AddServiceBricksComplete(Configuration);
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            base.CustomConfigure(app);
            app.StartServiceBricks();
        }
    }
}