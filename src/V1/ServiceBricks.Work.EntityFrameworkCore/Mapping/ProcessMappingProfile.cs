using AutoMapper;

namespace ServiceBricks.Work.EntityFrameworkCore
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
                .ForMember(x => x.Key, y => y.MapFrom<KeyResolver>());

            CreateMap<Process, ProcessDto>()
                .ForMember(x => x.StorageKey, y => y.MapFrom(z => z.Key));
        }


        /// <summary>
        /// Resolver for the Process mapping.
        /// </summary>
        public class KeyResolver : IValueResolver<DataTransferObject, object, Guid>
        {
            /// <summary>
            /// Resolve the key from the StorageKey property.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="destination"></param>
            /// <param name="sourceMember"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public Guid Resolve(DataTransferObject source, object destination, Guid sourceMember, ResolutionContext context)
            {
                if (string.IsNullOrEmpty(source.StorageKey))
                    return Guid.Empty;

                // AI: Parse the value and make sure it is valid
                Guid tempKey;
                if (Guid.TryParse(source.StorageKey, out tempKey))
                    return tempKey;
                return Guid.Empty;
            }
        }

    }
}
