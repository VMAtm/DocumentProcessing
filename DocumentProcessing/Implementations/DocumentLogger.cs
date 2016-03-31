using System;
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
            _context.LogEntries.Add(new LogEntry());
        }

        public void Fatal(Exception exception)
        {
            _context.Faults.Add(new FaultEntry());
        }
    }
}