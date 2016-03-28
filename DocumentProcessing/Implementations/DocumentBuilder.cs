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
            var docId = Guid.NewGuid();
            var path = string.Format(@"\Document{0}.pdf", docId);
            using (var doc = new Document())
            using (var fs = new FileStream(path, FileMode.Create))
            using (PdfWriter.GetInstance(doc, fs))
            {
                doc.Open();
                doc.Add(new Paragraph(content));
            }
            return File.OpenRead(path);
        }
    }
}