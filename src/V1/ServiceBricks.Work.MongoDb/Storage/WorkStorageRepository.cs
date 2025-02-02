using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceBricks.Storage.MongoDb;

namespace ServiceBricks.Work.MongoDb
{
    /// <summary>
    /// This is the storage repository for the WorkMongoDb module.
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public partial class WorkStorageRepository<TDomain> : MongoDbStorageRepository<TDomain>
        where TDomain : class, IMongoDbDomainObject<TDomain>, new()
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
            ConnectionString = configuration.GetMongoDbConnectionString(WorkMongoDbConstants.APPSETTING_CONNECTION_STRING);
            DatabaseName = configuration.GetMongoDbDatabase(WorkMongoDbConstants.APPSETTING_DATABASE);
            CollectionName = WorkMongoDbConstants.GetCollectionName(typeof(TDomain).Name);
        }
    }
}
