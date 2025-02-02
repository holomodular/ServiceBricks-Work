using ServiceBricks;
using ServiceBricks.Work.Cosmos;
using ServiceBricks.Cache.Cosmos;
using ServiceBricks.Logging.Cosmos;
using ServiceBricks.Notification.Cosmos;
using ServiceBricks.Security.Cosmos;
using WebApp.Extensions;

namespace WebApp
{
    public class StartupCosmos
    {
        public StartupCosmos(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual IConfiguration Configuration { get; set; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceBricks(Configuration);
            services.AddServiceBricksLoggingCosmos(Configuration);
            services.AddServiceBricksCacheCosmos(Configuration);
            services.AddServiceBricksNotificationCosmos(Configuration);
            services.AddServiceBricksSecurityCosmos(Configuration);
            services.AddServiceBricksWorkCosmos(Configuration);
            ModuleRegistry.Instance.Register(new WebApp.Model.WebAppModule()); // Automapper registration (problemdetails)
            services.AddServiceBricksComplete(Configuration);
            services.AddCustomWebsite(Configuration);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment)
        {
            app.StartServiceBricks();
            app.StartCustomWebsite(webHostEnvironment);

            var logger = app.ApplicationServices.GetRequiredService<ILogger<StartupCosmos>>();
            logger.LogInformation("Application Started");
        }
    }
}