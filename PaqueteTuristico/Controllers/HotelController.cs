using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System.Reflection.Metadata;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelContext _context;
        private readonly ILogger<HotelController> logger;

        public HotelController(HotelContext context, ILogger<HotelController> logger)
        {
            this._context = context;
            this.logger = logger;
        }

        // GET api/<ValuesController>/5
        [HttpGet("/hotels/Hotel_ID")]
        public async Task<ActionResult<Hotel>> GetHotelAsync(int HotelId)
        {
            try
            {
                var h = await _context.HotelSet.FirstAsync(H =>  H.Id == HotelId);
   
                if(h != null) {
                    return Ok(h);
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }


        [HttpGet("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<ActionResult<Room>> GetRoomAsync(int HotelId,int RoomId)
        {
            try
            {
                var r = await _context.RoomSet.FirstAsync(R => R.Id == RoomId && R.HotelId == HotelId);

                if (r != null)
                {
                    return Ok(r);
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }


        [HttpGet("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<ActionResult<Meal>> GetMealAsync(int HotelId,int MealId)
        {
            try
            {
                var m = await _context.MealSet.FirstAsync(M => M.Id == MealId && M.HotelId == HotelId);
                if(m != null)
                {
                    return Ok(m);
                }
               
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }




        // POST api/<ValuesController>
        [HttpPost("/hotels/Hotel_ID")]
        public async Task<IActionResult> PostHotel(int Id, string Name, string Desc, int Price)
        {
            var h = await _context.HotelSet.FindAsync(Id);
            if (h != null)
            {
                if(Name != h.Name)
                {
                    h.Name = Name;
                }
                if(Desc != h.Description)
                {
                    h.Description = Desc;
                }
                if (Price != h.Price)
                {
                    h.Price = Price;
                }

                return Ok();
            }


            return NotFound();
        }

        [HttpPost("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<IActionResult> PostRoom(int HotelId, int RoomId, string Name, string Desc, int Price)
        {

                var r = await _context.RoomSet.FindAsync(RoomId,HotelId);

                if (r != null)
                {
                    if (Name != r.Name)
                    {
                        r.Name = Name;
                    }
                    if (Desc != r.Description)
                    {
                        r.Description = Desc;
                    }
                    if (Price != r.Price)
                    {
                        r.Price = Price;
                    }
                    return Ok();
                }

            return NotFound();
        }

        [HttpPost("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<IActionResult> PostMeal(int HotelId, int MealId, string Name, string Desc, int Price)
        {
            var m = await _context.MealSet.FindAsync(MealId, HotelId);

            if (m != null)
            {
                if (Name != m.Name)
                {
                    m.Name = Name;
                }
                if (Desc != m.Description)
                {
                    m.Description = Desc;
                }
                if (Price != m.Price)
                {
                    m.Price = Price;
                }
                return Ok();
            }

            return NotFound();
        }


        // PUT api/<ValuesController>/5
        [HttpPut("/hotels/Hotel_ID")]
        public async Task<ActionResult<Hotel>> PutHotel(int Id,string Name,string Desc,int Price)
        {
            var existingHotel = await _context.HotelSet.FindAsync(Id);

            if (existingHotel == null)
            {
                var h = new Hotel
                {
                    Id = Id,
                    Name = Name,
                    Description = Desc,
                    Price = Price,
                };
                try
                {
                    await _context.HotelSet.AddAsync(h);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }

            }

            return Ok();
        }

        [HttpPut("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<ActionResult<Room>> PutRoom(int Id, string Name, string Desc, int Price,int HotelId)
        {
            var existingRoom = await _context.RoomSet.FindAsync(Id);

            if (existingRoom == null)
            {
                var hotel = await _context.HotelSet.FindAsync(HotelId);
                if (hotel == null)
                {
                    return NotFound("Hotel not found");

                }

                var newRoom = new Room
                {
                    Id = Id,
                    Name = Name,
                    Description = Desc,
                    Price = Price,
                };
                    
                try
                {
                    hotel.Rooms.Add(newRoom);
                    await _context.RoomSet.AddAsync(newRoom);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                  return BadRequest(ex.Message);

                }
            }
            return Ok();
        }

        [HttpPut("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<ActionResult<Meal>> PutMeal(int Id, string Name, string Desc, int Price, int HotelId)
        {
            var existingMeal = await _context.MealSet.FindAsync(Id);

            if (existingMeal == null)
            {
                var hotel = await _context.HotelSet.FindAsync(HotelId);
                if (hotel == null)
                {
                    return NotFound("Hotel not found");

                }
                var newMeal = new Meal
                {
                    Id = Id,
                    Name = Name,
                    Description = Desc,
                    Price = Price,
                };
                try
                {
                    hotel.Meals.Add(newMeal);
                    await _context.MealSet.AddAsync(newMeal);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }

            }

            return Ok();
        }
        // DELETE api/<ValuesController>/5

        [HttpDelete("/hotels/Hotel_ID")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = _context.HotelSet.Include(H => H.Rooms).Include(M => M.Meals).Single(H => H.Id == id);

            if (hotel == null)
            {
                return NotFound();
            }
            else
            {
                _context.HotelSet.Remove(hotel);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<ActionResult<Meal>> DeleteMeal(int MealId, int HotelId)
        {
            try
            {
                var m = await _context.MealSet.FirstAsync(M => M.Id == MealId && M.HotelId == HotelId);

                if (m != null)
                {
                    _context.MealSet.Remove(m);
                    await _context.SaveChangesAsync();
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();

        }

        [HttpDelete("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<ActionResult<Room>> DeleteRoom(int RoomId,int HotelId)
        {
            try
            {
                var r = await _context.RoomSet.FirstAsync(R => R.Id == RoomId && R.HotelId == HotelId);
                if(r != null)
                {
                    _context.RoomSet.Remove(r);
                    await _context.SaveChangesAsync();
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
