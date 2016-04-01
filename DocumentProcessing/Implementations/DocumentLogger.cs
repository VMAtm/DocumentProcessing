using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
            var incoming = OperationContext.Current.IncomingMessageProperties;
            var endpoint = incoming[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            _context.Info(new LogEntry
            {
                InputString = info,
                EventDate = DateTime.UtcNow,
                IPHost = endpoint?.Address,
                Port = endpoint?.Port ?? 0
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