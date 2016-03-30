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
            byte[] pdfBytes;

            using (var buffer = new MemoryStream())
            {
                using (var doc = new Document())
                using (PdfWriter.GetInstance(doc, buffer))
                {
                    doc.Open();
                    doc.Add(new Paragraph(content));
                    doc.CloseDocument();
                }
                pdfBytes = buffer.ToArray();
            }
            return new MemoryStream(pdfBytes);
        }
    }
}