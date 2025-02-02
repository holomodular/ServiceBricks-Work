using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// Extensions to add the WorkAzureDataTables module to the service collection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkAzureDataTables module to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkAzureDataTables(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add parent module
            services.AddServiceBricksWork(configuration);

            // AI: Add the module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkAzureDataTablesModule.Instance);

            // AI: Add module business rules
            WorkAzureDataTablesModuleAddRule.Register(BusinessRuleRegistry.Instance);
            WorkAzureDataTablesModuleStartRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkAzureDataTablesModule>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
