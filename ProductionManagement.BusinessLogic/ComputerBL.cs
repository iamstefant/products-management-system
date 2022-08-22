using Microsoft.EntityFrameworkCore;
using ProductsManagement.Models;

namespace ProductionManagement.BusinessLogic
{
    public class ComputersBL : IComputersRepository
    {
        ComputersDbContext _ComputersDbContext;
        public ComputersBL(ComputersDbContext ComputersDbContext)
        {
            _ComputersDbContext = ComputersDbContext;
        }

        public async Task<IEnumerable<Computers>> Add()
        {
            var InstalledComputers = await _ComputersDbContext.Computers.ToListAsync();
            return InstalledComputers;
        }

        public Task<IEnumerable<Computers>> Delete(Computers item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Computers>> GetComputers()
        {
            var InstalledComputers = await _ComputersDbContext.Computers.ToListAsync();
            return InstalledComputers;
        }

        public Task<IEnumerable<Computers>> Update(Computers item)
        {
            throw new NotImplementedException();
        }
    }
}