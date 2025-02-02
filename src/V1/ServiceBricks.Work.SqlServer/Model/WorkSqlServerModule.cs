using System.Reflection;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.SqlServer
{
    /// <summary>
    /// The module definition for the WorkSqlServer module.
    /// </summary>
    public partial class WorkSqlServerModule : ServiceBricks.Module
    {
        public static WorkSqlServerModule Instance = new WorkSqlServerModule();

        /// <summary>
        /// Constructor for the WorkSqlServer module.
        /// </summary>
        public WorkSqlServerModule()
        {
            DependentModules = new List<IModule>()
            {
                WorkEntityFrameworkCoreModule.Instance
            };
        }
    }
}
