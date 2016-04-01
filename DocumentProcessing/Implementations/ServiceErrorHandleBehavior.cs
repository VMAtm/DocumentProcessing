using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace DocumentProcessing.Implementations
{
    public class ServiceErrorHandleBehavior : IServiceBehavior
    {
        private readonly IErrorHandler _errorHandler;

        public ServiceErrorHandleBehavior(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
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
            foreach (var channelDispatcher in serviceHostBase.ChannelDispatchers
                .Select(channelDispatcherBase => channelDispatcherBase as ChannelDispatcher))
            {
                channelDispatcher.ErrorHandlers.Add(_errorHandler);
            }
        }
    }
}