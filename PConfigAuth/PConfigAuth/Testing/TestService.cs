using PConfigAuth.Data;
using PConfigAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PConfigAuth.Testing
{
    public class TestService
    {
        private ApplicationDbContext _context;
 
        public TestService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void AddConfiguration(CPU cpu, GPU gpu, MOBO mobo, RAM ram, PSU psu, Case casePC, Cooler cooler, ApplicationUser user)
        {
        PC pcdata = new PC();
        pcdata.CPU = cpu;
        pcdata.GPU = gpu;
        pcdata.MOBO = mobo;
        pcdata.RAM = ram;
        pcdata.PSU = psu;
        pcdata.Case = casePC;
        pcdata.Cooler = cooler;
        pcdata.ApplicationUser = user;
        _context.PCs.Add(pcdata);
        _context.SaveChanges();
        }

        public List<PC> GetPCs()
        {
        var query = from b in _context.PCs
                    orderby b.Id
                    select b;

        return query.ToList();
         }
    }
}
