
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


namespace PConfigAuth
{
    public class Test
    {
    
        private ApplicationDbContext _context;
        private Case_service _service;
        private List<Case> list;
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

            _service = new Case_service(_context);
            _service.AddCase("Duzy", "Fractal", "666");
            _service.AddCase("Ogromny", "SPC", "1000");
            list = _service.GetCases();
            
        }
        [Fact]
        public void AddCaseTest()
        {                    

            var case1= list.Find(x => x.Id == 1);
            Assert.IsType(typeof(Case), case1);
            Assert.Equal("Duzy", case1.Name);
            Assert.Equal("Fractal", case1.Manufacturer);
            Assert.Equal("666", case1.Price);

            var case2 = list.Find(x => x.Price == "1000");
            Assert.IsType(typeof(Case), case2);
            Assert.Equal("Ogromny", case2.Name);
            Assert.Equal("SPC", case2.Manufacturer);
            Assert.Equal(2, case2.Id);
 
        }
        
        /*
        [Fact]
        public void Addcasetest()
        {

            var mockSet = new Mock<DbSet<Case>>();

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Cases).Returns(mockSet.Object);

            var service = new Case_service(mockContext.Object);
            service.AddCase("Duzy", "Fractal", "666");
            service.AddCase("Ogromny", "SPC", "1000");
            List <Case> list = service.GetCases();

            mockSet.Verify(m => m.Add(It.IsAny<Case>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        */


    }
    
}
