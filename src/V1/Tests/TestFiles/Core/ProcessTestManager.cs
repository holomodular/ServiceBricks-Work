using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceBricks.Work;
using ServiceQuery;

namespace ServiceBricks.Xunit
{
    public class ProcessTestManagerMongoDb : ProcessTestManager
    {
        public override ProcessDto GetObjectNotFound()
        {
            return new ProcessDto()
            {
                StorageKey = "000000000000000000000000"
            };
        }

        public override void ValidateObjects(ProcessDto clientDto, ProcessDto serviceDto, HttpMethod method)
        {

            //PrimaryKeyRule
            if (method == HttpMethod.Post)
                Assert.True(!string.IsNullOrEmpty(serviceDto.StorageKey));
            else
                Assert.True(serviceDto.StorageKey == clientDto.StorageKey);


            //CreateDateRule
            if (method == HttpMethod.Post)
                Assert.True(serviceDto.CreateDate > clientDto.CreateDate);
            else
                Assert.True(serviceDto.CreateDate == clientDto.CreateDate);


            //UpdateDateRule
            if (method == HttpMethod.Post || method == HttpMethod.Put)
                Assert.True(serviceDto.UpdateDate > clientDto.UpdateDate);
            else
                Assert.True(serviceDto.UpdateDate == clientDto.UpdateDate);


            Assert.True(serviceDto.ProcessQueue == clientDto.ProcessQueue);

            Assert.True(serviceDto.ProcessType == clientDto.ProcessType);

            Assert.True(serviceDto.ProcessData == clientDto.ProcessData);

            Assert.True(serviceDto.IsComplete == clientDto.IsComplete);

            Assert.True(serviceDto.IsError == clientDto.IsError);

            Assert.True(serviceDto.IsProcessing == clientDto.IsProcessing);

            Assert.True(serviceDto.RetryCount == clientDto.RetryCount);
long proputcTicks = 0;

            Assert.True(serviceDto.ProcessDate == clientDto.ProcessDate);

            Assert.True(serviceDto.FutureProcessDate == clientDto.FutureProcessDate);

            Assert.True(serviceDto.ProcessResponse == clientDto.ProcessResponse);

        }
    }

    public class ProcessTestManagerPostgres : ProcessTestManager
    {
        public override void ValidateObjects(ProcessDto clientDto, ProcessDto serviceDto, HttpMethod method)
        {

            //PrimaryKeyRule
            if (method == HttpMethod.Post)
                Assert.True(!string.IsNullOrEmpty(serviceDto.StorageKey));
            else
                Assert.True(serviceDto.StorageKey == clientDto.StorageKey);


            //CreateDateRule
            if (method == HttpMethod.Post)
                Assert.True(serviceDto.CreateDate.UtcTicks >= ((long)(clientDto.CreateDate.UtcTicks / 10)) * 10);
            else if (method == HttpMethod.Get)
            {
                // Postgres special handling
                long utcTicks = serviceDto.CreateDate.UtcTicks;
                utcTicks = ((long)(utcTicks / 10)) * 10;
                Assert.True(utcTicks == clientDto.CreateDate.UtcTicks);
            }
            else
                Assert.True(serviceDto.CreateDate == clientDto.CreateDate);


            //UpdateDateRule
            if (method == HttpMethod.Post || method == HttpMethod.Put)
                Assert.True(serviceDto.UpdateDate.UtcTicks >= ((long)(clientDto.CreateDate.UtcTicks / 10)) * 10);
            else
            {
                // Postgres special handling
                long utcTicks = serviceDto.UpdateDate.UtcTicks;
                utcTicks = ((long)(utcTicks / 10)) * 10;
                Assert.True(utcTicks == clientDto.UpdateDate.UtcTicks);
            }


            Assert.True(serviceDto.ProcessQueue == clientDto.ProcessQueue);

            Assert.True(serviceDto.ProcessType == clientDto.ProcessType);

            Assert.True(serviceDto.ProcessData == clientDto.ProcessData);

            Assert.True(serviceDto.IsComplete == clientDto.IsComplete);

            Assert.True(serviceDto.IsError == clientDto.IsError);

            Assert.True(serviceDto.IsProcessing == clientDto.IsProcessing);

            Assert.True(serviceDto.RetryCount == clientDto.RetryCount);
long proputcTicks = 0;

                // Postgres special handling
                if (method == HttpMethod.Post)
                {
                    // Postgres special handling
                    long utcTicks = clientDto.ProcessDate.UtcTicks;
                    utcTicks = ((long)(utcTicks / 10)) * 10;
                    Assert.True(serviceDto.ProcessDate.UtcTicks >= utcTicks);
                }
                else if (method == HttpMethod.Put)
                {
                    // Postgres special handling
                    long utcTicks = clientDto.ProcessDate.UtcTicks;
                    utcTicks = ((long)(utcTicks / 10)) * 10;
                    Assert.True(utcTicks == serviceDto.ProcessDate.UtcTicks);
                }
                else if (method == HttpMethod.Get)
                {
                    // Postgres special handling
                    long utcTicks = serviceDto.ProcessDate.UtcTicks;
                    utcTicks = ((long)(utcTicks / 10)) * 10;
                    Assert.True(utcTicks == clientDto.ProcessDate.UtcTicks);
                }

                // Postgres special handling
                if (method == HttpMethod.Post)
                {
                    // Postgres special handling
                    long utcTicks = clientDto.FutureProcessDate.UtcTicks;
                    utcTicks = ((long)(utcTicks / 10)) * 10;
                    Assert.True(serviceDto.FutureProcessDate.UtcTicks >= utcTicks);
                }
                else if (method == HttpMethod.Put)
                {
                    // Postgres special handling
                    long utcTicks = clientDto.FutureProcessDate.UtcTicks;
                    utcTicks = ((long)(utcTicks / 10)) * 10;
                    Assert.True(utcTicks == serviceDto.FutureProcessDate.UtcTicks);
                }
                else if (method == HttpMethod.Get)
                {
                    // Postgres special handling
                    long utcTicks = serviceDto.FutureProcessDate.UtcTicks;
                    utcTicks = ((long)(utcTicks / 10)) * 10;
                    Assert.True(utcTicks == clientDto.FutureProcessDate.UtcTicks);
                }

            Assert.True(serviceDto.ProcessResponse == clientDto.ProcessResponse);

        }
    }

    public class ProcessTestManagerAzureDataTables : ProcessTestManager
    {
        public override void ValidateObjects(ProcessDto clientDto, ProcessDto serviceDto, HttpMethod method)
        {
            DateTimeOffset dateTimeOffsetMinDate = new DateTimeOffset(1601, 1, 1, 0, 0, 0, TimeSpan.Zero);
            DateTime dateTimeMinDate = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateOnly dateOnlyMinDate = new DateOnly(1601, 1, 1);


            //PrimaryKeyRule
            if (method == HttpMethod.Post)
                Assert.True(!string.IsNullOrEmpty(serviceDto.StorageKey));
            else
                Assert.True(serviceDto.StorageKey == clientDto.StorageKey);


            //CreateDateRule
            if (method == HttpMethod.Post)
                Assert.True(serviceDto.CreateDate > clientDto.CreateDate);
            else
                Assert.True(serviceDto.CreateDate == clientDto.CreateDate);


            //UpdateDateRule
            if (method == HttpMethod.Post || method == HttpMethod.Put)
                Assert.True(serviceDto.UpdateDate > clientDto.UpdateDate);
            else
                Assert.True(serviceDto.UpdateDate == clientDto.UpdateDate);


            Assert.True(serviceDto.ProcessQueue == clientDto.ProcessQueue);

            Assert.True(serviceDto.ProcessType == clientDto.ProcessType);

            Assert.True(serviceDto.ProcessData == clientDto.ProcessData);

            Assert.True(serviceDto.IsComplete == clientDto.IsComplete);

            Assert.True(serviceDto.IsError == clientDto.IsError);

            Assert.True(serviceDto.IsProcessing == clientDto.IsProcessing);

            Assert.True(serviceDto.RetryCount == clientDto.RetryCount);

                // AzureDataTables special handling
                if (clientDto.ProcessDate < dateTimeMinDate)
                    Assert.True(serviceDto.ProcessDate == dateTimeMinDate);
                else
                    Assert.True(serviceDto.ProcessDate == clientDto.ProcessDate);

                // AzureDataTables special handling
                if (clientDto.FutureProcessDate < dateTimeMinDate)
                    Assert.True(serviceDto.FutureProcessDate == dateTimeMinDate);
                else
                    Assert.True(serviceDto.FutureProcessDate == clientDto.FutureProcessDate);

            Assert.True(serviceDto.ProcessResponse == clientDto.ProcessResponse);

        }
    }

    public class ProcessTestManager : TestManager<ProcessDto>
    {
        public override ProcessDto GetObjectNotFound()
        {
            return new ProcessDto
            {
                StorageKey = Guid.NewGuid().ToString().ToString()
            };
        }

        public override ProcessDto GetMinimumDataObject()
        {
            return new ProcessDto()
            {

            ProcessDate = DateTimeOffset.UtcNow,
            FutureProcessDate = DateTimeOffset.UtcNow,
            };
        }

        public override ProcessDto GetMaximumDataObject()
        {
            var model = new ProcessDto()
            {

            CreateDate = DateTimeOffset.UtcNow,
            UpdateDate = DateTimeOffset.UtcNow,
            ProcessQueue = Guid.NewGuid().ToString(),
            ProcessType = Guid.NewGuid().ToString(),
            ProcessData = Guid.NewGuid().ToString(),
            IsComplete = true,
            IsError = true,
            IsProcessing = true,
            RetryCount = 1,
            ProcessDate = DateTimeOffset.UtcNow,
            FutureProcessDate = DateTimeOffset.UtcNow,
            ProcessResponse = Guid.NewGuid().ToString(),
            };
            return model;
        }

        public override IApiController<ProcessDto> GetController(IServiceProvider serviceProvider)
        {
            var options = new OptionsWrapper<ApiOptions>(new ApiOptions() { ReturnResponseObject = false, ExposeSystemErrors = true });
            return new ProcessApiController(serviceProvider.GetRequiredService<IProcessApiService>(), options);
        }

        public override IApiController<ProcessDto> GetControllerReturnResponse(IServiceProvider serviceProvider)
        {
            var options = new OptionsWrapper<ApiOptions>(new ApiOptions() { ReturnResponseObject = true, ExposeSystemErrors = true });
            return new ProcessApiController(serviceProvider.GetRequiredService<IProcessApiService>(), options);
        }

        public override IApiClient<ProcessDto> GetClient(IServiceProvider serviceProvider)
        {
            return new ProcessApiClient(
                serviceProvider.GetRequiredService<ILoggerFactory>(),
                serviceProvider.GetRequiredService<IHttpClientFactory>(),
                serviceProvider.GetRequiredService<IConfiguration>());
        }

        public override IApiClient<ProcessDto> GetClientReturnResponse(IServiceProvider serviceProvider)
        {
            return new ProcessApiClient(
                serviceProvider.GetRequiredService<ILoggerFactory>(),
                serviceProvider.GetRequiredService<IHttpClientFactory>(),
                serviceProvider.GetRequiredService<IConfiguration>());
        }

        public override IApiService<ProcessDto> GetService(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IProcessApiService>();
        }

        public override void UpdateObject(ProcessDto dto)
        {

            dto.ProcessQueue = Guid.NewGuid().ToString();
            dto.ProcessType = Guid.NewGuid().ToString();
            dto.ProcessData = Guid.NewGuid().ToString();
            dto.IsComplete = false;
            dto.IsError = false;
            dto.IsProcessing = false;
            dto.RetryCount = 0;
            dto.ProcessDate = DateTimeOffset.UtcNow;
            dto.FutureProcessDate = DateTimeOffset.UtcNow;
            dto.ProcessResponse = Guid.NewGuid().ToString();
        }

        public override void ValidateObjects(ProcessDto clientDto, ProcessDto serviceDto, HttpMethod method)
        {

            //PrimaryKeyRule
            if (method == HttpMethod.Post)
                Assert.True(!string.IsNullOrEmpty(serviceDto.StorageKey));
            else
                Assert.True(serviceDto.StorageKey == clientDto.StorageKey);


            //CreateDateRule
            if (method == HttpMethod.Post)
                Assert.True(serviceDto.CreateDate > clientDto.CreateDate);
            else
                Assert.True(serviceDto.CreateDate == clientDto.CreateDate);


            //UpdateDateRule
            if (method == HttpMethod.Post || method == HttpMethod.Put)
                Assert.True(serviceDto.UpdateDate > clientDto.UpdateDate);
            else
                Assert.True(serviceDto.UpdateDate == clientDto.UpdateDate);


            Assert.True(serviceDto.ProcessQueue == clientDto.ProcessQueue);

            Assert.True(serviceDto.ProcessType == clientDto.ProcessType);

            Assert.True(serviceDto.ProcessData == clientDto.ProcessData);

            Assert.True(serviceDto.IsComplete == clientDto.IsComplete);

            Assert.True(serviceDto.IsError == clientDto.IsError);

            Assert.True(serviceDto.IsProcessing == clientDto.IsProcessing);

            Assert.True(serviceDto.RetryCount == clientDto.RetryCount);

            Assert.True(serviceDto.ProcessDate == clientDto.ProcessDate);

            Assert.True(serviceDto.FutureProcessDate == clientDto.FutureProcessDate);

            Assert.True(serviceDto.ProcessResponse == clientDto.ProcessResponse);

        }

        public override List<ServiceQueryRequest> GetQueriesForObject(ProcessDto dto)
        {
            List<ServiceQueryRequest> queries = new List<ServiceQueryRequest>();
            IServiceQueryRequestBuilder qb = null;


            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.StorageKey), dto.StorageKey.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.CreateDate), dto.CreateDate.ToString("o"));
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.UpdateDate), dto.UpdateDate.ToString("o"));
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.ProcessQueue), dto.ProcessQueue.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.ProcessType), dto.ProcessType.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.ProcessData), dto.ProcessData.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.IsComplete), dto.IsComplete.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.IsError), dto.IsError.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.IsProcessing), dto.IsProcessing.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.RetryCount), dto.RetryCount.ToString());
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.ProcessDate), dto.ProcessDate.ToString("o"));
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.FutureProcessDate), dto.FutureProcessDate.ToString("o"));
            queries.Add(qb.Build());

            qb = ServiceQueryRequestBuilder.New().
                IsEqual(nameof(ProcessDto.ProcessResponse), dto.ProcessResponse.ToString());
            queries.Add(qb.Build());


            return queries;
        }
    }
}
