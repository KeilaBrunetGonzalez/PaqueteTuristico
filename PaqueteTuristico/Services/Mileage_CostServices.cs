using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class Mileage_CostServices : ServiceBase
    {
        public Mileage_CostServices(conocubaContext context) : base(context)
        {
        }
        public async Task<bool> CreateMileage_Cost(MileageCost modality)
        {
            var mod = await context.Mileage_CostsSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                return false;
            }
            await context.ModalitySet.AddAsync(modality);
            await context.Mileage_CostsSet.AddAsync(modality);
            await context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateMileage_Cost(MileageCost modality)
        {
            var mod = await context.Mileage_CostsSet.FindAsync(modality.ModalityId);
            if (mod != null)
            {
                context.Entry(mod).CurrentValues.SetValues(modality);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteMileage_Cost(int Id)
        {
            var mod = await context.Mileage_CostsSet.FindAsync(Id);

            if (mod == null)
            {
                return false;
            }

            context.Mileage_CostsSet.Remove(mod);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<MileageCost>> GetMileageCosts()
        {
            var list = await context.Mileage_CostsSet.ToListAsync();
            return list;
        }
        
    }
}
