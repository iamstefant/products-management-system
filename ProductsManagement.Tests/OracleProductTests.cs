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
    public class OracleProductTests
    {
        private readonly Mock<IOracleProductRepository> repository;
        public OracleProductTests()
        {
            repository = new Mock<IOracleProductRepository>();
        }

        [Fact]
        public void GetOracleProducts_ListOfOracleProducts()
        {
            //arrange          
            repository.Setup(x => x.GetOracleProducts())
                .Returns(GetOracleProducts);
            var service = new OracleProductService(repository.Object);

            //act
            var actionResult = service.GetOracleProducts();

            //assert
            Assert.Equal(GetOracleProducts().Count(), actionResult.OracleProduct.Count());
        }

        [Fact]
        public void GetOracleProductById_ListOfOneProduct()
        {
            var oracleProduct = new OracleProduct
            {
                ProductId = 1,
                ProductName = "Java",
                ProductDescription = "Programming language",
                Price = 25
            };
            //arrange          
            repository.Setup(x => x.GetOracleProductById(It.IsAny<int>()))
                .Returns(oracleProduct);
            var service = new OracleProductService(repository.Object);

            //act
            var actionResult = service.GetOracleProductById(1);

            //assert
            Assert.Equal(oracleProduct.ProductId, actionResult.OracleProduct.ProductId);
        }

        [Fact]
        public void SearchOracleProductsByTheirName()
        {
            var searchedProduct = new List<OracleProduct>
            {
                new OracleProduct
                {
                     ProductId = 1,
                     ProductName = "Java",
                     ProductDescription = "Programming language",
                     Price = 25
                }

            };

            //arrange          
            repository.Setup(x => x.SearchOracleProductsByName("ja"))
                .Returns(searchedProduct);
            var service = new OracleProductService(repository.Object);

            //act
            var actionResult = service.SearchOracleProductsByName("ja");

            //assert
            Assert.Equal(searchedProduct.Count(), actionResult.OracleProduct.Count());
        }

        [Fact]
        public void GetOracleProductDetails()
        {
            var oracleProduct = new OracleProduct
            {
                ProductId = 1,
                ProductName = "Java",
                ProductDescription = "Programming language",
                Price = 25,
                ComputerInstallation = new List<ComputerInstallation>
                {
                    new ComputerInstallation
                    {
                        Id = 1,
                        PersonOfInstallation = "Stefan",
                        ComputerId = 1,
                        ProductId = 1,
                        Computer = new Computer
                        {
                             ComputerId = 1,
                             ComputerName = "Dell5551",
                             OwnerName = "Stefan",
                             Cpu = "I7-1050",
                             Ram = "16gb",
                             Gpu = "Nvidia1050",
                             Hdd = "512 ssd"

                        }

                    },
                    new ComputerInstallation
                    {
                        Id = 5,
                        PersonOfInstallation = "Stefan",
                        ComputerId = 2,
                        ProductId = 1,
                        Computer = new Computer
                        {
                             ComputerId = 2,
                             ComputerName = "Asus ZenBook",
                             OwnerName = "Risto",
                             Cpu = "I7-1150",
                             Ram = "32gb",
                             Gpu = "Nvidia1060",
                             Hdd = "512 ssd"

                        }

                    }

                }
            };

            //arrange
            repository.Setup(x => x.GetProductDetails(It.IsAny<int>()))
                .Returns(oracleProduct);
            var service = new OracleProductService(repository.Object);

            //act
            var actionResult = service.GetProductDetails(1);

            //assert 
            Assert.Equal(oracleProduct.ComputerInstallation.Count(), actionResult.InstalledComputers.Count());

        }

        private List<OracleProduct> GetOracleProducts()
        {
            List<OracleProduct> output = new List<OracleProduct>
        {
            new OracleProduct
            {
                 ProductId = 1,
                 ProductName = "Java",
                 ProductDescription = "Programming language",
                 Price = 25
            },
            new OracleProduct
            {
                ProductId = 2,
                ProductName = "ClusterWare",
                ProductDescription = "Infrastructure",
                Price = 500

            },
            new OracleProduct
            {
                 ProductId = 3,
                 ProductName = "Sales Planning",
                 ProductDescription = "Data driven tools",
                 Price = 750
            }
        };
            return output;
        }

    }


}