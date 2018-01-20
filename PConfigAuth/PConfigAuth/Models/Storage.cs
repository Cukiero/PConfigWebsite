using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }

        public virtual ICollection<PC_Storage> PC_Storage { get; set; }
    }
}
