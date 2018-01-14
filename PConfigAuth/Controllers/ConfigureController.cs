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
using PConfigAuth.Models.ConfigureViewModels;

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
        const int max_storage_amount = 8;

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
                    pcdata.CPU = await _context.CPUs.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyGPU);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.GPU = await _context.GPUs.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyMOBO);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.MOBO = await _context.MOBOes.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyRAM);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.RAM = await _context.RAMs.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyPSU);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.PSU = await _context.PSUs.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyCase);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.Case = await _context.Cases.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
                    hwid = null;
                }
                hwid = HttpContext.Session.GetString(SessionKeyCooler);
                if (!String.IsNullOrEmpty(hwid))
                {
                    pcdata.Cooler = await _context.Coolers.SingleOrDefaultAsync(s => s.Id == Int32.Parse(hwid));
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
                if(pcdata.CPU != null ||
                    pcdata.GPU != null ||
                    pcdata.MOBO != null ||
                    pcdata.RAM != null ||
                    pcdata.PSU != null ||
                    pcdata.Case != null ||
                    pcdata.Cooler != null ||
                    pcdata.PC_Storage.Any()
                    )
                {
                    _context.PCs.Add(pcdata);
                    await _context.SaveChangesAsync();
                    ViewData["ServerMessage"] = "<span id=\"temp-config-success-msg\">[Configuration has been added successfully.]</span>";
                }
                else
                {
                    ViewData["ServerMessage"] = "<span id=\"temp-config-error-msg\">[You cant' add an empty configuration.]</span>";
                }

            }
            else
            {
                ViewData["ServerMessage"] = "<span id=\"temp-config-error-msg\">[You need to be logged in to save your configuration.]</span>";
            }
            
            return await LoadDataFromHwType(hwtype);
        }


        //Data loaders:
        public async Task<IActionResult> LoadCPUs()
        {
            ViewData["HwType"] = "CPU";

            string moboID = HttpContext.Session.GetString(SessionKeyMOBO);
            MOBO mobo = null;
            if (!String.IsNullOrEmpty(moboID))
            {
                mobo = await _context.MOBOes.SingleOrDefaultAsync(m => m.Id == Int32.Parse(moboID));
            }

            string coolerID = HttpContext.Session.GetString(SessionKeyCooler);
            Cooler cooler = null;
            if (!String.IsNullOrEmpty(coolerID))
            {
                cooler = await _context.Coolers.SingleOrDefaultAsync(m => m.Id == Int32.Parse(coolerID));
            }

            List<CPU> cpuList = await _context.CPUs.AsNoTracking().ToListAsync();
            List<CPUViewModel> cpuListValidated = new List<CPUViewModel>();
            foreach(var item in cpuList)
            {
                CPUViewModel cpuValidated = new CPUViewModel
                {
                    CPU = item,
                    Socket_ok = true
                };

                if(mobo != null) { if(!item.Socket.Equals(mobo.Socket)) cpuValidated.Socket_ok = false; }
                if (cooler != null) { if (!item.Socket.Equals(cooler.Socket)) cpuValidated.Socket_ok = false; }

                cpuListValidated.Add(cpuValidated);
            }
            return View("CPUs", cpuListValidated);
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

            string coolerID = HttpContext.Session.GetString(SessionKeyCooler);
            Cooler cooler = null;
            if (!String.IsNullOrEmpty(coolerID))
            {
                cooler = await _context.Coolers.SingleOrDefaultAsync(m => m.Id == Int32.Parse(coolerID));
            }

            string cpuID = HttpContext.Session.GetString(SessionKeyCPU);
            CPU cpu = null;
            if (!String.IsNullOrEmpty(cpuID))
            {
                cpu = await _context.CPUs.SingleOrDefaultAsync(m => m.Id == Int32.Parse(cpuID));
            }

            string ramID = HttpContext.Session.GetString(SessionKeyRAM);
            RAM ram = null;
            if (!String.IsNullOrEmpty(ramID))
            {
                ram = await _context.RAMs.SingleOrDefaultAsync(m => m.Id == Int32.Parse(ramID));
            }

            List<MOBO> moboList = await _context.MOBOes.AsNoTracking().ToListAsync();
            List<MOBOViewModel> moboListValidated = new List<MOBOViewModel>();
            foreach (var item in moboList)
            {
                MOBOViewModel moboValidated = new MOBOViewModel
                {
                    MOBO = item,
                    Ram_type_ok = true,
                    Socket_ok = true
                };

                if (ram != null) { if (!item.Ram_type.Equals(ram.Ram_type)) moboValidated.Ram_type_ok = false; }
                if (cooler != null) { if (!item.Socket.Equals(cooler.Socket)) moboValidated.Socket_ok = false; }
                if (cpu != null) { if (!item.Socket.Equals(cpu.Socket)) moboValidated.Socket_ok = false; }

                moboListValidated.Add(moboValidated);
            }

            return View("MOBOes", moboListValidated);
        }

        public async Task<IActionResult> LoadRAMs()
        {
            ViewData["HwType"] = "RAM";

            string moboID = HttpContext.Session.GetString(SessionKeyMOBO);
            MOBO mobo = null;
            if (!String.IsNullOrEmpty(moboID))
            {
                mobo = await _context.MOBOes.SingleOrDefaultAsync(m => m.Id == Int32.Parse(moboID));
            }

            List<RAM> ramList = await _context.RAMs.AsNoTracking().ToListAsync();
            List<RAMViewModel> ramListValidated = new List<RAMViewModel>();
            foreach (var item in ramList)
            {
                RAMViewModel ramValidated = new RAMViewModel
                {
                    RAM = item,
                    Ram_type_ok = true
                };

                if (mobo != null) { if (!item.Ram_type.Equals(mobo.Ram_type)) ramValidated.Ram_type_ok = false; }

                ramListValidated.Add(ramValidated);
            }

            return View("RAMs", ramListValidated);
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

            string moboID = HttpContext.Session.GetString(SessionKeyMOBO);
            MOBO mobo = null;
            if (!String.IsNullOrEmpty(moboID))
            {
                mobo = await _context.MOBOes.SingleOrDefaultAsync(m => m.Id == Int32.Parse(moboID));
            }

            string cpuID = HttpContext.Session.GetString(SessionKeyCPU);
            CPU cpu = null;
            if (!String.IsNullOrEmpty(cpuID))
            {
                cpu = await _context.CPUs.SingleOrDefaultAsync(m => m.Id == Int32.Parse(cpuID));
            }

            List<Cooler> coolerList = await _context.Coolers.AsNoTracking().ToListAsync();
            List<CoolerViewModel> coolerListValidated = new List<CoolerViewModel>();
            foreach (var item in coolerList)
            {
                CoolerViewModel coolerValidated = new CoolerViewModel
                {
                    Cooler = item,
                    Socket_ok = true
                };

                if (mobo != null) { if (!item.Socket.Equals(mobo.Socket)) coolerValidated.Socket_ok = false; }
                if (cpu != null) { if (!item.Socket.Equals(cpu.Socket)) coolerValidated.Socket_ok = false; }

                coolerListValidated.Add(coolerValidated);
            }

            return View("Coolers", coolerListValidated);
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