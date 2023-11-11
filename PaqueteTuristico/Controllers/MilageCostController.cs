using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilageCostController : ControllerBase
    {
        private readonly conocubaContext _context;

        public MilageCostController(conocubaContext context)
        {
            this._context = context;
        }

        // GET

        [HttpGet("/modality/milage_cost")]

        public async Task<ActionResult<List<Models.MileageCost>>> GetMileageCost()
        {
            var list = await _context.Mileage_CostsSet.ToListAsync();

            return Ok(list);
        }

        //POST
        [HttpPost("/modality/milage_cost")]
        public async Task<ActionResult<String>> PostMilageCost([FromBody] MileageCost modality)
        {
            var mod = await _context.Mileage_CostsSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                return NotFound("Milage cost not found");
            }

            await _context.ModalitySet.AddAsync(modality);
            await _context.Mileage_CostsSet.AddAsync(modality);
            await _context.SaveChangesAsync();
            return Ok("Milage cost inserted");
        }

        // PUT 
        [HttpPut("/modality/milage_cost")]
        public async Task<ActionResult<String>> PutMilageCost([FromBody] MileageCost modality)
        {
            var mod = await _context.Mileage_CostsSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                _context.Entry(mod).CurrentValues.SetValues(modality);
                await _context.SaveChangesAsync();
                return Ok("Milage cost updated");
            }
            return NotFound("Milage cost not found");
        }

        //DELETE
        [HttpDelete("/modality/milage_cost_id")]
        public async Task<ActionResult<string>> DeleteMilageCost(int Id)
        {
            var mod = await _context.Mileage_CostsSet.FindAsync(Id);

            if (mod == null)
            {
                return BadRequest("Milage cost not found");
            }

            _context.Mileage_CostsSet.Remove(mod);
            await _context.SaveChangesAsync();

            return Ok("Milage cost not removed");
        }

    }
}
