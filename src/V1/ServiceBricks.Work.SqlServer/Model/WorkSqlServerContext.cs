using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using ServiceBricks.Storage.EntityFrameworkCore;
using ServiceBricks.Work.EntityFrameworkCore;

// dotnet ef migrations add WorkV1 --context WorkSqlServerContext --startup-project ../Tests/MigrationsHost

namespace ServiceBricks.Work.SqlServer
{
    /// <summary>
    /// The database context for the WorkSqlServer module.
    /// </summary>
    public partial class WorkSqlServerContext : DbContext
    {
        protected DbContextOptions<WorkSqlServerContext> _options = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkSqlServerContext() : base()
        {
            var configBuider = new ConfigurationBuilder();
            configBuider.AddAppSettingsConfig();
            var configuration = configBuider.Build();

            var builder = new DbContextOptionsBuilder<WorkSqlServerContext>();
            string connectionString = configuration.GetSqlServerConnectionString(
                WorkSqlServerConstants.APPSETTING_CONNECTION_STRING);
            builder.UseSqlServer(connectionString, x =>
            {
                x.MigrationsAssembly(typeof(WorkSqlServerContext).Assembly.GetName().Name);
                x.EnableRetryOnFailure();
            });
            _options = builder.Options;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"></param>
        public WorkSqlServerContext(DbContextOptions<WorkSqlServerContext> options) : base(options)
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
            builder.HasDefaultSchema(WorkSqlServerConstants.DATABASE_SCHEMA_NAME);

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
        public virtual WorkSqlServerContext CreateDbContext(string[] args)
        {
            return new WorkSqlServerContext(_options);
        }
    }
}
