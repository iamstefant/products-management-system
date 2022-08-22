using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Models;
using ProductsManagementBusenssLogic.ViewModels.OracleProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.ViewModels.ComputerViewModels
{
    public class ComputerDetailsViewModel
    {

        public ComputerViewModel Computer { get; set; }
        public List<OracleProductViewModel> InstalledOracleProducts { get; set; }
        public decimal TotalCost { get; set; } = 0;



        public ComputerDetailsViewModel()
        {
            Computer = new ComputerViewModel();
            InstalledOracleProducts = new List<OracleProductViewModel>();
        }

    }

}
