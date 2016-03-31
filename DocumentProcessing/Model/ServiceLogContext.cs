using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Model
{
    public class ServiceLogContext : DbContext, IServiceLogContext
    {
        //public ServiceLogContext() : base("name=ServiceLogContext")
        //{
        //}

        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<FaultEntry> Faults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}