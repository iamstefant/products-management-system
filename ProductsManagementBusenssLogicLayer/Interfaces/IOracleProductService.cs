using ProductManagement.DataAccess.Models;
using ProductsManagementBusenssLogic.ViewModels.OracleProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.Services
{
    public interface IOracleProductService
    {
        GetOracleProductViewModel GetOracleProducts();
        GetOracleProductByIdViewModel GetOracleProductById(int id);
        GetOracleProductViewModel SearchOracleProductsByName(string name);
        OracleProductDetailsViewModel GetProductDetails(int id);

    }
}
 