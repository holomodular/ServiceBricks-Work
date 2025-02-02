using Microsoft.Extensions.Logging;
using ServiceBricks.Cache;

namespace ServiceBricks.Work
{
    /// <summary>
    /// This is a service for processing a domain object table like a queue.
    /// </summary>
    /// <typeparam name="TDomainObject"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract partial class LockedWorkProcessService : WorkProcessService
    {
        protected readonly ISemaphoreService _semaphoreService;

        /// <summary>
        /// Consrtuctor.
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="repository"></param>
        /// <param name="semaphoreService"></param>
        public LockedWorkProcessService(
            ILoggerFactory loggerFactory,
            IApiService<ProcessDto> apiService,
            ISemaphoreService semaphoreService) : base(loggerFactory, apiService)
        {
            _semaphoreService = semaphoreService;
            SemaphoreLockName = this.GetType().AssemblyQualifiedName;
        }

        /// <summary>
        /// The name of the semaphore lock name used for locking.
        /// </summary>
        public virtual string SemaphoreLockName { get; set; }

        /// <summary>
        /// Get the list of queue items to process
        /// </summary>
        /// <param name="batchNumberToTake"></param>
        /// <param name="pickupErrors"></param>
        /// <param name="errorPickupCutoffDate"></param>
        /// <returns></returns>
        public override async Task<IResponseList<ProcessDto>> GetQueueItemsAsync(int batchNumberToTake, bool pickupErrors, DateTimeOffset errorPickupCutoffDate)
        {
            // Lock this object type so other types won't touch records
            var lockAcquired = await _semaphoreService.AcquireLockAsync(SemaphoreLockName);
            if (lockAcquired)
            {
                var resp = await base.GetQueueItemsAsync(batchNumberToTake, pickupErrors, errorPickupCutoffDate);
                await _semaphoreService.ReleaseLockAsync(SemaphoreLockName);
                return resp;
            }
            return new ResponseList<ProcessDto>();
        }
    }
}