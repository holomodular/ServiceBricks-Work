using System.Reflection;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.Sqlite
{
    /// <summary>
    /// The module definition for the WorkSqlite module.
    /// </summary>
    public partial class WorkSqliteModule : ServiceBricks.Module
    {
        public static WorkSqliteModule Instance = new WorkSqliteModule();

        /// <summary>
        /// Constructor for the WorkSqlite module.
        /// </summary>
        public WorkSqliteModule()
        {
            DependentModules = new List<IModule>()
            {
                WorkEntityFrameworkCoreModule.Instance
            };
        }
    }
}
