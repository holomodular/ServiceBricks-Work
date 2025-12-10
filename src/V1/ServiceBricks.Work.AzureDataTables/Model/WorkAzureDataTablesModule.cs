using System.Reflection;

namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// The module definition for the WorkAzureDataTables module.
    /// </summary>
    public partial class WorkAzureDataTablesModule : ServiceBricks.Module
    {
        public static WorkAzureDataTablesModule Instance = new WorkAzureDataTablesModule();

        /// <summary>
        /// Constructor for the WorkAzureDataTables module.
        /// </summary>
        public WorkAzureDataTablesModule()
        {
            DependentModules = new List<IModule>()
            {
                WorkModule.Instance
            };
        }
    }
}
