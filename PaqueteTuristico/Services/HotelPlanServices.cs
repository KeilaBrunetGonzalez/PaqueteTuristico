using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class HotelPlanServices : ServiceBase
    {
        public HotelPlanServices(conocubaContext context) : base(context)
        {
        }
        public async Task<bool> CreateHotelPlan( HotelPlan hotel)
        {
            var temp = await context.HotelPlanSet.FirstOrDefaultAsync(s => s.HotelId == hotel.HotelId && s.SeasonId == hotel.SeasonId);


            if (temp != null)
            {
                return false;
            }
            try
            {
                var hoteltemp = await context.HotelSet.FirstAsync(s => s.Id == hotel.HotelId);
                var seasontemp = await context.SeasonSet.FirstAsync(s => s.SeasonId == hotel.SeasonId);
                hotel.Hotel = hoteltemp;
                hotel.Season = seasontemp;
                hoteltemp.Plans.Add(hotel);
                seasontemp.Plans.Add(hotel);
                await context.HotelPlanSet.AddAsync(hotel);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteHotelPlan(int Hotelid, int Seasonid)
        {
            var current = await context.HotelPlanSet.FirstAsync(s => s.HotelId == Hotelid && s.SeasonId == Seasonid);

            try
            {
                context.HotelPlanSet.Remove(current);

                await context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public async Task<List<HotelPlan>> GetAll()
        {
            return await context.HotelPlanSet.ToListAsync();

        }
        public async Task<HotelPlan> GetHotelPlanById(int HotelId, int seasonId)
        {
            var temp = await context.HotelPlanSet.FirstAsync(s => s.HotelId == HotelId && s.SeasonId == seasonId);
            return temp;
        }
    }
}
