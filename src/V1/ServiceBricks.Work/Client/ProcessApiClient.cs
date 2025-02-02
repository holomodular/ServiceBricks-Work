using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ServiceBricks.Work
{
    /// <summary>
    /// This class is an REST API client for the ProcessDto.
    /// </summary>
    public partial class ProcessApiClient : ApiClient<ProcessDto>, IProcessApiClient
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="httpClientFactory"></param>
        /// <param name="configuration"></param>
        public ProcessApiClient(
            ILoggerFactory loggerFactory,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
            : base(loggerFactory, httpClientFactory, configuration.GetApiConfig(WorkConstants.APPSETTING_CLIENT_APICONFIG))
        {
            ApiResource = @"Work/Process";
        }
    }
}
