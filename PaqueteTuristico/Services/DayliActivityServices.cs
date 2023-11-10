using PaqueteTuristico.Data;
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
        public async void CreateDayliActivitie(DayliActivities activitie)
        {
            await context.DayliActivitieSet.AddAsync(activitie);
            await context.SaveChangesAsync();
        }
    }
}
