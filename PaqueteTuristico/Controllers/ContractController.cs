using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractServices _services;

        public ContractController(ContractServices services)
        {
            this._services = services;
        }

        // GET
        [HttpGet("/contracts/ContactID")]
        public async Task<ActionResult<EContract>> GetContract(int id)
        {
            var contract = await _services.GetContractAsync(id);

            if (contract != null)
            {
                return Ok(contract);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
