using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PConfigAuth.Models;
using PConfigAuth.Data;
using Microsoft.AspNetCore.Http;
using PConfigAuth.Models.TempConfigViewModels;

namespace PConfigAuth.ViewComponents
{
    public class TempConfigViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        const string SessionKeyCPU = "CPU";
        const string SessionKeyGPU = "GPU";
        const string SessionKeyMOBO = "MOBO";
        const string SessionKeyRAM = "RAM";
        const string SessionKeyPSU = "PSU";
        const string SessionKeyCase = "Case";
        const string SessionKeyCooler = "Cooler";
        const string SessionKeyStorageBase = "Storage";
        const int max_storage_amount = 8;


        public TempConfigViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            TempConfigViewModel configModel = new TempConfigViewModel();
            string id;
            id = HttpContext.Session.GetString(SessionKeyCPU);
            if (!String.IsNullOrEmpty(id))
            {
                configModel.cpu = await _context.CPUs.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id));
                id = null;
            }

            id = HttpContext.Session.GetString(SessionKeyGPU);
            if (!String.IsNullOrEmpty(id))
            {
                configModel.gpu = await _context.GPUs.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id));
                id = null;
            }

            id = HttpContext.Session.GetString(SessionKeyMOBO);
            if (!String.IsNullOrEmpty(id))
            {
                configModel.mobo = await _context.MOBOes.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id));
                id = null;
            }

            id = HttpContext.Session.GetString(SessionKeyRAM);
            if (!String.IsNullOrEmpty(id))
            {
                configModel.ram = await _context.RAMs.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id));
                id = null;
            }

            id = HttpContext.Session.GetString(SessionKeyPSU);
            if (!String.IsNullOrEmpty(id))
            {
                configModel.psu = await _context.PSUs.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id));
                id = null;
            }

            id = HttpContext.Session.GetString(SessionKeyCase);
            if (!String.IsNullOrEmpty(id))
            {
                configModel.casepc = await _context.Cases.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id));
                id = null;
            }

            id = HttpContext.Session.GetString(SessionKeyCooler);
            if (!String.IsNullOrEmpty(id))
            {
                configModel.cooler = await _context.Coolers.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id));
                id = null;
            }

            string SessionKeyStorage;
            configModel.storages = new List<StorageConfigViewModel>();
            if(configModel.storages != null)
            {
                for (int i = 1; i <= max_storage_amount; i++)
                {
                    SessionKeyStorage = SessionKeyStorageBase + i;
                    id = HttpContext.Session.GetString(SessionKeyStorage);

                    if (!String.IsNullOrEmpty(id))
                    {
                        StorageConfigViewModel stg_data = new StorageConfigViewModel
                        {
                            Storage = await _context.Storages.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Int32.Parse(id)),
                            SessionKeyNumber = i
                        };
                        configModel.storages.Add(stg_data);
                    }
                    id = null;
                }
            }
            


            return View("TempConfig", configModel);
        }

        
    }
}
