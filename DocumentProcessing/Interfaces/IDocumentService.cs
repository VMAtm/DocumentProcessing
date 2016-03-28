using System.IO;
using System.ServiceModel;

namespace DocumentProcessing.Interfaces
{
    [ServiceContract]
    public interface IDocumentService
    {
        [OperationContract]
        Stream GenerateDocument(string documentText);

        [OperationContract]
        int GetLog();
    }
}