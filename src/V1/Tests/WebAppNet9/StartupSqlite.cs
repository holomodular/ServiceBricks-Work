using ServiceBricks;
using ServiceBricks.Work.Sqlite;
using ServiceBricks.Cache.Sqlite;
using ServiceBricks.Logging.Sqlite;
using ServiceBricks.Notification.Sqlite;
using ServiceBricks.Security.Sqlite;
using WebApp.Extensions;

namespace WebApp
{
    public class StartupSqlite
    {
        public StartupSqlite(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual IConfiguration Configuration { get; set; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceBricks(Configuration);
            services.AddServiceBricksLoggingSqlite(Configuration);
            services.AddServiceBricksCacheSqlite(Configuration);
            services.AddServiceBricksNotificationSqlite(Configuration);
            services.AddServiceBricksSecuritySqlite(Configuration);
            services.AddServiceBricksWorkSqlite(Configuration);
            ModuleRegistry.Instance.Register(new WebApp.Model.WebAppModule()); // Automapper registration (problemdetails)
            services.AddServiceBricksComplete(Configuration);
            services.AddCustomWebsite(Configuration);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment)
        {
            app.StartServiceBricks();
            app.StartCustomWebsite(webHostEnvironment);

            var logger = app.ApplicationServices.GetRequiredService<ILogger<StartupSqlite>>();
            logger.LogInformation("Application Started");
        }
    }
}