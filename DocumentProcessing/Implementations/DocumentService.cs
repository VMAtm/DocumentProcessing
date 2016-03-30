using System.IO;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Implementations
{
    public sealed class DocumentService : IDocumentService
    {
        private readonly IDocumentBuilder _docBuilder;

        public DocumentService(IDocumentBuilder docBuilder)
        {
            _docBuilder = docBuilder;
        }

        public Stream GenerateDocument(string documentText)
        {
            return _docBuilder.GenerateDocument(documentText);
        }

        /// <summary>
        /// Logging
        /// http://stackoverflow.com/q/2046704/213550
        /// https://msdn.microsoft.com/en-us/library/system.servicemodel.web.incomingwebrequestcontext(v=vs.110).aspx
        /// http://stackoverflow.com/questions/93162/obtaining-client-ip-address-in-wcf-3-0
        /// https://msdn.microsoft.com/en-us/library/ms733747(v=vs.110).aspx
        /// https://blogs.msdn.microsoft.com/carlosfigueira/2011/04/11/wcf-extensibility-ioperationbehavior/
        /// https://msdn.microsoft.com/en-us/library/system.servicemodel.description.ioperationbehavior(v=vs.110).aspx
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetLog()
        {
            
            return 0;
        }
    }
}
