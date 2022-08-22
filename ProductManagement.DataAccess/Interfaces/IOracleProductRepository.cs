using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Interfaces
{
    public interface IOracleProductRepository
    {
        IEnumerable<OracleProduct> GetOracleProducts();
        OracleProduct GetOracleProductById(int id);
        IEnumerable<OracleProduct> SearchOracleProductsByName(string name);
        OracleProduct GetProductDetails(int id);

    }
}
