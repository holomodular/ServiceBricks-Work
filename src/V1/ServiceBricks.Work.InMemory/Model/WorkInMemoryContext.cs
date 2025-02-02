using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceBricks.Work.EntityFrameworkCore;

namespace ServiceBricks.Work.InMemory
{
    /// <summary>
    /// The database context for the WorkInMemory module.
    /// </summary>
    public partial class WorkInMemoryContext : DbContext
    {
        protected DbContextOptions<WorkInMemoryContext> _options = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkInMemoryContext() : base()
        {
            var configBuider = new ConfigurationBuilder();
            configBuider.AddAppSettingsConfig();
            var configuration = configBuider.Build();

            var builder = new DbContextOptionsBuilder<WorkInMemoryContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _options = builder.Options;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"></param>
        public WorkInMemoryContext(DbContextOptions<WorkInMemoryContext> options) : base(options)
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
            base.OnModelCreating(builder);

            // AI: Setup the entities to the model
            
            builder.Entity<Process>().HasKey(key => key.Key);

        }

        /// <summary>
        /// Create context.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual WorkInMemoryContext CreateDbContext(string[] args)
        {
            return new WorkInMemoryContext(_options);
        }
    }
}
