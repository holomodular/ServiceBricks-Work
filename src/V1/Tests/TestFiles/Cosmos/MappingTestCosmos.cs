
using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class MappingTestCosmos
    {
        public virtual ISystemManager SystemManager { get; set; }

        public MappingTestCosmos()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(StartupCosmos));
        }

        [Fact]
        public virtual Task ValidateMapperConfiguration()
        {
            var mapper = SystemManager.ServiceProvider.GetRequiredService<IMapper>();
            
            return Task.CompletedTask;
        }

        [Fact]
        public virtual async Task Test()
        {
            var service = SystemManager.ServiceProvider.GetRequiredService<IProcessApiService>();

            var resp = await service.CreateAsync(new ProcessDto() { });

            
        }

    }
}
