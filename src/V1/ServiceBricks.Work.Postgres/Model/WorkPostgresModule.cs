using System.Reflection;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.Postgres
{
    /// <summary>
    /// The module definition for the WorkPostgres module.
    /// </summary>
    public partial class WorkPostgresModule : ServiceBricks.Module
    {
        public static WorkPostgresModule Instance = new WorkPostgresModule();

        /// <summary>
        /// Constructor for the WorkPostgres module.
        /// </summary>
        public WorkPostgresModule()
        {
            DependentModules = new List<IModule>()
            {
                WorkEntityFrameworkCoreModule.Instance
            };
        }
    }
}
