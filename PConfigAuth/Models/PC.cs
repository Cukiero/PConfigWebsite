using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PConfigAuth.Models
{
    public class PC
    {
        public int Id { get; set; }
        [Required]
        public string ApplicationUserID { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int? CPUId { get; set; }
        public int? MOBOId { get; set; }
        public int? CaseId { get; set; }
        public int? PSUId { get; set; }
        public int? RAMId { get; set; }
        public int? GPUId { get; set; }
        public int? CoolerId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual CPU CPU { get; set; }
        public virtual MOBO MOBO { get; set; }
        public virtual Case Case { get; set; }
        public virtual PSU PSU { get; set; }
        public virtual RAM RAM { get; set; }
        public virtual GPU GPU { get; set; }
        public virtual ICollection<PC_Storage> PC_Storage { get; set; }
        public virtual Cooler Cooler { get; set; }
    }
}
