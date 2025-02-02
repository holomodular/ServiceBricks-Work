using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work.EntityFrameworkCore;
using ServiceBricks.Storage.Postgres;

namespace ServiceBricks.Work.Postgres
{
    /// <summary>
    /// Extensions to add the WorkPostgres module to the IServiceCollection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkPostgres module to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add the parent module
            services.AddServiceBricksWorkEntityFrameworkCore(configuration);

            // AI: Add the module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkPostgresModule.Instance);

            // AI: Add module business rules
            WorkPostgresModuleAddRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkPostgresModule>.Register(BusinessRuleRegistry.Instance);
            PostgresDatabaseMigrationRule<WorkModule, WorkPostgresContext>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
