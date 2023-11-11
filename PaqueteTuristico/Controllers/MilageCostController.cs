using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilageCostController : ControllerBase
    {
        private readonly conocubaContext _context;
        private readonly Mileage_CostServices _mileageCostServices;

        public MilageCostController(conocubaContext context, Mileage_CostServices _mileageCostServices)
        {
            this._context = context;
            this._mileageCostServices = _mileageCostServices;
        }

        // GET

        [HttpGet("/modality/milage_cost")]

        public async Task<ActionResult<List<Models.MileageCost>>> GetMileageCost()
        {
            var list = await _mileageCostServices.GetMileageCosts();

            return Ok(list);
        }

        //POST
        [HttpPost("/modality/milage_cost")]
        public async Task<ActionResult<String>> PostMilageCost([FromBody] MileageCost modality)
        {
            var mod = await _mileageCostServices.CreateMileage_Cost(modality);
            if (!mod)
            {
                return NotFound("Milage cost not found");
            }
            return Ok("Milage cost inserted");
        }

        // PUT 
        [HttpPut("/modality/milage_cost")]
        public async Task<ActionResult<String>> PutMilageCost([FromBody] MileageCost modality)
        {
            var mod = await _mileageCostServices.UpdateMileage_Cost(modality);
            if (mod)
            {
                return Ok("Milage cost updated");
            }
            return NotFound("Milage cost not found");
        }

        //DELETE
        [HttpDelete("/modality/milage_cost_id")]
        public async Task<ActionResult<string>> DeleteMilageCost(int Id)
        {
            var mod = await _mileageCostServices.DeleteMileage_Cost(Id);

            if (!mod)
            {
                return BadRequest("Milage cost not found");
            }
            return Ok("Milage cost not removed");
        }

    }
}
