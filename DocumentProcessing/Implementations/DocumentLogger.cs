using System;
using System.Data.Entity;
using DocumentProcessing.Interfaces;
using DocumentProcessing.Model;

namespace DocumentProcessing.Implementations
{
    public class DocumentLogger : IDocumentLogger
    {
        private readonly IServiceLogContext _context;

        public DocumentLogger(IServiceLogContext context)
        {
            _context = context;
        }

        public void Info(string info)
        {
            _context.Info(new LogEntry
            {
                InputString = info,
                EventDate = DateTime.UtcNow,
                IPHost = "",
                Port = 0
            });
        }

        public void Fatal(Exception exception)
        {
            _context.Fatal(new FaultEntry
            {
                StackTrace = exception.ToString()
            });
        }
    }
}