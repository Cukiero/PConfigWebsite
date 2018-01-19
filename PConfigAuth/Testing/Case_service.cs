using Microsoft.AspNetCore.Mvc;
using PConfigAuth.Data;
using PConfigAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PConfigAuth
{
    public class Case_service
    {
        private ApplicationDbContext _context;

        public Case_service(ApplicationDbContext context)
        {
            _context = context;
        }

        public Case AddCase(string name, string Manufacturer, string price)
        {
            var casetemp = new Case { Name = name, Manufacturer = Manufacturer, Price = price };
            _context.Cases.Add(casetemp);
            _context.SaveChanges();

            return casetemp;

        }


        public List<Case> GetCases()
        {
            var query = from b in _context.Cases
                        orderby b.Name
                        select b;

            return query.ToList();
        }
    }
}
