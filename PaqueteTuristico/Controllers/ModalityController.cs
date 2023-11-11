using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalityController : ControllerBase
    {
        private readonly conocubaContext _context;

        public ModalityController(conocubaContext context)
        {
            this._context = context;
        }

        // GET
        [HttpGet("/modalities/modality_id")]
        public async Task<ActionResult<Modality>> GetModality(int id)
        {
            var modality = await _context.ModalitySet.FirstAsync(c => c.ModalityId == id);

            if (modality == null)
            {
                return NotFound();
            }

            return Ok(modality);
        }
    }
}
