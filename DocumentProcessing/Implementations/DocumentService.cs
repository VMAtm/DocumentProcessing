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

        public int GetLog()
        {
            return 0;
        }
    }
}
