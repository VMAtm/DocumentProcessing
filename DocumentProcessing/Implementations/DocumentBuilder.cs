using System;
using System.IO;
using DocumentProcessing.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DocumentProcessing.Implementations
{
    class DocumentBuilder : IDocumentBuilder
    {
        public Stream GenerateDocument(string content)
        {
            var result = new MemoryStream();
            using (var buffer = new MemoryStream())
            using (var doc = new Document())
            using (PdfWriter.GetInstance(doc, buffer))
            {
                doc.Open();
                doc.Add(new Paragraph(content));
                buffer.Position = 0;
                buffer.CopyTo(result);
            }
            
            return result;
        }
    }
}