using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Interfaces;
using ProductManagement.DataAccess.Models;
using ProductManagement.DataAccess.Repositories;
using ProductsManagementBusenssLogic.Services;
using ProductsManagementBusenssLogic.ViewModels.ComputerViewModels;
using ProductsManagementBusenssLogic.ViewModels.OracleProductViewModels;

namespace ProductsManagementBusenssLogic.ComputersBusinessLogic
{
    public class ComputerService : IComputerService
    {
        
        private IComputerRepository _computerRepository;
        public ComputerService(IComputerRepository computerRepository)
        {
            
            _computerRepository = computerRepository;
        }


        public GetComputerViewModel GetComputers()
        {
            var computer = new GetComputerViewModel();

            var InstalledComputers = _computerRepository.GetComputers();

            var computerList = new List<ComputerViewModel>();

            foreach (var inst in InstalledComputers)
            {
                computerList.Add(new ComputerViewModel()
                {
                    ComputerId = inst.ComputerId,
                    ComputerName = inst.ComputerName,
                    OwnerName = inst.OwnerName,
                    Cpu = inst.Cpu,
                    Ram = inst.Ram,
                    Gpu = inst.Gpu,
                    Hdd = inst.Hdd

                });
                
            }

            computer.Computer = computerList;

            return computer;
        }

        public GetComputerByIdViewModel GetComputerById(int id)
        {
           

            var InstalledComputers = _computerRepository.GetComputerById(id);

            var computerById = new GetComputerByIdViewModel();

            computerById.Computer.ComputerId = InstalledComputers.ComputerId;
            computerById.Computer.ComputerName = InstalledComputers.ComputerName;
            computerById.Computer.Ram = InstalledComputers.Ram;
            computerById.Computer.OwnerName = InstalledComputers.OwnerName;
            computerById.Computer.Cpu = InstalledComputers.Cpu;
            computerById.Computer.Gpu = InstalledComputers.Gpu;
            computerById.Computer.Hdd = InstalledComputers.Hdd;

            return computerById;

            
        }

        public GetComputerViewModel SearchComputersByComputerName(string name)
        {
            var searchedComputers = _computerRepository.SearchComputersByComputerName(name);
            
            var computer = new GetComputerViewModel();
                     
            var computerList = new List<ComputerViewModel>();

            foreach (var inst in searchedComputers)
            {
                computerList.Add(new ComputerViewModel()
                {
                    ComputerId = inst.ComputerId,
                    ComputerName = inst.ComputerName,
                    OwnerName = inst.OwnerName,
                    Cpu = inst.Cpu,
                    Ram = inst.Ram,
                    Gpu = inst.Gpu,
                    Hdd = inst.Hdd

                });

            }

            computer.Computer = computerList;

            return computer;

        }
        public GetComputerViewModel SearchComputersByOwnerName(string name)
        {
            var searchedComputers = _computerRepository.SearchComputersByOwnerName(name);
            
            var computer = new GetComputerViewModel();

            var computerList = new List<ComputerViewModel>();

            foreach (var inst in searchedComputers)
            {
                computerList.Add(new ComputerViewModel()
                {
                    ComputerId = inst.ComputerId,
                    ComputerName = inst.ComputerName,
                    OwnerName = inst.OwnerName,
                    Cpu = inst.Cpu,
                    Ram = inst.Ram,
                    Gpu = inst.Gpu,
                    Hdd = inst.Hdd

                });

            }

            computer.Computer = computerList;

            return computer;

        }

        public ComputerDetailsViewModel GetComputerDetails(int computerId)
        {
            var computerDetails = new ComputerDetailsViewModel();

            //this is call to database instead of 3 times we solved with 1 time request
            var computer = _computerRepository.GetComputerDetails(computerId);

            //mapping computer
            computerDetails.Computer.ComputerId = computer.ComputerId;
            computerDetails.Computer.ComputerName = computer.ComputerName;
            computerDetails.Computer.Ram = computer.Ram;
            computerDetails.Computer.OwnerName = computer.OwnerName;
            computerDetails.Computer.Cpu = computer.Cpu;
            computerDetails.Computer.Gpu = computer.Gpu;
            computerDetails.Computer.Hdd = computer.Hdd;

            var oracleInstalledProducts = new List<OracleProductViewModel>();

            //mapping software into list
            foreach (var software in computer.ComputerInstallation)
            {

                oracleInstalledProducts.Add(new OracleProductViewModel()
                {
                    ProductId = software.OracleProduct.ProductId,
                    ProductName = software.OracleProduct.ProductName,
                    ProductDescription = software.OracleProduct.ProductDescription,
                    Price = software.OracleProduct.Price

                });
                computerDetails.TotalCost += software.OracleProduct.Price;
            }


            computerDetails.InstalledOracleProducts = oracleInstalledProducts;

            return computerDetails;

        }


    }

}