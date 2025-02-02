using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class WorkServiceTestsInMemory : WorkServiceTests
    {
        public WorkServiceTestsInMemory()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(StartupInMemory));
            TestManager = SystemManager.ServiceProvider.GetRequiredService<ITestManager<ProcessDto>>();
        }
    }
}