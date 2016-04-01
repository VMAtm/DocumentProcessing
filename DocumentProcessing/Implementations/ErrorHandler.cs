using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Implementations
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly IDocumentLogger _logger;

        public ErrorHandler(IDocumentLogger logger)
        {
            _logger = logger;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
        }

        public bool HandleError(Exception error)
        {
            _logger.Fatal(error);
            return true;
        }
    }
}