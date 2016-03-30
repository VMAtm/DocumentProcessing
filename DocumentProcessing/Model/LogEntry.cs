using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentProcessing.Model
{
    /// <summary>
    /// Entity framework
    /// https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
    /// 
    /// </summary>
    public class LogEntry : IdentifiedEntry
    {
        public DateTime EventDate { get; set; }

        public string IPHost { get; set; }

        public int Port { get; set; }

        public string InputString { get; set; }
    }
}
