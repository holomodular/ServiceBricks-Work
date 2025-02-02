using ServiceBricks;
using ServiceBricks.Work.InMemory;
using ServiceBricks.Cache.InMemory;
using ServiceBricks.Logging.InMemory;
using ServiceBricks.Notification.InMemory;
using ServiceBricks.Security.InMemory;
using WebApp.Extensions;

namespace WebApp
{
    public class StartupInMemory
    {
        public StartupInMemory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual IConfiguration Configuration { get; set; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceBricks(Configuration);
            services.AddServiceBricksLoggingInMemory(Configuration);
            services.AddServiceBricksCacheInMemory(Configuration);
            services.AddServiceBricksNotificationInMemory(Configuration);
            services.AddServiceBricksSecurityInMemory(Configuration);
            services.AddServiceBricksWorkInMemory(Configuration);
            ModuleRegistry.Instance.Register(new WebApp.Model.WebAppModule()); // Automapper registration (problemdetails)
            services.AddServiceBricksComplete(Configuration);
            services.AddCustomWebsite(Configuration);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment)
        {
            app.StartServiceBricks();
            app.StartCustomWebsite(webHostEnvironment);

            var logger = app.ApplicationServices.GetRequiredService<ILogger<StartupInMemory>>();
            logger.LogInformation("Application Started");
        }
    }
}