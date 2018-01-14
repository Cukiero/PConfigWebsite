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
                    Name = "BIG",
                    Manufacturer = "Corsair",
                    Price = "500"
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
                    is_SSD = "1",
                    Price = "389"
                },
                 new Storage
                {
                    Name = "Toshiba P300",
                    Manufacturer = "Toshiba",
                    Size = "1000",
                    is_SSD = "0",
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
