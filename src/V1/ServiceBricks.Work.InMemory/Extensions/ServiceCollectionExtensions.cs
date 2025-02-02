using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.InMemory
{
    /// <summary>
    /// Extensions to add the WorkInMemory module to the IServiceCollection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkInMemory module to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkInMemory(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add the parent module
            services.AddServiceBricksWorkEntityFrameworkCore(configuration);

            // AI: Add the module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkInMemoryModule.Instance);

            // AI: Add module business rules
            WorkInMemoryModuleAddRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkInMemoryModule>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
