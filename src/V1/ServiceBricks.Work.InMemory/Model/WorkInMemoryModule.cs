using System.Reflection;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.InMemory
{
    /// <summary>
    /// The module definition for the WorkInMemory module.
    /// </summary>
    public partial class WorkInMemoryModule : ServiceBricks.Module
    {
        public static WorkInMemoryModule Instance = new WorkInMemoryModule();

        /// <summary>
        /// Constructor for the WorkInMemory module.
        /// </summary>
        public WorkInMemoryModule()
        {
            DependentModules = new List<IModule>()
            {
                WorkEntityFrameworkCoreModule.Instance
            };
        }
    }
}
