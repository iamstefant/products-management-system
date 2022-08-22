using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManagement.BusinessLogic
{
    public class ComputersBO
    {
        IComputersRepository _ComputersRepository;
        public ComputersBO(IComputersRepository ComputersRepository)
        {
            _ComputersRepository = ComputersRepository;
        }

        public async Task<Computers> GetComputers()
        {
            var InstalledComputers = await _ComputersRepository.GetComputers();
            return (Computers)InstalledComputers;
        }
    }
}
