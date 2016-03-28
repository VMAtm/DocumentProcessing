using System;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;
using DocumentProcessing.Implementations;
using NUnit.Framework;
using UnitTests.DocService;

namespace DocumentProcessingTests
{
    [TestFixture]
    public class DocumentServiceTest
    {
        private static ServiceHost _documentsService;
        private static DocumentServiceClient _documentsServiceProxy;

        [OneTimeSetUp]
        public static void Init()
        {
            _documentsService = new ServiceHost(typeof(DocumentService));
            _documentsService.Open();
            _documentsServiceProxy = new DocumentServiceClient();
        }

        [OneTimeTearDown]
        public static void Dispose()
        {
            _documentsService.Close();
        }

        [TestCase(0)]
        public void GetInitialLogTest(int expected)
        {
            Assert.AreEqual(_documentsServiceProxy.GetLog(), expected);
        }

        [TestCase("")]
        [TestCase("asdfasdfasdfas  asdfsd sd fdferklgj\r\ndfkmg njk h18 12k -12  =-a {} {{{}adsd 1 \\")]
        [TestCase("asdfasdfasdfas  asdfsd sd fdferklgj dfkmg njk h18 12k -12  =-a {} {{{}adsd 1 \\")]
        public void GenerateDocumentWithRandomStringTest(string expectedContent)
        {
            using (var result = new StreamReader(_documentsServiceProxy.GenerateDocument(expectedContent)))
            {
                var resultContent = result.ReadToEnd();
                Assert.IsTrue(resultContent.Contains(expectedContent));
            };
        }

        [Test]
        public void GenerateDocumentWithLongStringTest()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 1000; ++i)
            {
                sb.AppendLine(i.ToString());
            }
            var expectedContent = sb.ToString();
            using (var result = new StreamReader(_documentsServiceProxy.GenerateDocument(expectedContent)))
            {
                var resultContent = result.ReadToEnd();
                Assert.IsTrue(resultContent.Contains(expectedContent));
            };
        }

        [TestCase(1)]
        public void GetLogAfterSomeOperationsTest(int expected)
        {
            var currentLogs = _documentsServiceProxy.GetLog();
            _documentsServiceProxy.GenerateDocument(string.Empty);
            var afterLogs = _documentsServiceProxy.GetLog();
            Assert.AreEqual(afterLogs - currentLogs, expected);
        }
    }
}