using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostPerTourController : ControllerBase
    {
        private readonly conocubaContext _context;

        public CostPerTourController(conocubaContext context)
        {
            this._context = context;
        }

        // GET
        [HttpGet("/modality/cos_per_tour_id")]
        public async Task<ActionResult<CostPerTour>> GetCostPerTour(int id)
        {
            var mod = await _context.Cost_Per_ToursSet.FirstAsync(C => C.ModalityId == id);

            if (mod != null)
            {
                return Ok(mod);
            }

            return NotFound();
        }

        [HttpGet("/modality/cos_per_tour")]

        public async Task<ActionResult<List<Models.CostPerTour>>> GetCostPerTour()
        {
            var list = await _context.Cost_Per_ToursSet.ToListAsync();

            return Ok(list);
        }

        //POST
        [HttpPost("/modality/cos_per_tour")]
        public async Task<ActionResult<String>> PostCostPerTour([FromBody] CostPerTour modality)
        {
            var mod = await _context.Cost_Per_ToursSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                return NotFound("Cost per tour not found");
            }

            await _context.ModalitySet.AddAsync(modality);
            await _context.Cost_Per_ToursSet.AddAsync(modality);
            await _context.SaveChangesAsync();
            return Ok("Cost per tour inserted");
        }

        // PUT 
        [HttpPut("/modality/cos_per_tour")]
        public async Task<ActionResult<String>> PutCostPerTour([FromBody] CostPerTour modality)
        {
            var mod = await _context.Cost_Per_ToursSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                _context.Entry(mod).CurrentValues.SetValues(modality);
                await _context.SaveChangesAsync();
                return Ok("Cost Per Tour updated");
            }
            return NotFound("Cost Per Tour not found");
        }

        //DELETE
        [HttpDelete("/modality/cos_per_tour_id")]
        public async Task<ActionResult<string>> DeleteCostPerTour(int Id)
        {
            var mod = await _context.Cost_Per_ToursSet.FindAsync(Id);

            if (mod == null)
            {
                return BadRequest("Cost Per Tour not found");
            }

            _context.Cost_Per_ToursSet.Remove(mod);
            await _context.SaveChangesAsync();

            return Ok("Cost Per Tour not removed");
        }

    }
}
