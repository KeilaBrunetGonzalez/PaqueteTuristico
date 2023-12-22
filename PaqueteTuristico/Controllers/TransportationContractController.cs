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
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationContractController : ControllerBase
    {
        private readonly TransportationContractServices _services;
        public TransportationContractController(TransportationContractServices services)
        {
            this._services = services;
        }

        // GET 

        [HttpGet("/contracts/transportationContract")]

        public async Task<ActionResult<List<TransportationContract>>> GetTransContract()
        {
            var contractList = await _services.GetTransportationContractAsync();
            if (contractList.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(contractList);
        }



        // POST 

        [HttpPost("/contracts/transportationContract")]
        public async Task<ActionResult<string>> CreateTransportationContract([FromBody] TransportationContract contract)
        {
            var insertContract = await _services.InsertTransportationContractAsync(contract);

            if (insertContract)
            {
                return BadRequest("This contract exist");
            }

            return Ok("Transportation contract inserted");
        }

        //PUT

        [HttpPut("/contracts/transportationContract")]
         public async Task<ActionResult<string>> UpdateTranaportationContract([FromBody] TransportationContract cont)
        {
            var upContract = await _services.UpdateTransportationContractAsync(cont);

            if (upContract)
            {
                return Ok("Transportation contract updated");
            }
            return NotFound("Transportation contract not found");
        }


        //DELETE

        [HttpDelete("/contracts/transportationContract")]
        public async Task<ActionResult<string>> DeleteTransportationContract(int Id)
        {
            var removedContract = await _services.DeleteTransportationContractAsync(Id);

            if (removedContract)
            {
                return Ok("Transportation contract removed");
            }
            return NotFound("Transportation contract not found");
        }

    }
}
