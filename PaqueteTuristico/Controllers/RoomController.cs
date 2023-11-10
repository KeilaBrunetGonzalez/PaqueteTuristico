using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly conocubaContext _context;

        public RoomController(conocubaContext context)
        {
            this._context = context;
        }

        //GET
        [HttpGet("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<ActionResult<Room>> GetRoomAsync(int RoomId)
        {
            var r = await _context.RoomSet.FindAsync(RoomId);

            if (r != null)
            {
                return Ok(r);
            }

            return NotFound();
        }

        //POST

        [HttpPost("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<ActionResult<string>> PostRoom([FromBody] Room room)
        {
            var roomExists = await _context.RoomSet.AnyAsync(r => r.Id == room.Id && r.HotelId == room.HotelId);

            if (roomExists)
            {
                return BadRequest("Room with the specified Id already exists in the hotel");
            }

            var hotel = await _context.HotelSet.FindAsync(room.HotelId);

            if (hotel == null)
            {
                return NotFound("Hotel not found");
            }

            hotel.Rooms.Add(room);
            await _context.RoomSet.AddAsync(room);
            await _context.SaveChangesAsync();

            return Ok("Hotel Room created");
        }


        //PUT
        [HttpPut("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<ActionResult<string>> PutRoom([FromBody] Room room)
        {

            var roomExists = await _context.RoomSet.FirstAsync(R => R.Id == room.Id && R.HotelId == room.HotelId);

            if (roomExists != null)
            {
                _context.Entry(roomExists).CurrentValues.SetValues(room);
                await _context.SaveChangesAsync();

                return Ok("Hotel Room updated");
            }

            return NotFound("Hotel Room not found");
        }
        //DELETE
        [HttpDelete("/hotels/Hotel_ID/rooms/ROOM_ID")]
        public async Task<ActionResult<string>> DeleteRoom(int RoomId, int HotelId)
        {

                var r = await _context.RoomSet.FirstAsync(R => R.Id == RoomId && R.HotelId == HotelId);
                if (r != null)
                {
                    _context.RoomSet.Remove(r);
                    await _context.SaveChangesAsync();
                    return Ok("Hotel Room removed");
                }

            return NotFound("Hotel Room not found");
        }

    }
}
