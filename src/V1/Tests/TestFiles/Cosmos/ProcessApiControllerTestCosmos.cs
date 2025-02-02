using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class ProcessApiControllerTestCosmos : ProcessApiControllerTest
    {
        public ProcessApiControllerTestCosmos()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(StartupCosmos));
            TestManager = SystemManager.ServiceProvider.GetRequiredService<ITestManager<ProcessDto>>();
        }
    }
}
