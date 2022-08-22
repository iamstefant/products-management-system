using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsManagementBusenssLogic.Services;
using ProductsManagementBusenssLogic.ViewModels;

namespace ProductsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController (IComputerService computersService)
        {
            _computerService = computersService;
        }

               
        [HttpGet]
        public async Task<IActionResult> GetAllComputers()
        {
            var InstalledComputers = _computerService.GetComputers();
            return Ok(InstalledComputers);
        }

        [Route("/GetById")]
        [HttpGet]
        public async Task<IActionResult> GetSpecificComputerById(int id)
        {
            var computer = _computerService.GetComputerById(id);

            if (computer == null)
                return NotFound();
            else
                return Ok(computer);
        }

        [Route("/GetByName")]
        [HttpGet]
        public IActionResult SearchComputersByComputerName(string? name)
        {
            var foundComputers =  _computerService.SearchComputersByComputerName(name ?? String.Empty);

            if (foundComputers == null)
                return BadRequest();
            else
                return Ok(foundComputers);
        }

        [Route("/OwnerName")]
        [HttpGet]
        public IActionResult SearchComputersByOwnerName(string? name)
        {
            var foundComputers = _computerService.SearchComputersByOwnerName(name ?? String.Empty);

            if (foundComputers == null)
                return BadRequest();
            else
                return Ok(foundComputers);
        }

        [Route("/SoftwareForPc")]
        [HttpGet]
        public async Task<IActionResult> GetComputerDetails(int id)
        {
            var computerDetails =  _computerService.GetComputerDetails(id);

            if (computerDetails == null)
                return BadRequest();
            else
                return Ok(computerDetails);
        }

    }
}
