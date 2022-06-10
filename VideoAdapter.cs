using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class VideoAdapter: Hardware
    {
        public VideoAdapter()
        {
            MemoryVolume = 0;
            MemoryType = "";
        }

        protected int MemoryVolume{ get; set; }
        public string MemoryType { get; set; }
    }
}
