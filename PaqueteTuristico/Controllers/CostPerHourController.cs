using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System.Diagnostics.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostPerHourController : ControllerBase
    {
        private readonly conocubaContext _context;

        public CostPerHourController(conocubaContext context)
        {
            this._context = context;
        }

        // GET

        [HttpGet("/modality/cos_per_hour")]

        public async Task<ActionResult<List<Models.CostPerHour>>> GetCostPerHour()
        {
            var list = await _context.Cost_Per_HoursSet.ToListAsync();

            return Ok(list);
        }

        //POST
        [HttpPost("/modality/cos_per_hour")]
        public async Task<ActionResult<String>> PostCostPerHour([FromBody] CostPerHour modality)
        {
            var mod = await _context.HotelSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                return NotFound("Cost per hour not found");
            }

            await _context.ModalitySet.AddAsync(modality);
            await _context.Cost_Per_HoursSet.AddAsync(modality);
            await _context.SaveChangesAsync();
            return Ok("Cost per hour inserted");
        }

        // PUT 
        [HttpPut("/modality/cos_per_hour")]
        public async Task<ActionResult<String>> PtCostPerHour([FromBody] CostPerHour modality)
        {
            var mod = await _context.Cost_Per_HoursSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                _context.Entry(mod).CurrentValues.SetValues(modality);
                await _context.SaveChangesAsync();
                return Ok("Cost Per Hour updated");
            }
            return NotFound("Cost Per Hour not found");
        }

        //DELETE
        [HttpDelete("/modality/cos_per_hour_id")]
        public async Task<ActionResult<string>> DeleteCostPerHour(int Id)
        {
            var mod = await _context.Cost_Per_HoursSet.FindAsync(Id);

            if (mod == null)
            {
                return BadRequest("Cost Per Hour not found");
            }

            _context.Cost_Per_HoursSet.Remove(mod);
            await _context.SaveChangesAsync();

            return Ok("Cost Per Hour not removed");
        }


    }
}
