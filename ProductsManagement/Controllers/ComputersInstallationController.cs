using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsManagementBusenssLogic.Services;

namespace ProductsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersInstallationController : ControllerBase
    {
        private readonly IComputersInstallationService _computerService;

        public ComputersInstallationController(IComputersInstallationService busnessObject)
        {
            _computerService = busnessObject;
        }
                     

        [Route("{search}")]
        [HttpGet]
        public async Task<IActionResult> SearchAsyncSoftwareForPc(int computerId, int productId)
        {
            var foundedSoftware = await _computerService.GetSoftwareForComputers(computerId, productId);

            if (foundedSoftware == null)
                return BadRequest();
            else
                return Ok(foundedSoftware);
        }
    }
}
