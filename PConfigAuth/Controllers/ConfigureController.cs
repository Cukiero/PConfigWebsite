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
using System.Collections.ObjectModel;

namespace PConfigAuth.Controllers
{
    public class ConfigureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        const string SessionKeyCPU = "CPU";
        const string SessionKeyGPU = "GPU";
        const string SessionKeyMOBO = "MOBO";
        const string SessionKeyRAM = "RAM";
        const string SessionKeyPSU = "PSU";
        const string SessionKeyCase = "Case";
        const string SessionKeyCooler = "Cooler";
        const string SessionKeyStorageBase = "Storage";
        const int max_storage_amount = 5;

        public ConfigureController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }


        public IActionResult Index()
        {
            ViewData["HwType"] = "Index";
            return View("Index");
        }

        //Adding user's configuration

        public async Task<IActionResult> AddConfig(string hwtype)
        {
            string user = _userManager.GetUserId(User);
            if (!String.IsNullOrEmpty(user))
            {
                PC pcdata = new PC();
                string hwid;

                pcdata.DateOfCreation = DateTime.Now;
                pcdata.ApplicationUserID = user;

                hwid = HttpContext.Session.GetString(SessionKeyCPU);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.CPUId = Int32.Parse(hwid);
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyGPU);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.GPUId = Int32.Parse(hwid);
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyMOBO);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.MOBOId = Int32.Parse(hwid);
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyRAM);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.RAMId = Int32.Parse(hwid);
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyPSU);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.PSUId = Int32.Parse(hwid);
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyCase);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.CaseId = Int32.Parse(hwid);
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyCooler);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.CoolerId = Int32.Parse(hwid);
                    hwid = null;
                }



                string SessionKeyStorage;
                pcdata.PC_Storage = new Collection<PC_Storage>();
                for (int i = 1; i <= max_storage_amount; i++)
                {
                    SessionKeyStorage = SessionKeyStorageBase + i;
                    hwid = HttpContext.Session.GetString(SessionKeyStorage);

                    if (!String.IsNullOrEmpty(hwid))
                    {
                        Storage stg = await _context.Storages.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
                        PC_Storage pc_stg = new PC_Storage
                        {
                            PC = pcdata,
                            Storage = stg
                        };
                        if (stg.PC_Storage == null)
                        {
                            stg.PC_Storage = new Collection<PC_Storage>();
                        }

                        stg.PC_Storage.Add(pc_stg);
                        pcdata.PC_Storage.Add(pc_stg);
                    }
                    hwid = null;
                }

                _context.PCs.Add(pcdata);
                await _context.SaveChangesAsync();
            }
            
            return await LoadDataFromHwType(hwtype);
        }


        //Data loaders:

        public async Task<IActionResult> LoadCPUs()
        {
            ViewData["HwType"] = "CPU";
            var data = _context.CPUs.AsNoTracking();
            return View("CPUs", await data.ToListAsync());
        }

        public async Task<IActionResult> LoadGPUs()
        {
            ViewData["HwType"] = "GPU";
            var data = _context.GPUs.AsNoTracking();
            return View("GPUs", await data.ToListAsync());
        }

        public async Task<IActionResult> LoadMOBOes()
        {
            ViewData["HwType"] = "MOBO";
            var data = _context.MOBOes.AsNoTracking();
            return View("MOBOes", await data.ToListAsync());
        }

        public async Task<IActionResult> LoadRAMs()
        {
            ViewData["HwType"] = "RAM";
            var data = _context.RAMs.AsNoTracking();
            return View("RAMs", await data.ToListAsync());
        }

        public async Task<IActionResult> LoadPSUs()
        {
            ViewData["HwType"] = "PSU";
            var data = _context.PSUs.AsNoTracking();
            return View("PSUs", await data.ToListAsync());
        }

        public async Task<IActionResult> LoadCases()
        {
            ViewData["HwType"] = "Case";
            var data = _context.Cases.AsNoTracking();
            return View("Cases", await data.ToListAsync());
        }
        public async Task<IActionResult> LoadCoolers()
        {
            ViewData["HwType"] = "Cooler";
            var data = _context.Coolers.AsNoTracking();
            return View("Coolers", await data.ToListAsync());
        }
        public async Task<IActionResult> LoadStorages()
        {
            ViewData["HwType"] = "Storage";
            var data = _context.Storages.AsNoTracking();
            return View("Storages", await data.ToListAsync());
        }

        //Adding hardware id to session

        public async Task<IActionResult> AddCPU(int id)
        {
            HttpContext.Session.SetString(SessionKeyCPU, id.ToString());
            return await LoadCPUs();
        }

        public async Task<IActionResult> AddGPU(int id)
        {
            HttpContext.Session.SetString(SessionKeyGPU, id.ToString());
            return await LoadGPUs();
        }

        public async Task<IActionResult> AddMOBO(int id)
        {
            HttpContext.Session.SetString(SessionKeyMOBO, id.ToString());
            return await LoadMOBOes();
        }

        public async Task<IActionResult> AddRAM(int id)
        {
            HttpContext.Session.SetString(SessionKeyRAM, id.ToString());
            return await LoadRAMs();
        }
        public async Task<IActionResult> AddPSU(int id)
        {
            HttpContext.Session.SetString(SessionKeyPSU, id.ToString());
            return await LoadPSUs();
        }
        public async Task<IActionResult> AddCase(int id)
        {
            HttpContext.Session.SetString(SessionKeyCase, id.ToString());
            return await LoadCases();
        }
        public async Task<IActionResult> AddCooler(int id)
        {
            HttpContext.Session.SetString(SessionKeyCooler, id.ToString());
            return await LoadCoolers();
        }

        public async Task<IActionResult> AddStorage(int id)
        {
            string SessionKeyStorage;
            string testStr;
            for(int i=1; i <= max_storage_amount; i++)
            {
                SessionKeyStorage = SessionKeyStorageBase + i;
                testStr=HttpContext.Session.GetString(SessionKeyStorage);
                if (string.IsNullOrEmpty(testStr))
                {
                    HttpContext.Session.SetString(SessionKeyStorage, id.ToString());
                    return await LoadStorages();
                }
            }
            return await LoadStorages();

        }
        //Loadpicker to refresh after removal
        public async Task<IActionResult> LoadDataFromHwType(string hwtype)
        {
            switch (hwtype)
            {
                case "CPU":
                    return await LoadCPUs();
                case "GPU":
                    return await LoadGPUs();
                case "MOBO":
                    return await LoadMOBOes();
                case "RAM":
                    return await LoadRAMs();
                case "PSU":
                    return await LoadPSUs();
                case "Case":
                    return await LoadCases();
                case "Cooler":
                    return await LoadCoolers();
                case "Storage":
                    return await LoadStorages();
            }
            return Index();
        }

        //Removing hardware id from session

        public async Task<IActionResult> RemoveCPU(string hwtype)
        {
            HttpContext.Session.Remove(SessionKeyCPU);

            return await LoadDataFromHwType(hwtype);
        }
        public async Task<IActionResult> RemoveGPU(string hwtype)
        {
            HttpContext.Session.Remove(SessionKeyGPU);

            return await LoadDataFromHwType(hwtype);
        }
        public async Task<IActionResult> RemoveMOBO(string hwtype)
        {
            HttpContext.Session.Remove(SessionKeyMOBO);

            return await LoadDataFromHwType(hwtype);
        }
        public async Task<IActionResult> RemoveRAM(string hwtype)
        {
            HttpContext.Session.Remove(SessionKeyRAM);

            return await LoadDataFromHwType(hwtype);
        }
        public async Task<IActionResult> RemovePSU(string hwtype)
        {
            HttpContext.Session.Remove(SessionKeyPSU);

            return await LoadDataFromHwType(hwtype);
        }
        public async Task<IActionResult> RemoveCase(string hwtype)
        {
            HttpContext.Session.Remove(SessionKeyCase);

            return await LoadDataFromHwType(hwtype);
        }
        public async Task<IActionResult> RemoveCooler(string hwtype)
        {
            HttpContext.Session.Remove(SessionKeyCooler);

            return await LoadDataFromHwType(hwtype);
        }

        public async Task<IActionResult> RemoveStorage(string hwtype, int id)
        {
            id = id + 1;
            string SessionKeyStorage = SessionKeyStorageBase + id;

            HttpContext.Session.Remove(SessionKeyStorage);

            return await LoadDataFromHwType(hwtype);
        }
    }
}