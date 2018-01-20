using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PConfigAuth.Data;
using PConfigAuth.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace PConfigAuth.Controllers
{
    public class MyConfigurationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public MyConfigurationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<MyConfigurationsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string user = _userManager.GetUserId(User);
            var data = _context.PCs
                .Where(p => p.ApplicationUserID == user)
                .Include(p => p.CPU)
                .Include(p => p.GPU)
                .Include(p => p.MOBO)
                .Include(p => p.RAM)
                .Include(p => p.PSU)
                .Include(p => p.Case)
                .Include(p => p.Cooler)
                .Include(p => p.PC_Storage)
                .ThenInclude(l => l.Storage)
                .OrderByDescending(d => d.DateOfCreation)
                .AsNoTracking();

            return View("Index",await data.ToListAsync());

        }

        public async Task<IActionResult> RemoveConfig(int id)
        {
            string user = _userManager.GetUserId(User);
            var pc_config = new PC
            {
                Id = id,
                ApplicationUserID = user
            };

            _context.PCs.Attach(pc_config);
            _context.PCs.Remove(pc_config);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("Unable to remove configuration." + ex);
            }

            return await Index();

        }

    }
}