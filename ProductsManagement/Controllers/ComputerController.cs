using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.WebApi;
using ProductsManagementBusenssLogic.Services;
using ProductsManagementBusenssLogic.ViewModels;

namespace ProductsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public ComputerController (IComputerService computersService, JwtAuthenticationManager jwtAuthenticationManager)
        {
            _computerService = computersService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

                       
        [HttpGet]
        //[Authorize]
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
        public IActionResult SearchComputersByComputerName(string? computerName, string? ownerName, string? cpu, string? ram, string? gpu, string? hdd)
        {
            var foundComputers =  _computerService.SearchComputersByComputerName(computerName ?? String.Empty, ownerName ?? String.Empty, cpu ?? String.Empty,
                ram ?? String.Empty, gpu ?? String.Empty, hdd ?? String.Empty);

            if (foundComputers == null)
                return BadRequest();
            else
                return Ok(foundComputers);
        }

        [Route("/OwnerName")]
        [HttpGet]
        public IActionResult SearchComputersByOwnerName(string? computerName, string? ownerName, string? cpu, string? ram, string? gpu, string? hdd)
        {
            var foundComputers = _computerService.SearchComputersByOwnerName(computerName ?? String.Empty, ownerName ?? String.Empty, cpu ?? String.Empty,
                ram ?? String.Empty, gpu ?? String.Empty, hdd ?? String.Empty);

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

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = _jwtAuthenticationManager.Authenticate(usr.username, usr.password);

            if(token == null)
            {
                return Unauthorized();
            }

            return Ok(token); 
        }
    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }    
    }
}
