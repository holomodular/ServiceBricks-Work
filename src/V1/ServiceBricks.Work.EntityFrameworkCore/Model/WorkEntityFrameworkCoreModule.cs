using System.Reflection;

namespace ServiceBricks.Work.EntityFrameworkCore
{
    /// <summary>
    /// The module definition for the WorkEntityFrameworkCore module.
    /// </summary>
    public partial class WorkEntityFrameworkCoreModule : ServiceBricks.Module
    {
        public static WorkEntityFrameworkCoreModule Instance = new WorkEntityFrameworkCoreModule();

        /// <summary>
        /// Constructor for the WorkEntityFrameworkCore module.
        /// </summary>
        public WorkEntityFrameworkCoreModule()
        {
            AutomapperAssemblies = new List<Assembly>()
            {
                typeof(WorkEntityFrameworkCoreModule).Assembly
            };
            DependentModules = new List<IModule>()
            {
                WorkModule.Instance
            };
        }
    }
}
