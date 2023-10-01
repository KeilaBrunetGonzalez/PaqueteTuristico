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
        [HttpGet("GetHotel")]
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


        [HttpGet("GetRoom")]
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


        [HttpGet("GetMeal")]
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
        [HttpPost("HotelPost")]
        public async Task<IActionResult> PostHotel(int Id, string Name, string Desc, int Price)
        {
            var existingHotel = await _context.HotelSet.FindAsync(Id);
            if (existingHotel != null)
            {
                if(Name != null)
                {
                    existingHotel.Name = Name;
                }
                if(Desc != null)
                {
                    existingHotel.Description = Desc;
                }
                if (Price != 0)
                {
                    existingHotel.Price = Price;
                }
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("RoomPost")]
        public async Task<IActionResult> PostRoom(int HotelId, int RoomId, string Name, string Desc, int Price)
        {
            try
            {
                var list = await _context.RoomSet.ToListAsync();
                foreach (var r in list)
                {
                    if (RoomId == r.Id && HotelId == r.HotelId)
                    {
                        if (Name != null)
                        {
                            r.Name = Name;
                        }
                        if (Desc != null)
                        {
                            r.Description = Desc;
                        }
                        if (Price != 0)
                        {
                            r.Price = Price;
                        }
                        return Ok();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }

        [HttpPost("MealPost")]
        public async Task<IActionResult> PostMeal(int HotelId, int MealId, string Name, string Desc, int Price)
        {
            try
            {
                var list = await _context.MealSet.ToListAsync();
                foreach (var m in list)
                {
                    if (MealId == m.Id && HotelId == m.HotelId)
                    {
                        if (Name != null)
                        {
                            m.Name = Name;
                        }
                        if (Desc != null)
                        {
                            m.Description = Desc;
                        }
                        if (Price != 0)
                        {
                            m.Price = Price;
                        }
                        return Ok();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound();
        }


        // PUT api/<ValuesController>/5
        [HttpPut("PutHotel")]
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
                catch (ArgumentNullException ex)
                {
                    return BadRequest(ex.Message);

                }



            }

            return Ok();
        }

        [HttpPut("PutRoom")]
        public async Task<ActionResult<Room>> PutRoom(int Id, string Name, string Desc, int Price,int HotelId)
        {
            var existingRoom = await _context.MealSet.FindAsync(Id);

            if (existingRoom == null)
            {
                if (FindHotel(HotelId))
                {
                    var r = new Room
                    {
                        Id = Id,
                        Name = Name,
                        Description = Desc,
                        Price = Price,
                        HotelId = HotelId,
                    };
                    try
                    {
                        await _context.RoomSet.AddAsync(r);
                        await _context.SaveChangesAsync();
                    }
                    catch (ArgumentNullException ex)
                    {
                        return BadRequest(ex.Message);

                    }
                }

            }

            return Ok();
        }

        [HttpPut("PutMeal")]
        public async Task<ActionResult<Meal>> PutMeal(int Id, string Name, string Desc, int Price, int HotelId)
        {
            var existingMeal = await _context.MealSet.FindAsync(Id);

            if (existingMeal == null)
            {
                if (FindHotel(HotelId))
                {
                    var m = new Meal
                    {
                        Id = Id,
                        Name = Name,
                        Description = Desc,
                        Price = Price,
                        HotelId = HotelId,
                    };
                    try
                    {
                        await _context.MealSet.AddAsync(m);
                        await _context.SaveChangesAsync();
                    }
                    catch (ArgumentNullException ex)
                    {
                        return BadRequest(ex.Message);

                    }
                }

            }

            return Ok();
        }
        // DELETE api/<ValuesController>/5

        [HttpDelete("DeleteHotel")]
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

                await _context.SaveChangesAsync();

                _context.HotelSet.Remove(hotel);
                await _context.SaveChangesAsync();
            }

            

            return NoContent();
        }

        private  void DeleteMeal(int id)
        {

            try { 
            var list =  _context.MealSet.ToList();
            foreach (var m in list)
            {
                if (id == m.HotelId)
                {
                    _context.MealSet.Remove(m);
                }
            }
            }
            catch (ArgumentNullException ex)
            {
                BadRequest(ex.Message);

            }

        }

        private void DeleteRooms(int id)
        {
            try
            {
                var list =  _context.RoomSet.ToList();
                foreach (var r in list)
                {
                    if (id == r.HotelId)
                    {
                        _context.RoomSet.Remove(r);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                BadRequest(ex.Message);

            }
        }

        [HttpDelete("DeleteMeal")]
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

        [HttpDelete("DeleteRoom")]
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

        private bool FindHotel(int HotelId)
        { 

            var list =  _context.HotelSet.ToList();
            foreach (var h in list)
            {
                if (HotelId == h.Id)
                {
                    return true;
                }
                else { 
                }
            }
            return false;
        }


    }

    

}
