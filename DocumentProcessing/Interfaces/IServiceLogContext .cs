using System.Data.Entity;
using DocumentProcessing.Model;

namespace DocumentProcessing.Interfaces
{
    public interface IServiceLogContext
    {
        DbSet<LogEntry> LogEntries { get; set; }
        DbSet<FaultEntry> Faults { get; set; }
    }
}