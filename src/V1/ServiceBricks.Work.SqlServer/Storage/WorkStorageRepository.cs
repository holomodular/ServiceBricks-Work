using Microsoft.Extensions.Logging;
using ServiceBricks.Storage.EntityFrameworkCore;

namespace ServiceBricks.Work.SqlServer
{
    /// <summary>
    /// This is the storage repository for the WorkSqlServer module.
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public partial class WorkStorageRepository<TDomain> : EntityFrameworkCoreStorageRepository<TDomain>
        where TDomain : class, IEntityFrameworkCoreDomainObject<TDomain>, new()
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logFactory"></param>
        /// <param name="context"></param>
        public WorkStorageRepository(
            ILoggerFactory logFactory,
            WorkSqlServerContext context)
            : base(logFactory)
        {
            Context = context;
            DbSet = context.Set<TDomain>();
        }
    }
}
