using Microsoft.Extensions.Logging;
using ServiceBricks.Cache;

namespace ServiceBricks.Work
{
    /// <summary>
    /// This is a service for processing a domain object table like a queue.
    /// </summary>
    /// <typeparam name="TDomainObject"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract partial class SingleWorkProcessService : WorkProcessService
    {
        protected readonly ISingleServerProcessService _singleServerProcessService;

        /// <summary>
        /// Consrtuctor.
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="repository"></param>
        /// <param name="semaphoreService"></param>
        public SingleWorkProcessService(
            ILoggerFactory loggerFactory,
            IApiService<ProcessDto> apiService,
            ISingleServerProcessService singleServerProcessService) : base(loggerFactory, apiService)
        {
            _singleServerProcessService = singleServerProcessService;
        }

        /// <summary>
        /// Execute the process.
        /// </summary>
        /// <param name="cancellationToken"></param>
        public override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (await _singleServerProcessService.ShouldThisServerRunForProcessAsync(this.GetType().AssemblyQualifiedName))
                await base.ExecuteAsync(cancellationToken);
        }
    }
}