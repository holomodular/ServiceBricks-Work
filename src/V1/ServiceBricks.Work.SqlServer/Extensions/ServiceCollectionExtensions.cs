using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work.EntityFrameworkCore;
using ServiceBricks.Storage.SqlServer;

namespace ServiceBricks.Work.SqlServer
{
    /// <summary>
    /// Extensions to add the WorkSqlServer module to the IServiceCollection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkSqlServer module to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add the parent module
            services.AddServiceBricksWorkEntityFrameworkCore(configuration);

            // AI: Add the module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkSqlServerModule.Instance);

            // AI: Add module business rules
            WorkSqlServerModuleAddRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkSqlServerModule>.Register(BusinessRuleRegistry.Instance);
            SqlServerDatabaseMigrationRule<WorkModule, WorkSqlServerContext>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
