using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class Cost_per_hourServicescs : ServiceBase
    {
        public Cost_per_hourServicescs(conocubaContext context) : base(context)
        {
        }
        public async Task<bool> CreateCostperhour(CostPerHour modality)
        {
            var mod = await context.HotelSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                return false;
            }

            await context.ModalitySet.AddAsync(modality);
            await context.Cost_Per_HoursSet.AddAsync(modality);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCostPerHour(CostPerHour modality)
        {
            var mod = await context.Cost_Per_HoursSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                context.Entry(mod).CurrentValues.SetValues(modality);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteCostPerHour(int Id)
        {

            var mod = await context.Cost_Per_HoursSet.FindAsync(Id);

            if (mod == null)
            {
                return false;
            }

            context.Cost_Per_HoursSet.Remove(mod);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CostPerHour>> GetCostPerHours()
        {
            var list = await context.Cost_Per_HoursSet.ToListAsync();
            return list;
        }
    }
}
