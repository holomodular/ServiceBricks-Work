using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceBricks.Work.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ServiceBricks.Work.Cosmos
{
    /// <summary>
    /// The database context for the WorkCosmos module.
    /// </summary>
    public partial class WorkCosmosContext : DbContext
    {
        protected DbContextOptions<WorkCosmosContext> _options = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"></param>
        public WorkCosmosContext(DbContextOptions<WorkCosmosContext> options) : base(options)
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
        builder.Entity<Process>().ToContainer(WorkCosmosConstants.GetContainerName(nameof(Process)));
        builder.Entity<Process>().HasPartitionKey(key => key.Key);

        }



        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if NET8_0_OR_GREATER
            optionsBuilder.ConfigureWarnings(w => w.Ignore(CosmosEventId.SyncNotSupported));
#endif

            base.OnConfiguring(optionsBuilder);
        }


        /// <summary>
        /// Create context.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual WorkCosmosContext CreateDbContext(string[] args)
        {
            return new WorkCosmosContext(_options);
        }
    }
}
