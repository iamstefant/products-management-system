using ProductManagement.DataAccess.Models;
using ProductsManagementBusenssLogic.ViewModels.ComputerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.Services
{
    public interface IComputerService
    {
        GetComputerViewModel GetComputers();
        GetComputerByIdViewModel GetComputerById(int id);
        GetComputerViewModel SearchComputersByComputerName(string name);
        GetComputerViewModel SearchComputersByOwnerName(string name);
        // ComputerDetailsViewModel GetComputerDetails(int id);
        ComputerDetailsViewModel GetComputerDetails(int id);
    }
}
