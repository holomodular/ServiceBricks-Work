using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work.EntityFrameworkCore;
using ServiceBricks.Storage.Sqlite;

namespace ServiceBricks.Work.Sqlite
{
    /// <summary>
    /// Extensions to add the WorkSqlite module to the IServiceCollection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkSqlite module to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add the parent module
            services.AddServiceBricksWorkEntityFrameworkCore(configuration);

            // AI: Add the module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkSqliteModule.Instance);

            // AI: Add module business rules
            WorkSqliteModuleAddRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkSqliteModule>.Register(BusinessRuleRegistry.Instance);
            SqliteDatabaseMigrationRule<WorkModule, WorkSqliteContext>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
