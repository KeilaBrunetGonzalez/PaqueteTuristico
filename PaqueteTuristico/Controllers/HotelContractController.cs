using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class HotelContractController : ControllerBase
    {
        private readonly HotelContractServices _services;
        public HotelContractController(HotelContractServices services)
        {
            this._services = services;
        }

        //GET
        [HttpGet("/contracts/HotelContract")]
        public async Task<ActionResult<List<HotelContract>>> GetHotelContract()
        {
            var contractList = await _services.GetHotelContractAsync();
            if (contractList.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(contractList);
        }

        //POST
        [HttpPost("/contracts/HotelContract")]
        public async Task<ActionResult<string>> CreateHotelContract([FromBody] HotelContract contract)
        {
            var insertContract = await _services.InsertHotelContractAsync(contract);

            if (insertContract)
            {
                return BadRequest("This contract exist");
            }

            return Ok("Hotel contract inserted");

        }

        //PUT
        [HttpPut("/contracts/HotelContract")]
        public async Task<ActionResult<string>> UpdateHotelContract([FromBody] HotelContract cont)
        {
            var upContract = await _services.UpdateHotelContractAsync(cont);

            if (upContract)
            {
                return Ok("Hotel contract updated");
            }
            return NotFound("Hotel contract not found");
        }

        //DELETE
        [HttpDelete("/contracts/HotelContract")]
        public async Task<ActionResult<string>> DeleteHotelContract(int Id)
        {
            var removedContract = await _services.DeleteHotelContractAsync(Id);

            if (removedContract)
            {
                return Ok("Hotel contract removed");
            }
            return NotFound("Hotel contract not found");
        }
    }
}
