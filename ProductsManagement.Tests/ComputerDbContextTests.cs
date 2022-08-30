using FakeItEasy;
using Moq;
using NPOI.SS.Formula.Functions;
using ProductManagement.DataAccess.Interfaces;
using ProductManagement.DataAccess.Repositories;
using ProductManagement.DataAccess.Models;
using ProductsManagementBusenssLogic.Services;
using ProductsManagementBusenssLogic.ComputersBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.DbContexts;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.Graph;

namespace ProductsManagement.Tests
{
    public class ComputerDbContextTests
    {
        private Mock<ProductDbContext> _context;
        private ComputerRepository _repo;
        public ComputerDbContextTests()
        {
            _context = new Mock<ProductDbContext>();
        }
        

        [Fact]
        public void SearchComputersByTheirName()
        {
            ////Arrange          

            var data = new List<Computer> {
                 new Computer
                {
                     ComputerId = 3,
                     ComputerName = "Lenovo",
                     OwnerName = "Dejan",
                     Cpu = "I7-1250",
                     Ram = "64gb",
                     Gpu = "Nvidia3050",
                     Hdd = "512 ssd"
                }

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Computer>>();
            mockSet.As<IQueryable<Computer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Computer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Computer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Computer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            _context = new Mock<ProductDbContext>();

            //Set the context of mock object to  the data we created.
          //  _context.Setup(c => c.SearchComputersByOwnerName("","","","","","")).Returns(mockSet.Object);

            //Create instance of WorldRepository by injecting mock DbContext we created
            _repo = new ComputerRepository(_context.Object);


            //Act
            //_repo.SearchComputersByOwnerName("Lenovo", "", "", "", "", "",
            //    new Computer
            //    {
            //        ComputerId = 3,
            //         ComputerName = "Lenovo",
            //         OwnerName = "Dejan",
            //         Cpu = "I7-1250",
            //         Ram = "64gb",
            //         Gpu = "Nvidia3050",
            //         Hdd = "512 ssd"
            //    });

            _repo.SearchComputersByOwnerName("Lenovo", "", "", "", "", "");

            var count = _repo.SearchComputersByOwnerName("Lenovo", "", "", "", "", "").Count();

            //Assert
            Assert.Equal(1, count);



        }

    }


}