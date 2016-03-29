using System.IO;
using System.Text;
using DocumentProcessing.Implementations;
using DocumentProcessing.Interfaces;
using DocumentProcessingTests.DocService;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Extensions.Wcf.SelfHost;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using Ninject.Web.Common.SelfHost;
using NUnit.Framework;

namespace DocumentProcessingTests
{
    [TestFixture]
    public class DocumentServiceTest
    {
        private static NinjectSelfHostBootstrapper _selfHost;
        private static DocumentServiceClient _documentsServiceProxy;

        [OneTimeSetUp]
        // ReSharper disable UnusedMember.Global
        public static void Init()
        // ReSharper restore UnusedMember.Global
        {
            var docServiceToHost = NinjectWcfConfiguration.Create<DocumentService, NinjectServiceSelfHostFactory>();
            _selfHost = new NinjectSelfHostBootstrapper(CreateKernel, docServiceToHost);
            _selfHost.Start();
            _documentsServiceProxy = new DocumentServiceClient();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new MoqMockingKernel();
            kernel.Bind<IDocumentBuilder>().ToMock();
            return kernel;
        }

        [OneTimeTearDown]
        // ReSharper disable UnusedMember.Global
        public static void Dispose()
        // ReSharper restore UnusedMember.Global
        {
            _selfHost.Dispose();
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
            }
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
            }
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