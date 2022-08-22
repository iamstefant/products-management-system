using ProductsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManagement.BusinessLogic
{
    public interface IComputersRepository
    {
        Task<IEnumerable<Computers>> GetComputers();
        Task<IEnumerable<Computers>> Add();
        Task<IEnumerable<Computers>> Update(Computers item);
        Task<IEnumerable<Computers>> Delete(Computers item);


    }
}
