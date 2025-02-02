using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;
using ServiceBricks.Work.Postgres;
using ServiceBricks.Cache.Postgres;

namespace ServiceBricks.Xunit
{
    public class StartupPostgres : ServiceBricks.Startup
    {
        public StartupPostgres(IConfiguration configuration) : base(configuration)
        {
        }

        public virtual void ConfigureDevelopmentServices(IServiceCollection services)
        {
            base.CustomConfigureServices(services);
            services.AddSingleton(Configuration);
            services.AddServiceBricks(Configuration);
            services.AddServiceBricksCachePostgres(Configuration);
            services.AddServiceBricksWorkPostgres(Configuration);

            // Remove all background tasks/timers for unit testing

            // Register TestManager

            services.AddScoped<ITestManager<ProcessDto>, ProcessTestManagerPostgres>();

            services.AddServiceBricksComplete(Configuration);
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            base.CustomConfigure(app);
            app.StartServiceBricks();
        }
    }
}