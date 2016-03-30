using System;
using System.Reflection;
using DocumentProcessing.Implementations;
using DocumentProcessing.Interfaces;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Extensions.Wcf.SelfHost;
using Ninject.Web.Common.SelfHost;

namespace DocumentProcessing
{
    static class DocumentServiceHost
    {
        /// <summary>
        /// http://stackoverflow.com/q/25102582/213550
        /// https://pieterderycke.wordpress.com/2011/05/09/using-an-ioc-container-to-create-wcf-service-instances/
        /// http://codereview.stackexchange.com/q/33379/4889
        /// </summary>
        /// <param name="args"></param>
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
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IDocumentService>().To<DocumentService>();
            kernel.Bind<IDocumentBuilder>().To<DocumentBuilder>();
            return kernel;
        }
    }
}