using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class HardDisk:Hardware
    {
        public HardDisk()
        {
            Capacity = 0;
            Size = 0;
            InterfaceName = "";
        }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public string InterfaceName { get; set; }
    }
}
