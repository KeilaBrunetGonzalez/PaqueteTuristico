using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class Cost_per_tourServices : ServiceBase
    {
        public Cost_per_tourServices(conocubaContext context) : base(context)
        {
        }
        public async Task<bool> CreateCostperTour(CostPerTour modality)
        {
            var mod = await context.Cost_Per_ToursSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                return false;
            }

            await context.ModalitySet.AddAsync(modality);
            await context.Cost_Per_ToursSet.AddAsync(modality);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCostPerTour(CostPerTour modality)
        {

            var mod = await context.Cost_Per_ToursSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                context.Entry(mod).CurrentValues.SetValues(modality);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteCostPerTour(int Id)
        {
            var mod = await context.Cost_Per_ToursSet.FindAsync(Id);

            if (mod == null)
            {
                return false;
            }

            context.Cost_Per_ToursSet.Remove(mod);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<CostPerTour>> GetPerTours()
        {
            var list = await context.Cost_Per_ToursSet.ToListAsync();
            return list;
        }
        
    }
}
