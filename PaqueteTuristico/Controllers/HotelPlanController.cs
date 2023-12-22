using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;
using PaqueteTuristico.Dtos;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelPlanController : ControllerBase
    {
        private readonly ILogger<HotelPlanController> logger;
        private readonly HotelPlanServices hotelPlanServices;

        private static readonly string[] Summaries = new[]
       {
        "Alta"," Baja"
        };

        private readonly conocubaContext context;
        public HotelPlanController(ILogger<HotelPlanController> logger, conocubaContext context, HotelPlanServices hotelPlanServices)
        {
            this.context = context;
            this.logger = logger;
            this.hotelPlanServices = hotelPlanServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelPlan>>> Get() {
            return await hotelPlanServices.GetAll();
        }

            

        // GET api/<HotelPlanController>/5
        [HttpGet("/HotelPlan/Hotelplan_id")]
        public async Task<ActionResult<HotelPlan>> GetHotelPlanAsync(int HotelId, int seasonId)
        {
            var current = await hotelPlanServices.GetHotelPlanById(HotelId,seasonId);
            if (current == null)
            {
                return NotFound();

            }
            return current;
        }



        // Post api/<HotelPlanController>/5
        [HttpPost("/HotelPlan/Hotelplan_id")]
        public async Task<ActionResult<HotelPlan>> Post([FromBody] HotelplanDTO hotel)
        {
            HotelPlan hotel1 = new HotelPlan(); 
            hotel1.HotelId = hotel.HotelId;
            hotel1.SeasonId = hotel.SeasonId;
            var temp = await hotelPlanServices.CreateHotelPlan(hotel1);
            

            if (!temp)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE api/<HotelPlanController>/5

        [HttpDelete("{Hotelid}/{Seasonid}")]
        public async Task<IActionResult> Delete(int Hotelid, int Seasonid)
        {
            var current = await hotelPlanServices.DeleteHotelPlan(Hotelid, Seasonid);

            if(!current)
            {
                return BadRequest("No se pudo eliminar");
            }
            return Ok();
        }

    }
}
