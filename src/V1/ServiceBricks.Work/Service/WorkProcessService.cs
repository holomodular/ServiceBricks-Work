using Microsoft.Extensions.Logging;
using ServiceQuery;

namespace ServiceBricks.Work
{
    /// <summary>
    /// This is a service for processing a domain object table like a queue.
    /// </summary>
    /// <typeparam name="TDomainObject"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract partial class WorkProcessService : WorkService<ProcessDto>
    {
        /// <summary>
        /// Consrtuctor.
        /// </summary>
        /// <param name="loggerFactory"></param>
        /// <param name="repository"></param>
        public WorkProcessService(
            ILoggerFactory loggerFactory,
            IApiService<ProcessDto> apiService) : base(loggerFactory, apiService)
        {
            ProcessQueue = this.GetType().AssemblyQualifiedName;
        }

        /// <summary>
        /// The name of the process queue
        /// </summary>
        public virtual string ProcessQueue { get; set; }

        /// <summary>
        /// Get the query to pickup items from the queue.
        /// </summary>
        /// <param name="batchNumberToTake"></param>
        /// <param name="pickupErrors"></param>
        /// <param name="errorPickupCutoffDate"></param>
        /// <returns></returns>
        protected override ServiceQueryRequest GetQueueItemsQuery(int batchNumberToTake, bool pickupErrors, DateTimeOffset errorPickupCutoffDate)
        {
            // Add an additional filter for the process queue name
            var req = base.GetQueueItemsQuery(batchNumberToTake, pickupErrors, errorPickupCutoffDate);
            var additionalReqBuilder = new ServiceQueryRequestBuilder();
            if (string.IsNullOrEmpty(ProcessQueue))
            {
                // Treat null and empty string as the same queue
                additionalReqBuilder
                .And()
                .Begin()
                    .IsNull(nameof(ProcessDto.ProcessQueue))
                    .Or()
                    .IsEqual(nameof(ProcessDto.ProcessQueue), "")
                .End();
            }
            else
            {
                additionalReqBuilder
                .And()
                .IsEqual(nameof(ProcessDto.ProcessQueue), this.ProcessQueue);
            }

            var addReq = additionalReqBuilder.Build();
            req.Filters.AddRange(addReq.Filters);
            return req;
        }
    }
}