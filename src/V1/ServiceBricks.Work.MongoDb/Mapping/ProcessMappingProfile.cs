namespace ServiceBricks.Work.MongoDb
{
    /// <summary>
    /// This is an automapper profile for the Process domain object.
    /// </summary>
    public partial class ProcessMappingProfile
    {
        /// <summary>
        /// Register the mapping
        /// </summary>
        public static void Register(IMapperRegistry registry)
        {
            registry.Register<Process, ProcessDto>(
                (s, d) =>
                {
                    d.CreateDate = s.CreateDate;
                    d.FutureProcessDate = s.FutureProcessDate;
                    d.IsComplete = s.IsComplete;
                    d.IsError = s.IsError;
                    d.IsProcessing = s.IsProcessing;
                    d.ProcessData = s.ProcessData;
                    d.ProcessDate = s.ProcessDate;
                    d.ProcessQueue = s.ProcessQueue;
                    d.ProcessResponse = s.ProcessResponse;
                    d.ProcessType = s.ProcessType;
                    d.RetryCount = s.RetryCount;
                    d.StorageKey = s.Key.ToString();
                    d.UpdateDate = s.UpdateDate;
                });
            registry.Register<ProcessDto, Process>(
                (s, d) =>
                {
                    //d.CreateDate ignore by rule
                    d.FutureProcessDate = s.FutureProcessDate;
                    d.IsComplete = s.IsComplete;
                    d.IsError = s.IsError;
                    d.IsProcessing = s.IsProcessing;
                    d.ProcessData = s.ProcessData;
                    d.ProcessDate = s.ProcessDate;
                    d.ProcessQueue = s.ProcessQueue;
                    d.ProcessResponse = s.ProcessResponse;
                    d.ProcessType = s.ProcessType;
                    d.RetryCount = s.RetryCount;                    
                    d.Key = s.StorageKey;
                    d.UpdateDate = s.UpdateDate;
                });
        }
    }
}
