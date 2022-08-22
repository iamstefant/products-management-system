using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsManagementBusenssLogic.Services;

namespace ProductsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OracleProductController : ControllerBase
    {
        
        private readonly IOracleProductService _oracleProductService;

        public OracleProductController(IOracleProductService oracleProductsService)
        {
            _oracleProductService = oracleProductsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOracleProducts()
        {
            var InstalledProducts = _oracleProductService.GetOracleProducts();
            return Ok(InstalledProducts);
        }

        [Route("/GetOracleProductsById")]
        [HttpGet]
        public async Task<IActionResult> GetOracleProductById(int id)
        {
            var oracleProduct = _oracleProductService.GetOracleProductById(id);

            if (oracleProduct == null)
                return NotFound();
            else
                return Ok(oracleProduct);
        }

        [Route("/SearchOracleProductsByName")]
        [HttpGet]
        public IActionResult SearchProductsByProductName(string? name)
        {
            var foundProducts =  _oracleProductService.SearchOracleProductsByName(name ?? String.Empty);

            if (foundProducts == null)
                return BadRequest();
            else
                return Ok(foundProducts);
        }

        [Route("/GetComputersForSoftware")]
        [HttpGet]
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var foundComputers =  _oracleProductService.GetProductDetails(id);

            if (foundComputers == null)
                return BadRequest();
            else
                return Ok(foundComputers);
        }

    }
}
