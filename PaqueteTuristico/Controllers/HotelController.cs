﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
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
        [HttpGet("{HotelId}")]
        public async Task<ActionResult<Hotel>> GetHotelAsync(int HotelId)
        {
                var hotel = await _services.GetHotelAsync(HotelId);

                if (hotel != null)
                {
                    return Ok(hotel);
                }
          
                return NotFound();
        }
        [Authorize]
        [HttpGet("Province/{ProvinceId}/{startDate}/{endDate}/{countP}")]
        public async Task<ActionResult<List<Hotel>>> GetHotelByProvinceId(int ProvinceId, DateTime startDate, DateTime endDate, int countP)
        {
            var list = await _services.GetProvinceActiveHotelAsync(ProvinceId,startDate, endDate,countP);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
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
            hotel.HotelId = ++id;

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

        [HttpDelete("{HotelId}")]
        public async Task<ActionResult<String>> DeleteHotel(int HotelId)
        {
            var removed = await _services.DeleteHotelAsync(HotelId);

            if (removed)
            {
                return Ok("Hotel removed");
            }
            return NotFound("Hotel not found");
        }

        

        [HttpPatch("{HotelId}/{enabled}")]
        public async Task<ActionResult<String>> PatchEnabled(int HotelId, bool enabled)
        {
            var updated = await _services.UpdateEnabledAsync(HotelId, enabled);

            if (updated)
            {
                return Ok("Hotel updated");
            }
            return NotFound("Hotel not found");
        }

        /*[HttpGet]
        public IActionResult GetHotels()
        {
            var hotel = _services.GetAllHotels();

            if (hotel != null)
            {
                return Ok(hotel);
            }

            return NotFound();
        }*/
    }

    

}
