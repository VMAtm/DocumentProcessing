using System;

namespace DocumentProcessing.Model
{
    public class LogEntry : IdentifiedEntry
    {
        public DateTime EventDate { get; set; }

        public string IPHost { get; set; }

        public int Port { get; set; }

        public string InputString { get; set; }
    }
}