using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace ServiceBricks.Work.MongoDb
{
    /// <summary>
    /// This rule is executed when the WorkMongoDb module is added.
    /// </summary>
    public sealed class WorkMongoDbModuleAddRule : BusinessRule
    {
        /// <summary>
        /// Register the rule
        /// </summary>
        public static void Register(IBusinessRuleRegistry registry)
        {
            registry.Register(
                typeof(ModuleAddEvent<WorkMongoDbModule>),
                typeof(WorkMongoDbModuleAddRule));
        }

        /// <summary>
        /// UnRegister the rule.
        /// </summary>
        public static void UnRegister(IBusinessRuleRegistry registry)
        {
            registry.UnRegister(
                typeof(ModuleAddEvent<WorkMongoDbModule>),
                typeof(WorkMongoDbModuleAddRule));
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
            var e = context.Object as ModuleAddEvent<WorkMongoDbModule>;
            if (e == null || e.DomainObject == null || e.ServiceCollection == null)
            {
                response.AddMessage(ResponseMessage.CreateError(LocalizationResource.PARAMETER_MISSING, "context"));
                return response;
            }

            // AI: Perform logic
            var services = e.ServiceCollection;
            var configuration = e.Configuration;

            // AI: Add the storage services for the module for each domain object
            
            services.AddScoped<IStorageRepository<Process>, WorkStorageRepository<Process>>();


            // AI: Add API services for the module. Each DTO should have two registrations, one for the generic IApiService<> and one for the named interface
            
            services.AddScoped<IApiService<ProcessDto>, ProcessApiService>();
            services.AddScoped<IProcessApiService, ProcessApiService>();

            // AI: Register mappings
            ProcessMappingProfile.Register(MapperRegistry.Instance);

            // AI: Register business rules for the module
                     DomainCreateUpdateDateRule<Process>.Register(BusinessRuleRegistry.Instance);
            ApiConcurrencyByUpdateDateRule<Process, ProcessDto>.Register(BusinessRuleRegistry.Instance);
         DomainDateTimeOffsetRule<Process>.Register(BusinessRuleRegistry.Instance,nameof(Process.ProcessDate),nameof(Process.FutureProcessDate));
            DomainQueryPropertyRenameRule<Process>.Register(BusinessRuleRegistry.Instance, "StorageKey", "Key");



            return response;
        }
    }
}
