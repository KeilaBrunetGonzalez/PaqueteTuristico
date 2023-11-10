using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Service
{
    public class HotelServices
    {

        private readonly conocubaContext _context;

        public HotelServices(conocubaContext context)
        {
            this._context = context;
        }


        //POST
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
        

    }
}
