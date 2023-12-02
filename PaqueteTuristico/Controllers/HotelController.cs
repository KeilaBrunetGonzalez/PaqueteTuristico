using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelAsync(int HotelId)
        {
                var hotel = await _services.GetHotelAsync(HotelId);

                if (hotel != null)
                {
                    return Ok(hotel);
                }
          
                return NotFound();
        }


        // DELETE: api/<Hotel>
        [HttpGet]

        public async Task<ActionResult<List<Models.Hotel>>> GetHotelsByHotelId()
        {
            var list = await _services.GetHotelsAsync();
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
        }


        // POST : api/<Hotel>
        [HttpPost]
        public async Task<ActionResult<String>> PostHotel([FromBody] Hotel hotel)
        {
            var id = await _services.GetLastHotelIdAsync();
            hotel.Id = ++id;

            var inserted = await _services.InsertHotelAsync(hotel);

            if (inserted)
            {
                return Ok("Hotel inserted");
            }

            return BadRequest("Hotel already exist");   
        }

        // PUT: api/<Hotel>
        [HttpPut]
        public async Task<ActionResult<String>> PutHotel([FromBody] Hotel hotel)
        {
            var updated = await _services.UpdateHotelAsync(hotel);

            if (updated)
            {
                return Ok("Hotel updated");
            }
            return NotFound("Hotel not found");
        }


        // DELETE: api/Hotel

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteHotel(int Id)
        {
            var removed = await _services.DeleteHotelAsync(Id);

            if (removed)
            {
                return Ok("Hotel removed");
            }
            return NotFound("Hotel not found");
        }

        

        [HttpPatch("{id}/{enabled}")]
        public async Task<ActionResult<String>> PatchEnabled(int id, bool enabled)
        {
            var updated = await _services.UpdateEnabledAsync(id, enabled);

            if (updated)
            {
                return Ok("Hotel updated");
            }
            return NotFound("Hotel not found");
        }
        
    }

    

}
