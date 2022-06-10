using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Processor : Hardware
    {
        public Processor()
        {
            BitDepth = 0;
            CoresCount = 0;
            CashLevel = "";
        }
        public int BitDepth{ get; set; }
        public int CoresCount { get; set; }
        protected string CashLevel { get; set; }
    }
}
