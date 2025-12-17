using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;
using ServiceBricks.Work.SqlServer;
using ServiceBricks.Cache.InMemory;

namespace ServiceBricks.Xunit
{
    public class StartupSqlServer : ServiceBricks.Startup
    {
        public StartupSqlServer(IConfiguration configuration) : base(configuration)
        {
        }

        public virtual void ConfigureDevelopmentServices(IServiceCollection services)
        {
            base.CustomConfigureServices(services);
            services.AddSingleton(Configuration);
            services.AddServiceBricks(Configuration);
            services.AddServiceBricksCacheInMemory(Configuration);
            services.AddServiceBricksWorkSqlServer(Configuration);

            // Remove all background tasks/timers for unit testing

            // Register TestManager

            services.AddScoped<ITestManager<ProcessDto>, ProcessTestManager>();

            services.AddServiceBricksComplete(Configuration);
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            base.CustomConfigure(app);
            app.StartServiceBricks();
        }
    }
}