using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DocumentProcessingTests
{
    [TestFixture]
    public class DocumentServiceTest
    {
        private static ServiceHost _documentsService;

        [OneTimeSetUp]
        public void Init()
        {
            
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            
        }

        [Test]
        public void GetInitialLogTest()
        {
            throw new NotImplementedException();
        }


        [Test]
        public void GenerateDocumentWithRandomStringTest()
        {

        }

        [Test]
        public void GenerateDocumentWithEmptyStringTest()
        {

        }

        [Test]
        public void GenerateDocumentWithLongStringTest()
        {

        }

        [Test]
        public void GenerateDocumentWithNewLinesTest()
        {

        }

        [Test]
        public void GetLogAfterSomeOperationsTest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetLogTest()
        {

        }
    }
}