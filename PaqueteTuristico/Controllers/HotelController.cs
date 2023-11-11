using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelServices _services;

        public HotelController(HotelServices _services)
        {
            this._services = _services;
        }


        // GET 
        [HttpGet("/hotels/Hotel_ID")]
        public async Task<ActionResult<Hotel>> GetHotelAsync(int HotelId)
        {
                var hotel = await _services.GetHotelAsync(HotelId);

                if (hotel != null)
                {
                    return Ok(hotel);
                }
          
                return NotFound();
        }

        [HttpGet("/hotels")]

        public async Task<ActionResult<List<Models.Hotel>>> GetHotelsByHotelId()
        {
            var list = await _services.GetHotelsAsync();
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
        }


        // POST 
        [HttpPost("/hotels/Hotel_ID")]
        public async Task<ActionResult<String>> PostHotel([FromBody] Hotel hotel)
        {
            var inserted = await _services.InsertHotelAsync(hotel);

            if (inserted)
            {
                return Ok("Hotel inserted");
            }

            return BadRequest("Hotel already exist");   
        }

        // PUT 
        [HttpPut("/hotels/Hotel_ID")]
        public async Task<ActionResult<String>> PutHotel([FromBody] Hotel hotel)
        {
            var updated = await _services.UpdateHotelAsync(hotel);

            if (updated)
            {
                return Ok("Hotel updated");
            }
            return NotFound("Hotel not found");
        }


        // DELETE 

        [HttpDelete("/hotels/Hotel_ID")]
        public async Task<ActionResult<String>> DeleteHotel(int Id)
        {
            var removed = await _services.DeleteHotelAsync(Id);

            if (removed)
            {
                return Ok("Hotel removed");
            }
            return NotFound("Hotel not found");
        }

    }

    

}
