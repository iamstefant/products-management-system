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
    public class OracleProductService : IOracleProductService
    {
        
    
        private IOracleProductRepository _oracleProductRepository;
        public OracleProductService(IOracleProductRepository oracleProductRepository)
        {
            _oracleProductRepository = oracleProductRepository;
        }

        public GetOracleProductViewModel GetOracleProducts()
        {
                       
            var getOracleProduct = new GetOracleProductViewModel();

            var oracleProducts = _oracleProductRepository.GetOracleProducts();

            var oralceProductList = new List<OracleProductViewModel>();

            foreach (var inst in oracleProducts)
            {
                oralceProductList.Add(new OracleProductViewModel()
                {
                    ProductId = inst.ProductId,
                    ProductName = inst.ProductName,
                    ProductDescription = inst.ProductDescription,
                    Price = inst.Price,

                });

            }

            getOracleProduct.OracleProduct = oralceProductList;

            return getOracleProduct;
        }

        public GetOracleProductByIdViewModel GetOracleProductById(int id)
        {
            
            var oracleProductId = _oracleProductRepository.GetOracleProductById(id);

            var oracleProduct = new GetOracleProductByIdViewModel();

            oracleProduct.OracleProduct.ProductId = oracleProductId.ProductId;
            oracleProduct.OracleProduct.ProductName = oracleProductId.ProductName;
            oracleProduct.OracleProduct.ProductDescription = oracleProductId.ProductDescription;    
            oracleProduct.OracleProduct.Price = oracleProductId.Price;
           
            return oracleProduct;



        }

        public GetOracleProductViewModel SearchOracleProductsByName(string name)
        {
            var searchedProducts = _oracleProductRepository.SearchOracleProductsByName(name);

            var oracleProduct = new GetOracleProductViewModel();

            var oracleProductList = new List<OracleProductViewModel>();

            foreach (var inst in searchedProducts)
            {
                oracleProductList.Add(new OracleProductViewModel()
                {
                    ProductId = inst.ProductId,
                    ProductName = inst.ProductName,
                    ProductDescription = inst.ProductDescription,
                    Price = inst.Price
                });

            }

            oracleProduct.OracleProduct= oracleProductList;

            return oracleProduct;


        }
        

        public OracleProductDetailsViewModel GetProductDetails(int id)
        {
            var oracleProductDetails = new OracleProductDetailsViewModel();

            //this is call to database instead of 3 times we solved with 1 time request
            var oracleProduct = _oracleProductRepository.GetProductDetails(id);

            //mapping computer
            oracleProductDetails.OracleProduct.ProductId = oracleProduct.ProductId;
            oracleProductDetails.OracleProduct.ProductName = oracleProduct.ProductName;
            oracleProductDetails.OracleProduct.ProductDescription = oracleProduct.ProductDescription;
            oracleProductDetails.OracleProduct.Price = oracleProduct.Price;
            
            var installedComputers = new List<ComputerViewModel>();

            //mapping software into list
            foreach (var comps in oracleProduct.ComputerInstallation)
            {

                installedComputers.Add(new ComputerViewModel()
                {
                    ComputerId = comps.Computer.ComputerId,
                    ComputerName = comps.Computer.ComputerName,
                    OwnerName = comps.Computer.ComputerName,
                    Cpu = comps.Computer.Cpu,
                    Ram = comps.Computer.Ram,
                    Gpu = comps.Computer.Gpu,
                    Hdd = comps.Computer.Hdd

                });
                
            }


            oracleProductDetails.InstalledComputers = installedComputers;

            return oracleProductDetails;





        }
    }
}