using System.IO;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Implementations
{
    public sealed class DocumentService : IDocumentService
    {
        private readonly IDocumentBuilder _docBuilder;
        private readonly IServiceLogContext _db;

        public DocumentService(IDocumentBuilder docBuilder, IServiceLogContext context)
        {
            _docBuilder = docBuilder;
            _db = context;
        }

        public Stream GenerateDocument(string documentText)
        {
            return _docBuilder.GenerateDocument(documentText);
        }

        public int GetLog()
        {
            return _db.GetLog();
        }
    }
}