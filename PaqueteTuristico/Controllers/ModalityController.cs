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
    public class ModalityController : ControllerBase
    {
        private readonly conocubaContext _context;
        private readonly ModalityServices _services;

        public ModalityController(conocubaContext context , ModalityServices services)
        {
            this._context = context;
            this._services = services;
        }

        // GET
        [HttpGet("/modalities/modality_id")]
        public async Task<ActionResult<Modality>> GetModality(int id)
        {
            var modality = await _services.GetModalityById(id);

            if (modality == null)
            {
                return NotFound();
            }

            return Ok(modality);
        }
    }
}
