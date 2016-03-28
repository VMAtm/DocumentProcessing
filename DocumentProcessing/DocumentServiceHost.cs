using System;
using System.Linq;
using System.ServiceModel;
using DocumentProcessing.Implementations;

namespace DocumentProcessing
{
    static class DocumentServiceHost
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(DocumentService)))
            {
                host.Open();

                Console.WriteLine("The service is ready at {0}", host.BaseAddresses.First().AbsoluteUri);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}