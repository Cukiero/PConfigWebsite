using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models.ConfigureViewModels
{
    public class MOBOViewModel
    {
        public MOBO MOBO { get; set; }
        public bool Ram_type_ok { get; set; }
        public bool Socket_ok { get; set; }
    }
}
