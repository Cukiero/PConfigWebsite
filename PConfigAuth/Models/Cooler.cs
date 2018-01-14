using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models
{
    public class Cooler
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Socket { get; set; }
        public string Fans { get; set; }
        public string Price { get; set; }

        public virtual ICollection<PC> PCs { get; set; }
    }
}
