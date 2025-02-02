using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Storage.MongoDb;

namespace ServiceBricks.Work.MongoDb
{
    /// <summary>
    /// Extensions to add the WorkMongoDb module to the IServiceCollection.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the WorkMongoDb module to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add the parent module
            services.AddServiceBricksWork(configuration);

            // AI: Add this module to the ModuleRegistry
            ModuleRegistry.Instance.Register(WorkMongoDbModule.Instance);

            // AI: Add module business rules
            WorkMongoDbModuleAddRule.Register(BusinessRuleRegistry.Instance);
            MongoDbGuidSerializerStandardRule.Register(BusinessRuleRegistry.Instance);
            ModuleSetStartedRule<WorkMongoDbModule>.Register(BusinessRuleRegistry.Instance);

            return services;
        }
    }
}
