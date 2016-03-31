using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace DocumentProcessing.Implementations
{
    public class ServiceLoggingBehavior : IServiceBehavior
    {
        private readonly IOperationBehavior _loggingBehavior;

        public ServiceLoggingBehavior(IOperationBehavior loggingBehavior)
        {
            _loggingBehavior = loggingBehavior;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var operation in serviceDescription.Endpoints
                .SelectMany(endpoint => endpoint.Contract.Operations)
                .Where(operation => operation.Name.Equals("GenerateDocument", StringComparison.InvariantCultureIgnoreCase)))
            {
                operation.Behaviors.Add(_loggingBehavior);
            }
        }
    }
}