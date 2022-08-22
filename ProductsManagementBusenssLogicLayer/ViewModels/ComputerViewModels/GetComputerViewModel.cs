using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.ViewModels.ComputerViewModels
{
    public class GetComputerViewModel
    {
        public List<ComputerViewModel> Computer { get; set; }


        public GetComputerViewModel()
        {
            Computer = new List<ComputerViewModel>();
        }

    }

}
