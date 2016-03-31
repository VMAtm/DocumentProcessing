using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Implementations
{
    public class LogOperationBehavior : IOperationBehavior
    {
        private readonly IDocumentLogger _logger;

        public LogOperationBehavior(IDocumentLogger logger)
        {
            _logger = logger;
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new LoggingInvoker(_logger, dispatchOperation.Invoker);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }
    }
}