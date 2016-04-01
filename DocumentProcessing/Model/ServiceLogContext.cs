using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Model
{
    public class ServiceLogContext : DbContext, IServiceLogContext
    {
        public ServiceLogContext(string connectionString)
            : base(connectionString)
        {
            Database.CreateIfNotExists();
        }

        public int GetLog()
        {
            return LogEntries.Select(i => i.ID).Count();
        }

        public void Info(LogEntry log)
        {
            LogEntries.Add(log);
            SaveChanges();
        }

        public void Fatal(FaultEntry fault)
        {
            Faults.Add(fault);
            SaveChanges();
        }

        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<FaultEntry> Faults { get; set; }
        // ReSharper restore MemberCanBePrivate.Global
        // ReSharper restore UnusedAutoPropertyAccessor.Global

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}