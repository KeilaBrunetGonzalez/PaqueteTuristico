using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ComplementaryContractController : ControllerBase
    {
        private readonly ComplementaryContractServices _services;

        public ComplementaryContractController(ComplementaryContractServices services)
        {
            this._services = services;
        }
        //GET
        [HttpGet("/contracts/complementaryContract")]
        public async Task<ActionResult<List<ComplementaryContract>>> GetCompContract()
        {
            var contractList = await _services.GetComplementaryContractsAsync();
            if (contractList.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(contractList);
        }

        //POST
        [HttpPost("/contracts/complementaryContract")]
        public async Task<ActionResult<string>> CreateComplementaryContract([FromBody] ComplementaryContract contract)
        {
            var insertContract = await _services.InsertComplementaryContractAsync(contract);

            if (insertContract)
            {
                return BadRequest("This contract exist");
            }

            return Ok("Complementary contract inserted");

        }

        //PUT
        [HttpPut("/contracts/complementaryContract")]

        public async Task<ActionResult<string>> UpdateComplementaryContract([FromBody] ComplementaryContract cont)
        {
            var upContract = await _services.UpdateComplementaryContractAsync(cont);

            if (upContract)
            {
                return Ok("Complementary contract updated");
            }
            return NotFound("Complementary contract not found");
        }

        //Delete
        [HttpDelete("/contracts/complementaryContract")]

        public async Task<ActionResult<string>> DeleteComplementaryContract(int Id)
        {
            var removedContract = await _services.DeleteComplementaryContractAsync(Id);

            if (removedContract)
            {
                return Ok("Complementary contract removed");
            }
            return NotFound("Complementary contract not found");
        }

    }
}
