using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBricks.Work.EntityFrameworkCore
{
    /// <summary>
    /// Extensions to add the WorkEntityFrameworkCore module to the IServiceCollection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkEntityFrameworkCore module to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add the parent module
            services.AddServiceBricksWork(configuration);

            // AI: Add this module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkEntityFrameworkCoreModule.Instance);

            // AI: Add module business rules
            WorkEntityFrameworkCoreModuleAddRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkEntityFrameworkCoreModule>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
