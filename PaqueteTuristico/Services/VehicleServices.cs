using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Controllers;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System.Collections.Generic;
using System.Transactions;

namespace PaqueteTuristico.Services
{
    public class VehicleServices : ServiceBase
    {
        public VehicleServices(conocubaContext context) : base(context)
        {
        }

        public  async Task<bool> CreateVehicle(Vehicle vehicle) 
        {
            var temp = await context.VehicleSet.FindAsync(vehicle.VehicleId);
            if (temp == null) { 
                await context.VehicleSet.AddAsync(vehicle);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public  async Task<bool> DeleteVehicle(int id)
        {
            try
            {
                var temp = await context.VehicleSet.FindAsync(id);
                if (temp != null)
                {
                    context.VehicleSet.Remove(temp);
                    await context.SaveChangesAsync();
                }else 
                { return false; }
            
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            
                var temp = await context.VehicleSet.FirstOrDefaultAsync(v => v.VehicleId == vehicle.VehicleId);
            if(temp == null) {
                return false;
            }
            else { 
                if (temp.Capacity_Without_Equipement != vehicle.Capacity_Without_Equipement)
                {
                    temp.Capacity_Without_Equipement = vehicle.Capacity_Without_Equipement;
                }
                if (temp.Capacity_With_Equipement != vehicle.Capacity_With_Equipement)
                {
                    temp.Capacity_With_Equipement = vehicle.Capacity_With_Equipement;
                }
                if (temp.Manufacturing_Mode != vehicle.Manufacturing_Mode)
                {
                    temp.Manufacturing_Mode = vehicle.Manufacturing_Mode;
                }
                if (temp.Total_Capacity != vehicle.Total_Capacity)
                {
                    temp.Total_Capacity = vehicle.Total_Capacity;
                }
                if (temp.License_Plate_Number != vehicle.License_Plate_Number)
                {
                    temp.License_Plate_Number = vehicle.License_Plate_Number;
                }
                if (temp.Year_of_Manufacture != vehicle.Year_of_Manufacture)
                {
                    temp.Year_of_Manufacture = vehicle.Year_of_Manufacture;
                }
                context.VehicleSet.Update(temp);
                await context.SaveChangesAsync();
            }
            
            return true;
        }
            
        public  async Task<List<Vehicle>> GetAll()
        {
            return await context.VehicleSet.ToListAsync();
            
        }
        public async Task<Vehicle> GetVehicleById(int id)
        {
           Vehicle temp =  await context.VehicleSet.FirstAsync(n => n.VehicleId == id);
            return temp;
        }

        public async Task<int> ObtenerUltimoIdVehicleAsync()
        {
            int ultimoId = await context.VehicleSet.AnyAsync()
                ? await context.HotelSet.MaxAsync(e => e.Id)
                : 0;

            return ultimoId;
        }
    }
}
