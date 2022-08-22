using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.ViewModels.ComputerViewModels
{
    public class GetComputerByIdViewModel
    {
        public ComputerViewModel Computer { get; set; }


        public GetComputerByIdViewModel()
        {
            Computer = new ComputerViewModel();
        }

    }

}
