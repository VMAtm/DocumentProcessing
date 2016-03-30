using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentProcessing.Model
{
    public class FaultEntry : IdentifiedEntry
    {
        public string StackTrace { get; set; }
    }
}
