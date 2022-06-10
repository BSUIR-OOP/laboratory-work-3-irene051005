using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class Hardware
    {
        public Hardware()
        {
            Price = 0;
            ProducerName = "";
        }
        protected float Price { get; set; }
        public string ProducerName  { get; set; }
    }
}
