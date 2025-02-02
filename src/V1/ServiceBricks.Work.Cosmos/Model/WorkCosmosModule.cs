using System.Reflection;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.Cosmos
{
    /// <summary>
    /// The module definition for the WorkCosmos module.
    /// </summary>
    public partial class WorkCosmosModule : ServiceBricks.Module
    {
        public static WorkCosmosModule Instance = new WorkCosmosModule();

        /// <summary>
        /// Constructor for the WorkCosmos module.
        /// </summary>
        public WorkCosmosModule()
        {
            DependentModules = new List<IModule>()
            {
                WorkEntityFrameworkCoreModule.Instance
            };
        }
    }
}
