using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class DayliActivityServices
    {
        private readonly conocubaContext context;
        public DayliActivityServices(conocubaContext context)
        {
            this.context = context;
        }
        public async Task<bool> CreateDayliActivitie(DayliActivities activitie)
        {
            try { 
            await context.DayliActivitieSet.AddAsync(activitie);
            await context.SaveChangesAsync();
            } catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public async Task<bool> DeletedayliActivities( int id)
        {
            try
            {
                var temp = await context.DayliActivitieSet.FirstAsync(d => d.ActivityId == id);
                context.DayliActivitieSet.Remove(temp);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public async Task<bool> UpdateDayliActivities(DayliActivities dayli)
        {
            var current = await context.DayliActivitieSet.FirstAsync(s => s.ActivityId == dayli.ActivityId);

            if (current == null)
            {
                return false;
            }
            else
            {
                if (current.Price != dayli.Price)
                {
                    current.Price = dayli.Price;
                }
                if (current.Description != dayli.Description)
                {
                    current.Description = dayli.Description;
                }
                if (current.Day != dayli.Day)
                {
                    current.Day = dayli.Day;
                }
              
                context.DayliActivitieSet.Update(current);
                await context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<List<DayliActivities>> GetAll()
        {
            return  await context.DayliActivitieSet.ToListAsync();
        }

        public async Task<DayliActivities> GetDayliActivitieById(int id)
        {
            DayliActivities dayli = await context.DayliActivitieSet.FirstAsync();
            return dayli;
        }

        public async Task<List<DayliActivities>?> GetProvinceActivitiesAsync(int ProvinceId)
        {
            var list = await context.DayliActivitieSet
            .Where(V => V.ProvinceId == ProvinceId)
            .ToListAsync();

            return list;
        }


        public IQueryable<DayliActivitiesDTO>? GetAllActivities()
        {
            var activities = from DayliActivities in context.DayliActivitieSet
                         join Province in context.ProvinceSet on DayliActivities.ProvinceId equals Province.ProvinceId
                         select new DayliActivitiesDTO
                         {
                             ActivityId = DayliActivities.ActivityId,
                             Day = DayliActivities.Day,
                             Description = DayliActivities.Description,
                             Price = DayliActivities.Price,
                             ProvinceName = Province.ProvinceName,
                         };
            return activities;
        }
    }

    
}
