using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceBricks.Work
{
    /// <summary>
    /// Extensions for adding the Work Microservice.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {

        /// <summary>
        /// Add the Work module clients to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkClient(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add clients for the module for each DTO

            services.AddScoped<IApiClient<ProcessDto>, ProcessApiClient>();
            services.AddScoped<IProcessApiClient, ProcessApiClient>();

            return services;
        }

        /// <summary>
        /// Add the ServiceBricks Work client to the service collection for the API Service references
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceBricksWorkClientForService(this IServiceCollection services, IConfiguration configuration)
        {
            // AI: Add clients for the API Services
            services.AddScoped<IApiService<ProcessDto>, ProcessApiClient>();
            services.AddScoped<IProcessApiService, ProcessApiClient>();

            return services;
        }
    }
}