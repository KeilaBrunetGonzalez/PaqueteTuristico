using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class SeasonServices : ServiceBase
    {
        public SeasonServices(conocubaContext context) : base(context)
        {
        }
        public async Task<bool> CreateSeason(Season season)
        {
            try
            {
                await context.SeasonSet.AddAsync(season);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteSeason(int id)
        {
            try
            {
                var temp = await context.SeasonSet.FirstAsync(d => d.SeasonId == id);
                context.SeasonSet.Remove(temp);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public async Task<bool> UpdateSeasons(Season season)
        {
            var current = await context.SeasonSet.FirstOrDefaultAsync(s => s.SeasonId == season.SeasonId);

            if (current == null)
            {
                return false;
            }
            else
            {
                if (current.StartDate != season.StartDate)
                {
                    current.StartDate = season.StartDate;
                }
                if (current.SeasonName != season.SeasonName)
                {
                    current.SeasonName = season.SeasonName;
                }

                context.SeasonSet.Update(current);
                await context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<List<Season>> GetAll()
        {
            return await context.SeasonSet.ToListAsync();
        }

        public async Task<Season> GetSeasonById(int id)
        {
            Season season = await context.SeasonSet.FirstAsync(x => x.SeasonId == id);
            return season;
        }

    }
}
