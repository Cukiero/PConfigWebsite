
using Microsoft.EntityFrameworkCore;
using Moq;
using PConfigAuth.Data;
using PConfigAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using PConfigAuth.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace PConfigAuth
{
    public class Test
    {
        private ApplicationDbContext _context;
        private ConfigureController _service;
        private UserManager<ApplicationUser> _userManager;
        private List<PC> list;
        private ILogger<ConfigureController> _logger;
        private PC pcdata;

        public Test()
        {

            DbContextOptions<ApplicationDbContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase();
            options = builder.Options;

            ApplicationDbContext _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();

            _service = new ConfigureController(_context, _userManager, _logger);

            var user = new ApplicationUser { UserName = "dan123", Email = "dandan@gmail.com" };
            var cpu = new CPU
            {
                Name = "i5-8400",
                Manufacturer = "Intel",
                Series = "i5",
                Socket = "1151",
                Cores = "6",
                TDP = "65",
                iGPU = 1,
                Price = "829"
            };

            var mobo = new MOBO
            {
                Name = "Z370-A PRO",
                Manufacturer = "MSI",
                Standard = "ATX",
                Chipset = "Z370",
                Socket = "1151",
                Ram_type = "DDR4",
                Price = "519"
            };

            var casePC =
                new Case
                {
                    Name = "BIG",
                    Manufacturer = "Corsair",
                    Price = "500"
                };


            var psu = new PSU
            {
                Name = "EVGA Supernnova G2",
                Manufacturer = "EVGA",
                Wattage = "550",
                Price = "329"
            };

            var ram = new RAM
            {
                Name = "Corsair Vengeance LPX",
                Manufacturer = "Corsair",
                Ram_type = "DDR4",
                Speed = "3000",
                Price = "619"
            };

            var cooler = new Cooler
            {
                Name = "Noctua NH-D15",
                Socket = "1151",
                Fans = "2",
                Price = "400"
            };

            var gpu = new GPU
            {
                Name = "MSI GTX 1070TI GAMING",
                Manufacturer = "MSI",
                Chipset = "GTX 1070TI",
                TDP = "200",
                Price = "2100"
            };

            _service.AddConfiguration(cpu, gpu, mobo, ram, psu, casePC, cooler,user);

            list = _service.GetPCs();
            pcdata = list.FirstOrDefault();
        }
       [Fact]
        public void PC_Test()
        {
           
            Assert.IsType(typeof(PC), pcdata);
            Assert.IsType(typeof(CPU), pcdata.CPU);
            Assert.IsType(typeof(MOBO), pcdata.MOBO);
            Assert.IsType(typeof(RAM), pcdata.RAM);
            Assert.IsType(typeof(PSU), pcdata.PSU);
            Assert.IsType(typeof(Case), pcdata.Case);
            Assert.IsType(typeof(Cooler), pcdata.Cooler);
            Assert.IsType(typeof(ApplicationUser), pcdata.ApplicationUser);

        }
        [Fact]
        public void CPU_PositiveTest()
        {

            Assert.Equal("i5-8400", pcdata.CPU.Name);
            Assert.Equal("Intel", pcdata.CPU.Manufacturer);
            Assert.True(Convert.ToBoolean(pcdata.CPU.iGPU));
        }
        
        [Fact]
        public void CPU_NegativeTest()
        {
 
            Assert.Equal("Ryzen 1600", pcdata.CPU.Name);
            Assert.Equal("AMD", pcdata.CPU.Manufacturer);
        }

        [Fact]
        public void StorageTest()
        {
            Assert.Null(pcdata.PC_Storage);
        }

        [Fact]
        public void UsernameTest()
        {
            Assert.Equal("dan123", pcdata.ApplicationUser.UserName);
        }

        [Fact]
        public void FakeUserTest()
        {
            var fakeuser = new ApplicationUser { UserName = "Hakerman", Email = "gmail@zxcv.com" };
            Assert.False(fakeuser.Equals(pcdata.ApplicationUser));
        }
    }
}
