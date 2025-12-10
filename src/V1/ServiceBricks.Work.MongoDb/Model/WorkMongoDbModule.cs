using System.Reflection;

namespace ServiceBricks.Work.MongoDb
{
    /// <summary>
    /// The module definition for the WorkMongoDb module.
    /// </summary>
    public partial class WorkMongoDbModule : ServiceBricks.Module
    {
        public static WorkMongoDbModule Instance = new WorkMongoDbModule();

        /// <summary>
        /// Constructor for the WorkMongoDb module.
        /// </summary>
        public WorkMongoDbModule()
        {
            DependentModules = new List<IModule>()
            {
                WorkModule.Instance
            };
        }
    }
}
