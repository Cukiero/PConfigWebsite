using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models
{
    public class CPU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Series { get; set; }
        public string Socket { get; set; }
        public string Cores { get; set; }
        public string TDP { get; set; }
        public byte iGPU { get; set; }
        public string Price { get; set; }

        public virtual ICollection<PC> PCs { get; set; }
    }
}
