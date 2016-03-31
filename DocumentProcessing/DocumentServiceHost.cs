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
            var kernel = new StandardKernel();
            var connectionString = ConfigurationManager.ConnectionStrings["ServiceLogContext"].ConnectionString;

            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IDocumentService>().To<DocumentService>();
            kernel.Bind<IDocumentBuilder>().To<DocumentBuilder>();
            kernel.Bind<IDocumentLogger>().To<DocumentLogger>();

            kernel.Bind<IOperationInvoker>().To<LoggingInvoker>();
            kernel.Bind<IOperationBehavior>().To<LogOperationBehavior>();
            kernel.Bind<IServiceBehavior>().To<ServiceLoggingBehavior>();

            kernel.Bind<IServiceLogContext>().To<ServiceLogContext>()
                .WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}