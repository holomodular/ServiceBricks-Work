using Microsoft.Extensions.DependencyInjection;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class MappingTestMongoDb
    {
        public virtual ISystemManager SystemManager { get; set; }

        public MappingTestMongoDb()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(StartupMongoDb));
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
