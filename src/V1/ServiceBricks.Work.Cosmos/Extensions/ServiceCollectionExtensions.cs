using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Storage.EntityFrameworkCore;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.Cosmos
{
    /// <summary>
    /// Extensions to add the WorkCosmos module to the IServiceCollection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkCosmos module to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkCosmos(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add the parent module
            services.AddServiceBricksWorkEntityFrameworkCore(configuration);

            // AI: Add the module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkCosmosModule.Instance);

            // AI: Add module business rules
            WorkCosmosModuleAddRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkCosmosModule>.Register(BusinessRuleRegistry.Instance);
            EntityFrameworkCoreDatabaseEnsureCreatedRule<WorkModule, WorkCosmosContext>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
