using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using ServiceBricks.Storage.EntityFrameworkCore;
using ServiceBricks.Work.EntityFrameworkCore;

// dotnet ef migrations add WorkV1 --context WorkSqliteContext --startup-project ../Tests/MigrationsHost

namespace ServiceBricks.Work.Sqlite
{
    /// <summary>
    /// The database context for the WorkSqlite module.
    /// </summary>
    public partial class WorkSqliteContext : DbContext
    {
        protected DbContextOptions<WorkSqliteContext> _options = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkSqliteContext() : base()
        {
            var configBuider = new ConfigurationBuilder();
            configBuider.AddAppSettingsConfig();
            var configuration = configBuider.Build();

            var builder = new DbContextOptionsBuilder<WorkSqliteContext>();
            string connectionString = configuration.GetSqliteConnectionString(
                WorkSqliteConstants.APPSETTING_CONNECTION_STRING);
            builder.UseSqlite(connectionString, x =>
            {
                x.MigrationsAssembly(typeof(WorkSqliteContext).Assembly.GetName().Name);
            });
            _options = builder.Options;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"></param>
        public WorkSqliteContext(DbContextOptions<WorkSqliteContext> options) : base(options)
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
                .Properties<DateTimeOffset>()
                .HaveConversion<DateTimeOffsetToBytesConverter>();

            base.ConfigureConventions(configurationBuilder);
        }

        /// <summary>
        /// Create context.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual WorkSqliteContext CreateDbContext(string[] args)
        {
            return new WorkSqliteContext(_options);
        }
    }
}
