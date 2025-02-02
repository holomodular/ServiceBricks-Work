using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceBricks.Storage.AzureDataTables;

namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// This is the storage repository for the WorkAzureDataTables module.
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public partial class WorkStorageRepository<TDomain> : AzureDataTablesStorageRepository<TDomain>
        where TDomain : class, IAzureDataTablesDomainObject<TDomain>, new()
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logFactory"></param>
        /// <param name="configuration"></param>
        public WorkStorageRepository(
            ILoggerFactory logFactory,
            IConfiguration configuration)
            : base(logFactory)
        {
            ConnectionString = configuration.GetAzureDataTablesConnectionString(WorkAzureDataTablesConstants.APPSETTING_CONNECTION_STRING);
            TableName = WorkAzureDataTablesConstants.GetTableName(typeof(TDomain).Name);
        }
    }
}
