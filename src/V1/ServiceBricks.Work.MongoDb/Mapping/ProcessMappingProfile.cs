using AutoMapper;

namespace ServiceBricks.Work.MongoDb
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
                .ForMember(x => x.Key, y => y.MapFrom(z => z.StorageKey));

            CreateMap<Process, ProcessDto>()
                .ForMember(x => x.StorageKey, y => y.MapFrom(z => z.Key));
        }
    }
}
