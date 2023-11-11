using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;


namespace PaqueteTuristico.Services
{
    public class RoomServices
    {
        private readonly conocubaContext _context;

        public RoomServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<Room?> GetRoomAsync(int roomCode)
        {
            var existingRoom = await _context.RoomSet.FindAsync(roomCode);
            if (existingRoom == null)
            {
                return null;

            }
            return existingRoom;
        }

        public async Task<List<Room>?> GetRoomsAsync(int hotelCode)
        {
            var list = await _context.RoomSet
            .Where(H => H.HotelId == hotelCode)
            .ToListAsync();

            return list;
        }

        //Insert
        public async Task<int> InsertRoomAsync(Room room)
        {
            var roomExists = await _context.RoomSet.AnyAsync(r => r.Id == room.Id && r.HotelId == room.HotelId);

            if (roomExists)
            {
                return 1;  
            }

            var hotel = await _context.HotelSet.FindAsync(room.HotelId);

            if (hotel == null)
            {
                return 2; 
            }

            hotel.Rooms.Add(room);
            await _context.RoomSet.AddAsync(room);
            await _context.SaveChangesAsync();

            return 0;
        }

        //Update
        public async Task<bool> UpdateRoomAsync(Room room)
        {
            var existingRoom = await _context.RoomSet.FirstAsync(R => R.Id == room.Id && R.HotelId == room.HotelId);
            var find = false;
            if (existingRoom != null)
            {
                _context.Entry(existingRoom).CurrentValues.SetValues(room);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }


        //Delete
        public async Task<bool> DeleteRoomAsync(int RoomId)
        {
            var existingRoom = await _context.RoomSet.FirstAsync(R => R.Id == RoomId);
            var find = false;
            if (existingRoom != null)
            {
                _context.RoomSet.Remove(existingRoom);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }
    }
}
