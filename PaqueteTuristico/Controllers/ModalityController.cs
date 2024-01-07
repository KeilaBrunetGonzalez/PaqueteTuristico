using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ModalityController : ControllerBase
    {
       
        private readonly ModalityServices _services;

        public ModalityController(ModalityServices services)
        {
            
            this._services = services;
        }

        // GET
        [HttpGet()]
        public async Task<ActionResult<Modality>> GetModality(int id)
        {
            var modality = await _services.GetModalityById(id);

            if (modality == null)
            {
                return NotFound();
            }

            return Ok(modality);
        }
        [Authorize]
        [HttpGet("Vehicleid/{vehicleid}")]
        public async Task<ActionResult<List<Modality>>> ModalitiesbyVehicleid( int vehicleid)
        {
            var list = await _services.GetModalitiesByVehicleId(vehicleid);
            if (!list.Any())
            {
                return NotFound();
            }
            return Ok(list);
        }
    }
}
