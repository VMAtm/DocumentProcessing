using System.IO;
using System.Threading.Tasks;

namespace DocumentProcessing.Interfaces
{
    public interface IDocumentBuilder
    {
        Stream GenerateDocument(string content);
    }
}