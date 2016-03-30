using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentClient.DocService;

namespace DocumentClient
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a test application for the document processing module.");
            Console.WriteLine("Please, provide a string to be written into a pdf document.");
            var line = Console.ReadLine();
            using (var documentsServiceProxy = new DocumentServiceClient())
            {
                using (var stream = documentsServiceProxy.GenerateDocument(line))
                using (var file = new FileStream("test.pdf", FileMode.Create, FileAccess.Write))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(file);
                }
            }
            Console.WriteLine("Document creation completed. Open the result (this will start a new process so you do need a pdf reader application installed)? (Y/N)");
            var choice = Console.Read();
            if (choice == 'Y')
            {
                Process.Start("test.pdf");
            }
        }
    }
}