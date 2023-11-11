using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelPlanController : ControllerBase
    {
        private readonly ILogger<HotelPlanController> logger;

        private static readonly string[] Summaries = new[]
       {
        "Alta"," Baja"
        };

        private readonly conocubaContext context;
        public HotelPlanController(ILogger<HotelPlanController> logger, conocubaContext context)
        {
            this.context = context;
            this.logger = logger;
        }


        // GET api/<HotelPlanController>/5
        [HttpGet("/HotelPlan/Hotelplan_id")]
        public async Task<ActionResult<HotelPlan>> GetHotelPlanAsync(int HotelId, int seasonId)
        {
            var current = await context.HotelPlanSet.FirstAsync(s => s.HotelId == HotelId && s.SeasonId == seasonId);
            if (current == null)
            {
                return NotFound();

            }
            return current;
        }



        // PUT api/<HotelPlanController>/5
        [HttpPut("/HotelPlan/Hotelplan_id")]
        public async Task<ActionResult<HotelPlan>> Put(HotelPlan hotel)
        {
            var temp = await context.HotelPlanSet.FirstAsync(s => s.HotelId == hotel.HotelId &&  s.SeasonId == hotel.SeasonId);
            

            if (temp == null)
            {
                return BadRequest();
            }
            try
            {
                await context.HotelPlanSet.AddAsync(hotel);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Ok();
        }

        // DELETE api/<HotelPlanController>/5

        [HttpDelete("/HotelPlan/Hotelplan_id")]
        public async Task<IActionResult> Delete(int Hotelid, int Seasonid)
        {
            var current = await context.HotelPlanSet.FirstAsync(s => s.HotelId == Hotelid && s.SeasonId == Seasonid);

            try
            {
                context.HotelPlanSet.Remove(current);

                await context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                ex.ToString();
                return NotFound();
            }
            return Ok();
        }

    }
}
