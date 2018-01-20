using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PConfigAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace PConfigAuth.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.CPUs.Any())
            {
                return;   // DB has been seeded
            }
            // CPU
            var CPUs = new CPU[]
            {
                new CPU
                {
                    Name = "i5-8400",
                    Manufacturer = "Intel",
                    Series = "i5",
                    Socket = "1151",
                    Cores = "6",
                    TDP = "65",
                    iGPU = 1,
                    Price = "829"
                },
                new CPU
                {
                    Name = "Ryzen 5 1600",
                    Manufacturer = "AMD",
                    Series = "Ryzen 5",
                    Socket = "AM4",
                    Cores = "6",
                    TDP = "65",
                    iGPU = 0,
                    Price = "899"
                },
                new CPU
                {
                    Name = "Ryzen 7 1700",
                    Manufacturer = "AMD",
                    Series = "Ryzen 7",
                    Socket = "AM4",
                    Cores = "8",
                    TDP = "95",
                    iGPU = 0,
                    Price = "1299"
                },
               new CPU
                {
                    Name = "i7-8600",
                    Manufacturer = "Intel",
                    Series = "i7",
                    Socket = "1151",
                    Cores = "6",
                    TDP = "95",
                    iGPU = 1,
                    Price = "1459"
                }
            };

            foreach (CPU c in CPUs)
            {
                context.CPUs.Add(c);
            }
            context.SaveChanges();



            //MOBO

            var Moboes = new MOBO[] {
                new MOBO
                {
                    Name = "Z370-A PRO",
                    Manufacturer = "MSI",
                    Standard = "ATX",
                    Chipset = "Z370",
                    Socket = "1151",
                    Ram_type = "DDR4",
                    Price = "519"
                },
                new MOBO
                {
                    Name = "MSI B350 TOMAHAWK",
                    Manufacturer = "MSI",
                    Standard = "ATX",
                    Chipset = "B350",
                    Socket = "AM4",
                    Ram_type = "DDR4",
                    Price = "384"
                },
                 new MOBO
                {
                    Name = "ASUS PRIME X370 PRO",
                    Manufacturer = "ASUS",
                    Standard = "ATX",
                    Chipset = "X370",
                    Socket = "AM4",
                    Ram_type = "DDR4",
                    Price = "645"
                },
                  new MOBO
                {
                    Name = "Gigabyte GA-AB350-GAMING 3",
                    Manufacturer = "Gigabyte",
                    Standard = "ATX",
                    Chipset = "B350",
                    Socket = "AM4",
                    Ram_type = "DDR4",
                    Price = "429"
                },
                   new MOBO
                {
                    Name = "ASRock Z370 EXTREME4",
                    Manufacturer = "ASRock",
                    Standard = "ATX",
                    Chipset = "Z370",
                    Socket = "1151",
                    Ram_type = "DDR4",
                    Price = "655"
                }
            };

            foreach (MOBO m in Moboes)
            {
                context.MOBOes.Add(m);
            }
            context.SaveChanges();


            // CASE

            var Cases = new Case[]
            {
                new Case
                {
                    Name = "Pure Base 600 ",
                    Manufacturer = "be quiet!",
                    Price = "359"
                },
                   new Case
                {
                    Name = "Z3 PLUS",
                    Manufacturer = "Zalman",
                    Price = "160"
                },
                       new Case
                {
                    Name = "Carbide 400C ",
                    Manufacturer = "Corsair",
                    Price = "323"
                },
                           new Case
                {
                    Name = "Gladius M35",
                    Manufacturer = "SilentiumPC",
                    Price = "188"
                },
                      new Case
                {
                    Name = "Define R5",
                    Manufacturer = "Fractal Design",
                    Price = "469"
                }
            };
            foreach (Case c in Cases)
            {
                context.Cases.Add(c);
            }
            context.SaveChanges();

            // PSU

            var PSUs = new PSU[]
            {
                new PSU
                {
                    Name = "EVGA Supernnova G2",
                    Manufacturer = "EVGA",
                    Wattage = "550",
                    Price = "329"
                },
                  new PSU
                {
                    Name = "Corsair VS",
                    Manufacturer = "Corsair",
                    Wattage = "550",
                    Price = "183"
                },
                      new PSU
                {
                    Name = "be quiet! Pure Power L8",
                    Manufacturer = "be quiet!",
                    Wattage = "600",
                    Price = "343"
                },
                          new PSU
                {
                    Name = "be quiet! POWER ZONE 650W",
                    Manufacturer = "be quiet!",
                    Wattage = "650",
                    Price = "406"
                },
                    new PSU
                {
                    Name = "Corsair RM550X",
                    Manufacturer = "Corsair",
                    Wattage = "550",
                    Price = "379"
                }
            };

            foreach (PSU c in PSUs)
            {
                context.PSUs.Add(c);
            }
            context.SaveChanges();


            // RAM

            var RAMs = new RAM[]
            {
                new RAM
                {
                    Name = "Corsair Vengeance LPX",
                    Manufacturer = "Corsair",
                    Ram_type = "DDR4",
                    Speed = "3000",
                    Price = "619"
                },
                  new RAM
                {
                    Name = "G.Skill Ripjaws V",
                    Manufacturer = "G.Skill",
                    Ram_type = "DDR4",
                    Speed = "3200",
                    Price = "849"
                },
                    new RAM
                {
                    Name = "ADATA XPG",
                    Manufacturer = "ADATA",
                    Ram_type = "DDR4",
                    Speed = "2400",
                    Price = "729"
                },
                      new RAM
                {
                    Name = "Ballistix Sport LT",
                    Manufacturer = "Ballistix",
                    Ram_type = "DDR4",
                    Speed = "2400",
                    Price = "384"
                }
            };

            foreach (RAM c in RAMs)
            {
                context.RAMs.Add(c);
            }
            context.SaveChanges();

            // Cooler

            var Coolers = new Cooler[]
            {
                 new Cooler
                {
                    Name = "Noctua NH-D15",
                    Socket = "1151",
                    Fans = "2",
                    Price = "400"
                },
                new Cooler
                {
                    Name = "SilentiumPC Grandis2 XE1436",
                    Socket = "AM4",
                    Fans = "2",
                    Price = "199"
                },
                   new Cooler
                {
                    Name = "be quiet! Dark Rock PRO 3 ",
                    Socket = "1151",
                    Fans = "2",
                    Price = "321"
                },
                      new Cooler
                {
                    Name = "Thermalright Macho Rev. B",
                    Socket = "AM4",
                    Fans = "1",
                    Price = "230"
                }
            };

            foreach (Cooler c in Coolers)
            {
                context.Coolers.Add(c);
            }
            context.SaveChanges();


            // GPU 

            var GPUs = new GPU[]
           {
                 new GPU
                {
                    Name = "MSI GTX 1070TI GAMING",
                    Manufacturer = "MSI",
                    Chipset = "GTX 1070TI",
                    TDP = "200",
                    Price = "2100"
                },
                   new GPU
                {
                    Name = "Gigabyte GeForce GTX1080 WINDFORCE OC",
                    Manufacturer = "Gigabyte",
                    Chipset = "GTX 1080",
                    TDP = "250",
                    Price = "3199"
                },
                     new GPU
                {
                    Name = "Gigabyte GeForce GTX 1050Ti GAMING G1",
                    Manufacturer = "Gigabyte",
                    Chipset = "GTX 1050TI",
                    TDP = "120",
                    Price = "889"
                },
                       new GPU
                {
                    Name = "ASUS GeForce GTX 1060 Strix OC 6GB",
                    Manufacturer = "MSI",
                    Chipset = "GTX 1060",
                    TDP = "150",
                    Price = "1709"
                }
           };

            foreach (GPU c in GPUs)
            {
                context.GPUs.Add(c);
            }
            context.SaveChanges();


            // STORAGE
            var Storages = new Storage[]
           {
                 new Storage
                {
                    Name = "GOODRAM SSD IRIDIUM PRO",
                    Manufacturer = "GOODRAM",
                    Size = "240",
                    Type = "SSD",
                    Price = "389"
                },
                   new Storage
                {
                    Name = "Crucial MX300",
                    Manufacturer = "Crucial",
                    Size = "275",
                    Type = "SSD",
                    Price = "369"
                },
                        new Storage
                {
                    Name = "Transcend SSD370",
                    Manufacturer = "Transcend",
                    Size = "128",
                    Type = "SSD",
                    Price = "259"
                },
                 new Storage
                {
                    Name = "Toshiba P300",
                    Manufacturer = "Toshiba",
                    Size = "1000",
                    Type = "HDD",
                    Price = "189"
                },
                   new Storage
                {
                    Name = "Seagate BarraCuda",
                    Manufacturer = "Seagate",
                    Size = "1000",
                    Type = "HDD",
                    Price = "189"
                }

           };

            foreach (Storage c in Storages)
            {
                context.Storages.Add(c);
            }
            context.SaveChanges();

        }
    }
}
