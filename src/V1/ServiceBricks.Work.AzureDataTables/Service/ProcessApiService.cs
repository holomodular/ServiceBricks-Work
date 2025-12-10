namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// This is a REST API service for ProcessDto.
    /// </summary>
    public partial class ProcessApiService : ApiService<Process, ProcessDto>, IProcessApiService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="businessRuleService"></param>
        /// <param name="repository"></param>
        public ProcessApiService(
            IMapper mapper,
            IBusinessRuleService businessRuleService,
            IDomainRepository<Process> repository)
            : base(mapper, businessRuleService, repository)
        {
        }
    }
}
