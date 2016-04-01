using System.IO;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Implementations
{
    public sealed class DocumentService : IDocumentService
    {
        private readonly IDocumentBuilder _docBuilder;
        private readonly IServiceLogContext _logContext;

        public DocumentService(IDocumentBuilder docBuilder, IServiceLogContext context)
        {
            _docBuilder = docBuilder;
            _logContext = context;
        }

        public Stream GenerateDocument(string documentText)
        {
            return _docBuilder.GenerateDocument(documentText);
        }

        public int GetLog()
        {
            return _logContext.GetLog();
        }
    }
}