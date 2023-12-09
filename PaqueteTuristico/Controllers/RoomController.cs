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
    public class RoomController : ControllerBase
    {
        private readonly RoomServices _services;

        public RoomController(RoomServices _services)
        {
            this._services = _services;
        }

        //GET
        [HttpGet("{roomId}")]
        public async Task<ActionResult<Room>> GetRoom(int roomId)
        {
            var room = await _services.GetRoomAsync(roomId);

            if (room != null)
            {
                return Ok(room);
            }

            return NotFound();
        }

        [HttpGet("{hotelCode}")]
        public async Task<ActionResult<List<Models.Room>>> GetRoomsByHotelId(int hotelId)
        {
            var list = await _services.GetHotelRoomsAsync(hotelId);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);

        }

        [HttpGet]

        public async Task<ActionResult<List<Models.Room>>> GetRooms()
        {
            var list = await _services.GetRoomsAsync();
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
        }


        //POST

        [HttpPost]
        public async Task<ActionResult<string>> PostRoom([FromBody] Room room)
        {
            var id = await _services.GetLastRoomIdAsync();
            room.Id = ++id;

            var option = await _services.InsertRoomAsync(room);

            if (option == 1)
            {
                return BadRequest("Room with the specified Id already exists in the hotel");
            }

            if (option == 2)
            {
                return NotFound("Hotel not found");
            }

            return Ok("Hotel Room created");
        }


        //PUT
        [HttpPut]
        public async Task<ActionResult<string>> PutRoom([FromBody] Room room)
        {

            var updated = await _services.UpdateRoomAsync(room);

            if (updated)
            {
                return Ok("Hotel Room updated");
            }

            return NotFound("Hotel Room not found");
        }

        //DELETE
        [HttpDelete("{roomId}")]
        public async Task<ActionResult<string>> DeleteRoom(int RoomId)
        {

            var removed = await _services.DeleteRoomAsync(RoomId);
            if (removed)
            {
                return Ok("Hotel Room removed");
            }

            return NotFound("Hotel Room not found");
        }



    }
}
