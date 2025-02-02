using Microsoft.Extensions.DependencyInjection;
using ServiceBricks.Work;
using ServiceBricks.Work.Client.Xunit;

namespace ServiceBricks.Xunit.Integration
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public class ProcessApiClientReturnResponseTest : ApiClientReturnResponseTest<ProcessDto>
    {
        public ProcessApiClientReturnResponseTest()
        {
            SystemManager = ServiceBricksSystemManager.GetSystemManager(typeof(ClientStartup));
            TestManager = SystemManager.ServiceProvider.GetRequiredService<ITestManager<ProcessDto>>();
        }
    }
}
