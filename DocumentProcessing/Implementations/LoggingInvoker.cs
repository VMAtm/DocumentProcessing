using System;
using System.Linq;
using System.ServiceModel.Dispatcher;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Implementations
{
    public class LoggingInvoker : IOperationInvoker
    {
        private readonly IDocumentLogger _logger;
        private readonly IOperationInvoker _invoker;

        public LoggingInvoker(IDocumentLogger logger, IOperationInvoker invoker)
        {
            _logger = logger;
            _invoker = invoker;
        }

        public object[] AllocateInputs()
        {
            return _invoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            if (inputs.Any())
            {
                _logger.Info(inputs.First().ToString());
            }
            return _invoker.Invoke(instance, inputs, out outputs);
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            if (inputs.Any())
            {
                _logger.Info(inputs.First().ToString());
            }
            return _invoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return _invoker.InvokeEnd(instance, out outputs, result);
        }

        public bool IsSynchronous => _invoker.IsSynchronous;
    }
}