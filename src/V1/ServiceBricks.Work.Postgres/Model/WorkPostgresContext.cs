using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using ServiceBricks.Storage.EntityFrameworkCore;
using ServiceBricks.Work.EntityFrameworkCore;

// dotnet ef migrations add WorkV1 --context WorkPostgresContext --startup-project ../Tests/MigrationsHost

namespace ServiceBricks.Work.Postgres
{
    /// <summary>
    /// The database context for the WorkPostgres module.
    /// </summary>
    public partial class WorkPostgresContext : DbContext
    {
        protected DbContextOptions<WorkPostgresContext> _options = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkPostgresContext() : base()
        {
            var configBuider = new ConfigurationBuilder();
            configBuider.AddAppSettingsConfig();
            var configuration = configBuider.Build();

            var builder = new DbContextOptionsBuilder<WorkPostgresContext>();
            string connectionString = configuration.GetPostgresConnectionString(
                WorkPostgresConstants.APPSETTING_CONNECTION_STRING);
            builder.UseNpgsql(connectionString, x =>
            {
                x.MigrationsAssembly(typeof(WorkPostgresContext).Assembly.GetName().Name);
                x.EnableRetryOnFailure();
            });
            _options = builder.Options;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"></param>
        public WorkPostgresContext(DbContextOptions<WorkPostgresContext> options) : base(options)
        {
            _options = options;
        }

        
        /// <summary>
        /// This defines a process to be run.
        /// </summary>
        public virtual DbSet<Process> Process { get; set; }


        /// <summary>
        /// OnModelCreating.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // AI: Set the default schema
            builder.HasDefaultSchema(WorkPostgresConstants.DATABASE_SCHEMA_NAME);

            // AI: Setup the entities to the model
            
            builder.Entity<Process>().HasKey(key => key.Key);


            base.OnModelCreating(builder);
        }

        /// <summary>
        /// Configure conventions
        /// </summary>
        /// <param name="configurationBuilder"></param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<TimeSpan>()
                .HaveConversion<long>();

            base.ConfigureConventions(configurationBuilder);
        }

        /// <summary>
        /// Create context.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual WorkPostgresContext CreateDbContext(string[] args)
        {
            return new WorkPostgresContext(_options);
        }
    }
}
