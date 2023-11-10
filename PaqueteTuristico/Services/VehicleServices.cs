using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class VehicleServices
    {
        private readonly conocubaContext context;
        public VehicleServices(conocubaContext context)
        {
            this.context = context;
        }
        public  async void CreateVehicle(Vehicle vehicle) 
        {
            await context.VehicleSet.AddAsync(vehicle);
            await context.SaveChangesAsync();
        }
    }
}
