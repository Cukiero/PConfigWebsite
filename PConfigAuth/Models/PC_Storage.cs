
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Models
{
    public class PC_Storage
    {
        public int Id { get; set; }
        public int PCId { get; set; }

        public int StorageId { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual PC PC { get; set; }
    }
}
