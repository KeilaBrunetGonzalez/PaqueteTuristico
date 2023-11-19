using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class HotelServices
    {

        private readonly conocubaContext _context;

        public HotelServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<Hotel?> GetHotelAsync(int HotelId)
        {
            var existingHotel = await _context.HotelSet.FirstAsync(H => H.Id == HotelId);
            if (existingHotel == null)
            {
                return null;

            }
            return existingHotel;
        }

        public async Task<List<Hotel>?> GetHotelsAsync()
        {
            var list = await _context.HotelSet.ToListAsync();

            return list;
        }

        //Insert
        public async Task<bool> InsertHotelAsync(Hotel hotel)
        {
            var existingHotel = await _context.HotelSet.FindAsync(hotel.Id);
            var find = false;
            if (existingHotel == null)
            {
                await _context.HotelSet.AddAsync(hotel);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        //Update
        public async Task<bool> UpdateHotelAsync(Hotel hotel)
        {
            var existingHotel = await _context.HotelSet.FindAsync(hotel.Id);
            var find = false;
            if (existingHotel != null)
            {
                _context.Entry(existingHotel).CurrentValues.SetValues(hotel);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        //Delete
        public async Task<bool> DeleteHotelAsync(int Id)
        {
            var existingHotel = await _context.HotelSet.FindAsync(Id);
            var find = false;
            if (existingHotel != null)
            {
                _context.HotelSet.Remove(existingHotel);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        public async Task<int> GetHotelCount()
        {
            var count = await _context.HotelSet.CountAsync();

            return count;
        }


    }
}
