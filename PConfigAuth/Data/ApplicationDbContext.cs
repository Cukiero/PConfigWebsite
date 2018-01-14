using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PConfigAuth.Models;

namespace PConfigAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PC> PCs { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<MOBO> MOBOes { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<PSU> PSUs { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<PC_Storage> PC_Storage { get; set; }
        public DbSet<Cooler> Coolers { get; set; }
    }
}
