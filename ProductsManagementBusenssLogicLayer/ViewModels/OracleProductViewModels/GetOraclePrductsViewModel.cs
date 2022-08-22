using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.ViewModels.OracleProductViewModels
{
    public class GetOracleProductViewModel
    {
        public List<OracleProductViewModel> OracleProduct { get; set; }


        public GetOracleProductViewModel()
        {
            OracleProduct = new List<OracleProductViewModel>();
        }

    }

}
