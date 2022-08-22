using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Interfaces
{
    public interface IComputerRepository
    {
        IEnumerable<Computer> GetComputers();
        Computer GetComputerById(int id);
        IEnumerable<Computer> SearchComputersByComputerName(string name);
        IEnumerable<Computer> SearchComputersByOwnerName(string name);
        Computer GetComputerDetails(int id);

    }
}
