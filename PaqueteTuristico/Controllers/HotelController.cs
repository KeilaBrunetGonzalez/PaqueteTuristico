using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly conocubaContext _context;
        private readonly ILogger<HotelController> logger;

        public HotelController(conocubaContext context, ILogger<HotelController> logger)
        {
            this._context = context;
            this.logger = logger;
        }

        // GET api/<ValuesController>/5
        [HttpGet("/hotels/Hotel_ID")]
        public async Task<ActionResult<Hotel>> GetHotelAsync(int HotelId)
        { 
                var h = await _context.HotelSet.FirstAsync(H => H.Id == HotelId);

                if (h != null)
                {
                    return Ok(h);
                }
          
                return NotFound();
        }


        // POST api/<ValuesController>/5
        [HttpPost("/hotels/Hotel_ID")]
        public async Task<ActionResult<String>> PostHotel([FromBody] Hotel hotel)
        {
            var existingHotel = await _context.HotelSet.FindAsync(hotel.Id);

            if (existingHotel == null)
            {
               await _context.HotelSet.AddAsync(hotel);
               await _context.SaveChangesAsync();
               
                return Ok("Hotel inserted");
            }

            return BadRequest("Hotel already found");   
        }

        // PUT api/<ValuesController>
        [HttpPut("/hotels/Hotel_ID")]
        public async Task<ActionResult<String>> PutHotel([FromBody] Hotel hotel)
        {
            var h = await _context.HotelSet.FindAsync(hotel.Id);
            if (h != null)
            {
                _context.Entry(h).CurrentValues.SetValues(hotel);
                await _context.SaveChangesAsync();
                return Ok("Hotel updated");
            }
            return NotFound("Hotel not found");
        }


        // DELETE api/<ValuesController>/5

        [HttpDelete("/hotels/Hotel_ID")]
        public async Task<ActionResult<String>> DeleteHotel(int Id)
        {
            var hotel = await _context.HotelSet.FindAsync(Id); ;

            if (hotel == null)
            {
                return NotFound("Hotel not found");
            }

             _context.HotelSet.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

    

}
