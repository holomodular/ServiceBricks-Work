using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work.EntityFrameworkCore;
using ServiceBricks.Storage.EntityFrameworkCore;

namespace ServiceBricks.Work.SqlServer
{
    /// <summary>
    /// This rule is executed when the WorkSqlServer module is added.
    /// </summary>
    public sealed class WorkSqlServerModuleAddRule : BusinessRule
    {
        /// <summary>
        /// Register the rule
        /// </summary>
        public static void Register(IBusinessRuleRegistry registry)
        {
            registry.Register(
                typeof(ModuleAddEvent<WorkSqlServerModule>),
                typeof(WorkSqlServerModuleAddRule));
        }

        /// <summary>
        /// UnRegister the rule.
        /// </summary>
        public static void UnRegister(IBusinessRuleRegistry registry)
        {
            registry.UnRegister(
                typeof(ModuleAddEvent<WorkSqlServerModule>),
                typeof(WorkSqlServerModuleAddRule));
        }

        /// <summary>
        /// Execute the business rule.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IResponse ExecuteRule(IBusinessRuleContext context)
        {
            var response = new Response();

            // AI: Make sure the context object is the correct type
            if (context == null || context.Object == null)
            {
                response.AddMessage(ResponseMessage.CreateError(LocalizationResource.PARAMETER_MISSING, "context"));
                return response;
            }
            var e = context.Object as ModuleAddEvent<WorkSqlServerModule>;
            if (e == null || e.DomainObject == null || e.ServiceCollection == null)
            {
                response.AddMessage(ResponseMessage.CreateError(LocalizationResource.PARAMETER_MISSING, "context"));
                return response;
            }

            // AI: Perform logic
            var services = e.ServiceCollection;
            var configuration = e.Configuration;

            // AI: Register the database for the module
            var builder = new DbContextOptionsBuilder<WorkSqlServerContext>();
            string connectionString = configuration.GetSqlServerConnectionString(
                WorkSqlServerConstants.APPSETTING_CONNECTION_STRING);
            builder.UseSqlServer(connectionString, x =>
            {
                x.MigrationsAssembly(typeof(ServiceCollectionExtensions).Assembly.GetName().Name);
                x.EnableRetryOnFailure();
            });
            services.Configure<DbContextOptions<WorkSqlServerContext>>(o => { o = builder.Options; });
            services.AddSingleton<DbContextOptions<WorkSqlServerContext>>(builder.Options);
            services.AddDbContext<WorkSqlServerContext>(c => { c = builder; }, ServiceLifetime.Scoped);

            // AI: Add the storage services for the module for each domain object
            
            services.AddScoped<IStorageRepository<Process>, WorkStorageRepository<Process>>();


            return response;
        }
    }
}
