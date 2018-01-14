using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models
{
    public class MOBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Standard { get; set; }
        public string Chipset { get; set; }
        public string Socket { get; set; }
        public string Ram_type { get; set; }
        public string Price { get; set; }

        public virtual ICollection<PC> PCs { get; set; }
    }
}
