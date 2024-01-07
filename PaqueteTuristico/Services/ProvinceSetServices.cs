using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class ProvinceSetService : ServiceBase
    {

        public ProvinceSetService(conocubaContext context) : base(context)
        {
        }

        //Get
        public async Task<Province?> GetProvinceByIdAsync(int ProvinceId)
        {
            var existingProvince = await context.ProvinceSet.FirstAsync(P => P.ProvinceId == ProvinceId);
            if (existingProvince == null)
            {
                return null;

            }
            return existingProvince;
        }

        public async Task<List<Province>?> GetProvincesAsync()
        {
            var list = await context.ProvinceSet.ToListAsync();

            return list;
        }

        //Insert
        public async Task<bool> InsertProvinceAsync(Province province)
        {
            var existingProvince = await context.ProvinceSet.FindAsync(province.ProvinceId);
            var find = false;
            if (existingProvince == null)
            {
                await context.ProvinceSet.AddAsync(province);
                await context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        //Update
        public async Task<bool> UpdateProvinceAsync(Province province)
        {
            var existingProvince = await context.ProvinceSet.FindAsync(province.ProvinceId);
            var existingP = await context.ProvinceSet.FindAsync(province.ProvinceName);
            var find = false;
            if (existingProvince != null)
            {
                if(existingP == null)
                {
                    context.Entry(existingProvince).CurrentValues.SetValues(province);
                    await context.SaveChangesAsync();
                    find = true;
                }

            }
            return find;
        }

        //Delete
        public async Task<bool> DeleteProvinceAsync(int Id)
        {
            var existingProvince = await context.ProvinceSet.FindAsync(Id);
            var find = false;
            if (existingProvince != null)
            {
                context.ProvinceSet.Remove(existingProvince);
                await context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        public async Task<int> GetLastProvinceIdAsync()
        {
            int ultimoId = await context.ProvinceSet.AnyAsync()
                ? await context.ProvinceSet.MaxAsync(e => e.ProvinceId)
                : 0;

            return ultimoId;
        }

    }
}
