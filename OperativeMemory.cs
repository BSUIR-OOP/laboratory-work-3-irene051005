using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class OperativeMemory: Hardware
    {
        
        public OperativeMemory()
        {
            MemoryKind = "";
            clockFrequency = 0;
        }
        protected string MemoryKind { get; set; }
        public int clockFrequency { get; set; }
    }
}
