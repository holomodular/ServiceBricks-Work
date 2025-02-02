namespace ServiceBricks.Work
{
    /// <summary>
    /// The module definition for the Work module.
    /// </summary>
    public partial class WorkModule : ServiceBricks.Module
    {
        public static WorkModule Instance = new WorkModule();

        public WorkModule()
        {
            DataTransferObjects = new List<Type>()
            {
                
                typeof(ProcessDto),
            };
        }
    }
}
