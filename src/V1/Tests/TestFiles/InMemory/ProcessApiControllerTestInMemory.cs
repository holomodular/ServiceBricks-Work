using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class ProcessApiControllerTestInMemory : ProcessApiControllerTest
    {
        public ProcessApiControllerTestInMemory()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(StartupInMemory));
            TestManager = SystemManager.ServiceProvider.GetRequiredService<ITestManager<ProcessDto>>();
        }
    }
}
