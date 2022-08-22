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
    public class OracleProductRepository : IOracleProductRepository
    {
        private ProductDbContext _productDbContext;
        public OracleProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public IEnumerable<OracleProduct> GetOracleProducts()
        {
            return _productDbContext.OracleProduct;
            
        }

        public OracleProduct GetOracleProductById(int id)
        {
            return _productDbContext.OracleProduct.FirstOrDefault(foundProduct => foundProduct.ProductId == id);
           
        }

        public IEnumerable<OracleProduct> SearchOracleProductsByName(string name)
        {
            IQueryable<OracleProduct> query = _productDbContext.OracleProduct;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(foundResult => foundResult.ProductName.Contains(name));
            }
            return query.ToList();
        }
        public OracleProduct GetProductDetails(int id)
        {
            var computers = _productDbContext.OracleProduct
                .Include("ComputerInstallation.Computer")
                .FirstOrDefault(p => p.ProductId == id);

            return computers;
        }

    }
}
