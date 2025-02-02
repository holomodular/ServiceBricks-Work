using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class ProcessApiControllerTestMongoDb : ProcessApiControllerTest
    {
        public ProcessApiControllerTestMongoDb()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(StartupMongoDb));
            TestManager = SystemManager.ServiceProvider.GetRequiredService<ITestManager<ProcessDto>>();
        }
    }
}
