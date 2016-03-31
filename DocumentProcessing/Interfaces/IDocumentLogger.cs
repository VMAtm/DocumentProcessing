using System;

namespace DocumentProcessing.Interfaces
{
    public interface IDocumentLogger
    {
        void Info(string info);

        void Fatal(Exception exception);
    }
}