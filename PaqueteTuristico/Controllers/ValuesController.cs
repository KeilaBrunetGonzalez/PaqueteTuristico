using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly HotelContext _context;

        public ValuesController(HotelContext context)
        {
            _context = context;
        }

        // GET api/<ValuesController>/5
        [HttpGet("HotelId")]
        public async Task<ActionResult<Hotel>> GetHotelAsync(int HotelId)
        {
            try
            {
                var list = await _context.HotelSet.ToListAsync();
                foreach (var h in list)
                {
                    if (HotelId == h.Id)
                    {
                        return Ok(h);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }


        [HttpGet("RoomId")]
        public async Task<ActionResult<Room>> GetRoomAsync(int HotelId,int RoomId)
        {
            try
            {
                var list = await _context.RoomSet.ToListAsync();
                foreach (var r in list)
                {
                    if (RoomId == r.Id && HotelId == r.HotelId)
                    {
                        return Ok(r);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }


        [HttpGet("MealId")]
        public async Task<ActionResult<Meal>> GetMealAsync(int HotelId,int MealId)
        {
            try
            {
                var list = await _context.MealSet.ToListAsync();
                foreach (var m in list)
                {
                    if (MealId == m.Id && HotelId == m.HotelId)
                    {
                        return Ok(m);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }




        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("HotelData")]
        public async Task<ActionResult> PutHotel([FromBody] Hotel Hotel)
        {
            var existingHotel = await _context.HotelSet.FindAsync(Hotel.Id);

            if (existingHotel == null)
            {
                _context.HotelSet.Add(Hotel);
            }
            else
            {
                _context.Entry(existingHotel).CurrentValues.SetValues(Hotel);
            }

            await _context.SaveChangesAsync();

            return Ok(Hotel);
        }
        // DELETE api/<ValuesController>/5

        [HttpDelete("HotelId")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.HotelSet.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            else
            {
                DeleteRooms(id);
                DeleteMeal(id);

                _context.HotelSet.Remove(hotel);
                await _context.SaveChangesAsync();
            }

            

            return NoContent();
        }

        private async void DeleteMeal(int id)
        {

            try { 
            var list = await _context.MealSet.ToListAsync();
            foreach (var m in list)
            {
                if (id == m.HotelId)
                {
                    _context.MealSet.Remove(m);
                     await _context.SaveChangesAsync();
                }
            }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                
            }

        }

        private async void DeleteRooms(int id)
        {
            try
            {
                var list = await _context.RoomSet.ToListAsync();
                foreach (var r in list)
                {
                    if (id == r.HotelId)
                    {
                        _context.RoomSet.Remove(r);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        [HttpDelete("MealId")]
        public async Task<ActionResult<Room>> DeleteMeal(int MealId, int HotelId)
        {
            try
            {
                var list = await _context.MealSet.ToListAsync();
                foreach (var m in list)
                {
                    if (MealId == m.Id && HotelId == m.HotelId)
                    {
                        _context.MealSet.Remove(m);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();

        }

        [HttpDelete("RoomId")]
        public async Task<ActionResult<Room>> DeleteRoom(int RoomId,int HotelId)
        {
            try
            {
                var list = await _context.RoomSet.ToListAsync();
                foreach (var r in list)
                {
                    if (RoomId == r.Id && HotelId == r.HotelId)
                    {
                        _context.RoomSet.Remove(r);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }


    }
}
