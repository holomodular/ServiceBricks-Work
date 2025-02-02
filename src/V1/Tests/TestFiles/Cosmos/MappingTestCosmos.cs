
using Microsoft.Extensions.DependencyInjection;

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
        public virtual Task ValidateAutomapperConfiguration()
        {
            var mapper = SystemManager.ServiceProvider.GetRequiredService<AutoMapper.IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return Task.CompletedTask;
        }
    }
}
