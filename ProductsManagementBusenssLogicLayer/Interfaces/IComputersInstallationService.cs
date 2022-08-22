using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.Services
{
    public interface IComputersInstallationService
    {
        Task<IEnumerable<ComputersInstallation>> GetSoftwareForComputers(int computerId, int productId);

    }
}
