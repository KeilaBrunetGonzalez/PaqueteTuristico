using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly conocubaContext _context;

        public ContractController(conocubaContext context)
        {
            this._context = context;
        }

        // GET
        [HttpGet("/contracts/{ContactID}")]
        public async Task<ActionResult<EContract>> GetContract(int id)
        {
            var contract = await _context.EContractSet.FirstAsync(c => c.Id == id);

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
