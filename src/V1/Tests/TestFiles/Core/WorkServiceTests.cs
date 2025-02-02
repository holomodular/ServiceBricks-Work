using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceBricks.Work;
using ServiceQuery;

namespace ServiceBricks.Xunit
{
    [Collection(ServiceBricks.Xunit.Constants.SERVICEBRICKS_COLLECTION_NAME)]
    public abstract partial class WorkServiceTests
    {
        public virtual ISystemManager SystemManager { get; set; }

        public virtual ITestManager<ProcessDto> TestManager { get; set; }

        public class ExampleWorkService : WorkProcessService
        {
            public static int ProcessCalled;

            public ExampleWorkService(ILoggerFactory loggerFactory, IApiService<ProcessDto> apiService) : base(loggerFactory, apiService)
            {
            }

            public override Task<IResponse> ProcessItemAsync(ProcessDto dto)
            {
                ProcessCalled++;
                return Task.FromResult<IResponse>(new Response());
            }
        }

        [Fact]
        public virtual async Task ExampleWorkServiceTests_ProcessOne()
        {
            var processApiService = SystemManager.ServiceProvider.GetRequiredService<IProcessApiService>();
            var loggerFactory = SystemManager.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var exampleWorker = new ExampleWorkService(loggerFactory, processApiService);

            // Create
            var respCreate = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = exampleWorker.ProcessQueue
            });

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 0);

            await exampleWorker.ExecuteAsync(CancellationToken.None);

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 1);

            // Cleanup
            ExampleWorkService.ProcessCalled = 0;
            await processApiService.DeleteAsync(respCreate.Item.StorageKey);
        }

        [Fact]
        public virtual async Task ExampleWorkServiceTests_ProcessTwo()
        {
            var processApiService = SystemManager.ServiceProvider.GetRequiredService<IProcessApiService>();
            var loggerFactory = SystemManager.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var exampleWorker = new ExampleWorkService(loggerFactory, processApiService);

            // Create
            var respCreateOne = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = exampleWorker.ProcessQueue
            });
            var respCreateTwo = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = exampleWorker.ProcessQueue
            });

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 0);

            await exampleWorker.ExecuteAsync(CancellationToken.None);

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 2);

            // Cleanup
            ExampleWorkService.ProcessCalled = 0;
            await processApiService.DeleteAsync(respCreateOne.Item.StorageKey);
            await processApiService.DeleteAsync(respCreateTwo.Item.StorageKey);
        }

        [Fact]
        public virtual async Task ExampleWorkServiceTests_ProcessNoneWrongQueue()
        {
            var processApiService = SystemManager.ServiceProvider.GetRequiredService<IProcessApiService>();
            var loggerFactory = SystemManager.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var exampleWorker = new ExampleWorkService(loggerFactory, processApiService);

            // Create
            var respCreateOne = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = "test"
            });
            var respCreateTwo = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = null
            });
            var respCreateThree = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = string.Empty
            });

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 0);

            await exampleWorker.ExecuteAsync(CancellationToken.None);

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 0);

            // Cleanup
            ExampleWorkService.ProcessCalled = 0;
            await processApiService.DeleteAsync(respCreateOne.Item.StorageKey);
            await processApiService.DeleteAsync(respCreateTwo.Item.StorageKey);
            await processApiService.DeleteAsync(respCreateThree.Item.StorageKey);
        }

        [Fact]
        public virtual async Task ExampleWorkServiceTests_ProcessNullAndEmpty()
        {
            var processApiService = SystemManager.ServiceProvider.GetRequiredService<IProcessApiService>();
            var loggerFactory = SystemManager.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var exampleWorker = new ExampleWorkService(loggerFactory, processApiService);
            exampleWorker.ProcessQueue = null;

            // Create
            var respCreateOne = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = null
            });
            var respCreateTwo = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = string.Empty
            });

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 0);

            await exampleWorker.ExecuteAsync(CancellationToken.None);

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 2);

            // Cleanup
            ExampleWorkService.ProcessCalled = 0;
            await processApiService.DeleteAsync(respCreateOne.Item.StorageKey);
            await processApiService.DeleteAsync(respCreateTwo.Item.StorageKey);
        }

        [Fact]
        public virtual async Task ExampleWorkServiceTests_FixOrphan()
        {
            var processApiService = SystemManager.ServiceProvider.GetRequiredService<IProcessApiService>();
            var loggerFactory = SystemManager.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var exampleWorker = new ExampleWorkService(loggerFactory, processApiService);

            // Create
            var respCreateOrphan = await processApiService.CreateAsync(new ProcessDto()
            {
                IsProcessing = true,
                ProcessDate = DateTimeOffset.UtcNow.Subtract(ExampleWorkService.ORPHANED_RECORD_TIMEOUT),
                ProcessQueue = exampleWorker.ProcessQueue
            });
            var respCreateTwo = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = exampleWorker.ProcessQueue
            });

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 0);

            await exampleWorker.ExecuteAsync(CancellationToken.None);

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 2);

            // Cleanup
            ExampleWorkService.ProcessCalled = 0;
            await processApiService.DeleteAsync(respCreateOrphan.Item.StorageKey);
            await processApiService.DeleteAsync(respCreateTwo.Item.StorageKey);
        }

        [Fact]
        public virtual async Task ExampleWorkServiceTests_DontFixOrphan()
        {
            var processApiService = SystemManager.ServiceProvider.GetRequiredService<IProcessApiService>();
            var loggerFactory = SystemManager.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var exampleWorker = new ExampleWorkService(loggerFactory, processApiService);

            // Create
            var respCreateOrphan = await processApiService.CreateAsync(new ProcessDto()
            {
                IsProcessing = true,
                ProcessDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(1)),
                ProcessQueue = exampleWorker.ProcessQueue
            });
            var respCreateTwo = await processApiService.CreateAsync(new ProcessDto()
            {
                ProcessQueue = exampleWorker.ProcessQueue
            });

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 0);

            await exampleWorker.ExecuteAsync(CancellationToken.None);

            // Assert
            Assert.True(ExampleWorkService.ProcessCalled == 1);

            // Cleanup
            ExampleWorkService.ProcessCalled = 0;
            await processApiService.DeleteAsync(respCreateOrphan.Item.StorageKey);
            await processApiService.DeleteAsync(respCreateTwo.Item.StorageKey);
        }
    }
}