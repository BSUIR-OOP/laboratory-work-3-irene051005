using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Monitor:Hardware
    {
        public Monitor()
        {
            Diagonal = 0;
            RefreshRate = 0;
            MatrixType = "";
            InterfaceType = "";
        }
        protected float Diagonal { get; set; }
        protected int RefreshRate { get; set; }
        public string MatrixType{ get; set; }
        protected string InterfaceType { get; set; }
    }
}
