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
    public class CostPerTourController : ControllerBase
    {
        
        private readonly Cost_per_tourServices _services;

        public CostPerTourController(Cost_per_tourServices _services)
        {
            
            this._services = _services;
        }

        // GET

        [HttpGet()]

        public async Task<ActionResult<List<Models.CostPerTour>>> GetCostPerTour()
        {
            var list = await _services.GetPerTours();

            return Ok(list);
        }

        //POST
        [HttpPost()]
        public async Task<ActionResult<String>> PostCostPerTour([FromBody] CostPerTour modality)
        {
            //Funcion para coger el ultimo id
            var id = await  _services.GetLastModalityIdAsync();
            modality.ModalityId = ++id;

            var mod = await _services.CreateCostperTour(modality);
            if (!mod)
            {
                return NotFound("Cost per tour not found");
            }
            return Ok("Cost per tour inserted");
        }

        // PUT 
        [HttpPut()]
        public async Task<ActionResult<String>> PutCostPerTour([FromBody] CostPerTour modality)
        {
            var mod = await _services.UpdateCostPerTour(modality);
            if (mod)
            {
                return Ok("Cost Per Tour updated");
            }
            return NotFound("Cost Per Tour not found");
        }

        //DELETE
        [HttpDelete("{Id}")]
        public async Task<ActionResult<string>> DeleteCostPerTour(int Id)
        {
            var mod = await _services.DeleteCostPerTour(Id);

            if (!mod)
            {
                return BadRequest("Cost Per Tour not found");
            }
            return Ok("Cost Per Tour not removed");
        }

    }
}
