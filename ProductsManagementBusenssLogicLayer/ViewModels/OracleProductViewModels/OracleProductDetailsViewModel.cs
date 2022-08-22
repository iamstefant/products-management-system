using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Models;
using ProductsManagementBusenssLogic.ViewModels.ComputerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.ViewModels.OracleProductViewModels
{
    public class OracleProductDetailsViewModel
    {

        public OracleProductViewModel OracleProduct { get; set; }
        public List<ComputerViewModel> InstalledComputers { get; set; }
        public decimal TotalCost { get; set; } = 0;



        public OracleProductDetailsViewModel()
        {
            OracleProduct = new OracleProductViewModel();
            InstalledComputers = new List<ComputerViewModel>();
        }

    }

}
