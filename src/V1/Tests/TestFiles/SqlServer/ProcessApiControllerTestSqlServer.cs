using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class ProcessApiControllerTestSqlServer : ProcessApiControllerTest
    {
        public ProcessApiControllerTestSqlServer()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(StartupSqlServer));
            TestManager = SystemManager.ServiceProvider.GetRequiredService<ITestManager<ProcessDto>>();
        }
    }
}
