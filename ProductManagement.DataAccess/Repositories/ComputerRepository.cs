using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Interfaces;
using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private ProductDbContext _productDbContext;
        public ComputerRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public Computer GetComputerById(int id)
        {
            return _productDbContext.Computer.FirstOrDefault(x => x.ComputerId == id);
        }

        public IEnumerable<Computer> GetComputers()
        {
            return _productDbContext.Computer;
        }
        public IEnumerable<Computer> SearchComputersByComputerName(string name)
        {
            IQueryable<Computer> query = _productDbContext.Computer;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(foundResult => foundResult.ComputerName.Contains(name));
            }

            return query.ToList();
        }
        public IEnumerable<Computer> SearchComputersByOwnerName(string name)
        {
            IQueryable<Computer> query = _productDbContext.Computer.Where(foundResult => foundResult.OwnerName.Contains(name));

            return query.ToList();
        }

        public Computer GetComputerDetails(int id)
        {
            //var foundProduct = _productDbContext.ComputerInstallation.Where(software => software.ComputerId == id).Select(y => y.ProductId).ToList();

            //var installedSoftware = _productDbContext.OracleProduct.Where(x => foundProduct.Contains(x.ProductId));

            // return installedSoftware;

            var computers = _productDbContext.Computer
               .Include("ComputerInstallation.OracleProduct")
               .FirstOrDefault(p => p.ComputerId == id);

            return computers;
        }

    }
}


