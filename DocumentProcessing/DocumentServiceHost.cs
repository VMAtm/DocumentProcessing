using System;
using System.Configuration;
using System.Reflection;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using DocumentProcessing.Implementations;
using DocumentProcessing.Interfaces;
using DocumentProcessing.Model;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Extensions.Wcf.SelfHost;
using Ninject.Web.Common.SelfHost;

namespace DocumentProcessing
{
    static class DocumentServiceHost
    {
        private static IKernel _kernel;

        static void Main(string[] args)
        {
            var docServiceToHost = NinjectWcfConfiguration.Create<DocumentService, NinjectServiceSelfHostFactory>();
            
            using (var selfHost = new NinjectSelfHostBootstrapper(CreateKernel, docServiceToHost))
            {
                selfHost.Start();
                Console.WriteLine("The service is ready at {0}", "");// docServiceToHost.BaseAddresses.First().AbsoluteUri);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
            }
        }

        private static IKernel CreateKernel()
        {
            _kernel = new StandardKernel();
            var connectionString = ConfigurationManager.ConnectionStrings["ServiceLogContext"].ConnectionString;

            _kernel.Load(Assembly.GetExecutingAssembly());
            _kernel.Bind<IDocumentService>().To<DocumentService>();
            _kernel.Bind<IDocumentBuilder>().To<DocumentBuilder>();
            _kernel.Bind<IDocumentLogger>().To<DocumentLogger>();

            _kernel.Bind<IErrorHandler>().To<ErrorHandler>();
            _kernel.Bind<IOperationInvoker>().To<LoggingInvoker>();
            _kernel.Bind<IOperationBehavior>().To<LogOperationBehavior>();

            _kernel.Bind<IServiceLogContext>().To<ServiceLogContext>()
                .WithConstructorArgument("connectionString", connectionString);

            return _kernel;
        }
    }
}