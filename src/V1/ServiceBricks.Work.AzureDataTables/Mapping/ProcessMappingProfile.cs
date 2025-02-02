using AutoMapper;
using ServiceBricks.Storage.AzureDataTables;

namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// This is an automapper profile for the Process domain object.
    /// </summary>
    public partial class ProcessMappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ProcessMappingProfile()
        {
            // AI: Add mappings
            CreateMap<ProcessDto, Process>()
                .ForMember(x => x.CreateDate, y => y.Ignore())
                .ForMember(x => x.PartitionKey, y => y.MapFrom<PartitionKeyResolver>())
                .ForMember(x => x.RowKey, y => y.MapFrom<RowKeyResolver>())
                .ForMember(x => x.ETag, y => y.Ignore())
                .ForMember(x => x.Timestamp, y => y.Ignore())
                .ForMember(x => x.Key, y => y.Ignore());

            CreateMap<Process, ProcessDto>()
                .ForMember(x => x.StorageKey, y => y.MapFrom<StorageKeyResolver>());
        }
    }
}