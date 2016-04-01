using System.Data.Entity;
using DocumentProcessing.Model;

namespace DocumentProcessing.Interfaces
{
    public interface IServiceLogContext
    {
        int GetLog();

        void Info(LogEntry log);

        void Fatal(FaultEntry fault);
    }
}