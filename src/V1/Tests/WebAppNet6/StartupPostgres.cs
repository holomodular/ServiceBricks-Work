using ServiceBricks;
using ServiceBricks.Work.Postgres;
using ServiceBricks.Cache.Postgres;
using ServiceBricks.Logging.Postgres;
using ServiceBricks.Notification.Postgres;
using ServiceBricks.Security.Postgres;
using WebApp.Extensions;

namespace WebApp
{
    public class StartupPostgres
    {
        public StartupPostgres(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual IConfiguration Configuration { get; set; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceBricks(Configuration);
            services.AddServiceBricksLoggingPostgres(Configuration);
            services.AddServiceBricksCachePostgres(Configuration);
            services.AddServiceBricksNotificationPostgres(Configuration);
            services.AddServiceBricksSecurityPostgres(Configuration);
            services.AddServiceBricksWorkPostgres(Configuration);
            ModuleRegistry.Instance.Register(new WebApp.Model.WebAppModule()); // Automapper registration (problemdetails)
            services.AddServiceBricksComplete(Configuration);
            services.AddCustomWebsite(Configuration);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment)
        {
            app.StartServiceBricks();
            app.StartCustomWebsite(webHostEnvironment);

            var logger = app.ApplicationServices.GetRequiredService<ILogger<StartupPostgres>>();
            logger.LogInformation("Application Started");
        }
    }
}