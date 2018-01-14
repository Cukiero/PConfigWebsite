using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models
{
    public class TempConfigViewModel
    {
        public CPU cpu { get; set; }
        public GPU gpu { get; set; }

        public MOBO mobo { get; set; }
        public RAM ram { get; set; }
        public PSU psu { get; set; }
        public Case casepc { get; set; }
        public Cooler cooler { get; set; }

        public IList<Storage> storages { get; set; }

    }
}
