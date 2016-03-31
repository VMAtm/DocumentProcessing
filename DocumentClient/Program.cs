using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using DocumentClient.DocService;

namespace DocumentClient
{
    static class Program
    {
        private const char Yes = 'Y';
        private const string TestFilePath = "TestFilePath";

        static void Main(string[] args)
        {
            Console.WriteLine(Properties.Resources.Program_Main_Intro);
            Console.WriteLine(Properties.Resources.Program_Main_String_To_Test);
            var line = Console.ReadLine();
            var testFilePath = ConfigurationManager.AppSettings[TestFilePath];

            using (var documentsServiceProxy = new DocumentServiceClient())
            {
                Console.WriteLine(documentsServiceProxy.GetLog());
                using (var stream = documentsServiceProxy.GenerateDocument(line))
                using (var file = new FileStream(testFilePath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(file);
                }
            }

            Console.WriteLine(Properties.Resources.Program_Main_Document_Creation_Completed);
            var choice = Console.Read();
            if (choice == Yes)
            {
                Process.Start(testFilePath);
            }
        }
    }
}