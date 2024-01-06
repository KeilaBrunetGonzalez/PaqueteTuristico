using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Controllers;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
                if(temp.Brand!= vehicle.Brand)
                {
                    temp.Brand = vehicle.Brand;
                }
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

        public async Task<List<Vehicle>?> GetProvinceVheicleAsync(int ProvinceId)
        {
            var list = await context.VehicleSet
            .Where(V => V.ProvinceId == ProvinceId)
            .ToListAsync();

            return list;
        }

        public async Task<int> ObtenerUltimoIdVehicleAsync()
        {
            int ultimoId = await context.VehicleSet.AnyAsync()
                ? await context.VehicleSet.MaxAsync(e => e.VehicleId)
                : 0;

            return ultimoId;
        }

        public IQueryable<VehicleDTO>? GetAllVehicle()
        {
            var vehicles = from Vehicle in context.VehicleSet
                         join Province in context.ProvinceSet on Vehicle.ProvinceId equals Province.ProvinceId
                         select new VehicleDTO
                         {
                             VehicleId = Vehicle.VehicleId,
                             License_Plate_Number = Vehicle.License_Plate_Number,
                             Brand = Vehicle.Brand,
                             Capacity_Without_Equipement = Vehicle.Capacity_Without_Equipement,
                             Capacity_With_Equipement = Vehicle.Capacity_With_Equipement,
                             Total_Capacity = Vehicle.Total_Capacity,
                             Year_of_Manufacture = Vehicle.Year_of_Manufacture,
                             Manufacturing_Mode = Vehicle.Manufacturing_Mode,
                             ProvinceName = Province.ProvinceName
                         };
            return vehicles;
        }
    }
}
