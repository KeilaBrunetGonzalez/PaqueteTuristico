﻿using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class DayliActivityServices
    {
        private readonly conocubaContext context;
        private readonly ContractServices con_services;
        public DayliActivityServices(conocubaContext context, ContractServices con_services)
        {
            this.context = context;
            this.con_services = con_services;
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

        public async Task<ICollection<DayliActivities>?> GetProvinceActivitiesAsync(int ProvinceId, DateTime startDate, DateTime endDate)
        {
            //Va aqui await con_servicesIs.IsContractEnabled(hotel.contractId)

            int starD = startDate.Day;
            int endD = endDate.Day;
            var list = await context.DayliActivitieSet
            .Where(da => da.ProvinceId == ProvinceId &&
            da.Day >= starD && da.Day <= endD)
            .ToListAsync();

            var newList = new List<DayliActivities>();

            if(list != null)
            {
                foreach (var l in list)
                {
                    if ( await con_services.IsContractEnabled(l.ContractId))
                    {
                        newList.Add(l);
                    }
                }

                return newList;
            }

            return list;
        }

        public async Task<int> ObtenerUltimoIdActivitiesAsync()
        {
            int ultimoId = await context.DayliActivitieSet.AnyAsync()
                ? await context.DayliActivitieSet.MaxAsync(e => e.ActivityId)
                : 0;

            return ultimoId;
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
