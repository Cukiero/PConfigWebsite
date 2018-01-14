using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models
{
    public class GPU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Chipset { get; set; }
        public string TDP { get; set; }
        public string Price { get; set; }

        public virtual ICollection<PC> PCs { get; set; }
    }
}
