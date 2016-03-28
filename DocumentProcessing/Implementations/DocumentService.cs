using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentProcessing.Interfaces;

namespace DocumentProcessing.Implementations
{
    public sealed class DocumentService : IDocumentService
    {
        public Stream GenerateDocument(string documentText)
        {
            return null;
        }

        public int GetLog()
        {
            return 0;
        }
    }
}
