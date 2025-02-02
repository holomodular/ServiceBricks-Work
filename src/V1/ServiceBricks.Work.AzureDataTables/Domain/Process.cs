using ServiceBricks.Storage.AzureDataTables;

namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// The Process domain object.
    /// </summary>
    public partial class Process : AzureDataTablesDomainObject<Process> , IDpCreateDate, IDpUpdateDate
    {
            
        /// <summary>
        /// The entity storage key.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// This is the create date.
        /// </summary>
        public DateTimeOffset CreateDate { get; set; }

        /// <summary>
        /// This is the update date.
        /// </summary>
        public DateTimeOffset UpdateDate { get; set; }

        /// <summary>
        /// The queue name.
        /// </summary>
        public string ProcessQueue { get; set; }

        /// <summary>
        /// The work type.
        /// </summary>
        public string ProcessType { get; set; }

        /// <summary>
        /// The work details.
        /// </summary>
        public string ProcessData { get; set; }

        /// <summary>
        /// Determine if completed processing.
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Determine if an error occured.
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Determine if currently processing.
        /// </summary>
        public bool IsProcessing { get; set; }

        /// <summary>
        /// The retry count.
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// The processing date.
        /// </summary>
        public DateTimeOffset ProcessDate { get; set; }

        /// <summary>
        /// The future processing date.
        /// </summary>
        public DateTimeOffset FutureProcessDate { get; set; }

        /// <summary>
        /// The process response.
        /// </summary>
        public string ProcessResponse { get; set; }

    }
}
