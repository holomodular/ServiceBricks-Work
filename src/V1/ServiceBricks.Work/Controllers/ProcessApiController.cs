using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ServiceBricks.Work
{
    /// <summary>
    /// This is a REST API Controller for ProcessDto.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/Work/Process")]
    [Produces("application/json")]
    public partial class ProcessApiController : AdminPolicyApiController<ProcessDto>, IProcessApiController
    {
        protected readonly IProcessApiService _apiService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="apiService"></param>
        /// <param name="apiOptions"></param>
        public ProcessApiController(
            IProcessApiService apiService,
            IOptions<ApiOptions> apiOptions)
            : base(apiService, apiOptions)
        {
            _apiService = apiService;
        }
    }
}
