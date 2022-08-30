using FakeItEasy;
using Moq;
using NPOI.SS.Formula.Functions;
using ProductManagement.DataAccess.Interfaces;
using ProductManagement.DataAccess.Repositories;
using ProductManagement.DataAccess.Models;
using ProductsManagementBusenssLogic.Services;
using ProductsManagementBusenssLogic.ComputersBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace ProductsManagement.Tests
{
    public class ComputerBusinessLogicTests
    {
        private readonly Mock<IComputerRepository> repository;
        
        public ComputerBusinessLogicTests()
        {
            repository = new Mock<IComputerRepository>();
        }

        [Fact]
        public void GetComputers_ListOfComputers()
        {
            //arrange          
            repository.Setup(x => x.GetComputers())
                .Returns(GetComputers);
            var service = new ComputerService(repository.Object);

            //act
            var actionResult = service.GetComputers();

            //assert
            Assert.Equal(GetComputers().Count(), actionResult.Computer.Count());
        }

        [Fact]
        public void GetComputerById_ListOfOneComputer()
        {
            var computer = new Computer
            {
                ComputerId = 1,
                ComputerName = "Dell5551",
                OwnerName = "Stefan",
                Cpu = "I7-1050",
                Ram = "16gb",
                Gpu = "Nvidia1050",
                Hdd = "512 ssd"
            };
            //arrange          
            repository.Setup(x => x.GetComputerById(It.IsAny<int>()))
                .Returns(computer);
            var service = new ComputerService(repository.Object);

            //act
            var actionResult = service.GetComputerById(1000);

            //assert
            Assert.Equal(computer.ComputerId, actionResult.Computer.ComputerId);
        }
        [Fact]
        public void SearchComputersByTheirName()
        {
            var searchedComputer = new List<Computer>
            {
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
               
            };

            //arrange          
            repository.Setup(x => x.SearchComputersByOwnerName("asasdf", "", "", "", "", ""))
               .Returns(searchedComputer);
            var service = new ComputerService(repository.Object);

            //act
            var actionResult = service.SearchComputersByOwnerName("asasdf", "", "", "", "", "");

            //assert
            Assert.Equal(searchedComputer.Count(), actionResult.Computer.Count());
        }

        [Fact]
        public void NotEqualSearchComputersByTheirName()
        {
        
            //arrange 
            repository.Setup(x => x.SearchComputersByOwnerName("xdcasdas", "", "", "", "", ""))
                 .Returns(GetComputers);
            var service = new ComputerService(repository.Object);

            //act
            var actionResult = service.SearchComputersByOwnerName("xdcasdas", "", "", "", "", "");

            //assert
            Assert.NotEqual(GetComputers().ToString(), actionResult.ToString());
        }

        [Fact]
        public void SearchComputersByOwnerNameEmptyStringsSituation()
        {

            //arrange 
            repository.Setup(x => x.SearchComputersByOwnerName("", "", "", "", "", ""))
                 .Returns(GetComputers);
            var service = new ComputerService(repository.Object);

            //act
            var actionResult = service.SearchComputersByOwnerName("", "", "", "", "", "");

            //assert 
            Assert.Equal(GetComputers().Count(), actionResult.Computer.Count());
        }

        [Fact]
        public void GetComputerDetails()
        {
            var computer = new Computer
            {
                ComputerId = 1,
                ComputerName = "Dell5551",
                OwnerName = "Stefan",
                Cpu = "I7-1050",
                Ram = "16gb",
                Gpu = "Nvidia1050",
                Hdd = "512 ssd",
                ComputerInstallation = new List<ComputerInstallation>
                {
                    new ComputerInstallation
                    {
                        Id = 1,
                        PersonOfInstallation = "Stefan",
                        ComputerId = 1,
                        ProductId = 1,
                        OracleProduct = new OracleProduct
                        {
                            ProductId = 1,
                            ProductName = "Java",
                            ProductDescription = "Programming language",
                            Price = 25

                        }

                    },
                    new ComputerInstallation
                    {
                        Id = 4,
                        PersonOfInstallation = "Stefan",
                        ComputerId = 1,
                        ProductId = 2,
                        OracleProduct = new OracleProduct
                        {
                            ProductId = 2,
                            ProductName = "ClusterWare",
                            ProductDescription = "Infrastructure",
                            Price = 500

                        }

                    }

                }
            };
       
            //arrange
            repository.Setup(x => x.GetComputerDetails(It.IsAny<int>()))
                .Returns(computer);
            var service = new ComputerService(repository.Object);

            //act
            var actionResult = service.GetComputerDetails(1);

            //assert 
            Assert.Equal(computer.ComputerInstallation.Count(), actionResult.InstalledOracleProducts.Count());

        }

        private List<Computer> GetComputers()
        {
            List<Computer> output = new List<Computer>
        {
            new Computer 
            {
                 ComputerId = 1,
                 ComputerName = "Dell5551",
                 OwnerName = "Stefan",
                 Cpu = "I7-1050",
                 Ram = "16gb",
                 Gpu = "Nvidia1050",
                 Hdd = "512 ssd"
            }, 
            new Computer
            {
                 ComputerId = 2,
                 ComputerName = "Asus ZenBook",
                 OwnerName = "Risto",
                 Cpu = "I7-1150",
                 Ram = "32gb",
                 Gpu = "Nvidia1060",
                 Hdd = "512 ssd"
            },
            new Computer
            {
                 ComputerId = 3,
                 ComputerName = "Lenovo",
                 OwnerName = "Dejan",
                 Cpu = "I7-1250",
                 Ram = "64gb",
                 Gpu = "Nvidia3050",
                 Hdd = "512 ssd"
            },
            new Computer
            {
                 ComputerId = 4,
                 ComputerName = "Msi",
                 OwnerName = "Nikola",
                 Cpu = "I5-4440",
                 Ram = "16gb",
                 Gpu = "Amd Rx 560",
                 Hdd = "512 ssd"
            },
            new Computer
            {
                 ComputerId = 5,
                 ComputerName = "string",
                 OwnerName = "string",
                 Cpu = "string",
                 Ram = "string",
                 Gpu = "string",
                 Hdd = "string"
            },
            new Computer
            {
                 ComputerId = 6,
                 ComputerName = "stefanssss",
                 OwnerName = "stefan",
                 Cpu = "dasd",
                 Ram = "sdadas",
                 Gpu = "sdasdsa",
                 Hdd = "dadsa"
            },
            new Computer
            {
                 ComputerId = 8,
                 ComputerName = "string",
                 OwnerName = "string",
                 Cpu = "string",
                 Ram = "string",
                 Gpu = "string",
                 Hdd = "string"
            }
        }; 
            return output;
        }

    }


}