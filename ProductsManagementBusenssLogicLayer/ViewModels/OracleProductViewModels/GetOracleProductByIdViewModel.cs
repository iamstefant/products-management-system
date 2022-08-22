using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.ViewModels.OracleProductViewModels
{
    public class GetOracleProductByIdViewModel
    {
        public OracleProductViewModel OracleProduct { get; set; }


        public GetOracleProductByIdViewModel()
        {
            OracleProduct = new OracleProductViewModel();
        }

    }

}
