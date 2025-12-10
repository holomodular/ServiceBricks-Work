using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Storage.AzureDataTables;

namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// This rule is executed when the WorkAzureDataTables module is added.
    /// </summary>
    public sealed class WorkAzureDataTablesModuleAddRule : BusinessRule
    {
        /// <summary>
        /// Register the rule
        /// </summary>
        public static void Register(IBusinessRuleRegistry registry)
        {
            registry.Register(
                typeof(ModuleAddEvent<WorkAzureDataTablesModule>),
                typeof(WorkAzureDataTablesModuleAddRule));
        }

        /// <summary>
        /// UnRegister the rule.
        /// </summary>
        public static void UnRegister(IBusinessRuleRegistry registry)
        {
            registry.UnRegister(
                typeof(ModuleAddEvent<WorkAzureDataTablesModule>),
                typeof(WorkAzureDataTablesModuleAddRule));
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
            var e = context.Object as ModuleAddEvent<WorkAzureDataTablesModule>;
            if (e == null || e.DomainObject == null || e.ServiceCollection == null)
            {
                response.AddMessage(ResponseMessage.CreateError(LocalizationResource.PARAMETER_MISSING, "context"));
                return response;
            }

            // AI: Perform logic
            var services = e.ServiceCollection;
            var configuration = e.Configuration;

            // AI: Configure all options for the module

            // AI: Add storage services for the module
            
            services.AddScoped<IStorageRepository<Process>, WorkStorageRepository<Process>>();


            // AI: Add API services for the module. Each DTO should have two registrations, one for the generic IApiService<> and one for the named interface
            
            services.AddScoped<IApiService<ProcessDto>, ProcessApiService>();
            services.AddScoped<IProcessApiService, ProcessApiService>();

            // AI: Register mappings
            ProcessMappingProfile.Register(MapperRegistry.Instance);

            // AI: Register business rules for the module
            DomainCreateUpdateDateRule<Process>.Register(BusinessRuleRegistry.Instance);
            ApiConcurrencyByUpdateDateRule<Process, ProcessDto>.Register(BusinessRuleRegistry.Instance);
            AzureDataTablesDomainDateTimeOffsetRule<Process>.Register(BusinessRuleRegistry.Instance,nameof(Process.ProcessDate),nameof(Process.FutureProcessDate));
            ProcessCreateRule.Register(BusinessRuleRegistry.Instance);
            DomainQueryPropertyRenameRule<Process>.Register(BusinessRuleRegistry.Instance, "StorageKey", "Key");


            return response;
        }
    }
}
