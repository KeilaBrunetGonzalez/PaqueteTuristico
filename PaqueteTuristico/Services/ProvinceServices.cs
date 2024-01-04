using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class ProvinceService
    {

        private readonly conocubaContext _context;

        public ProvinceService(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<Province?> GetProvinceAsync(int ProvinceId)
        {
            var existingProvince = await _context.ProvinceSet.FirstAsync(P => P.ProvinceId == ProvinceId);
            if (existingProvince == null)
            {
                return null;

            }
            return existingProvince;
        }

        public async Task<List<Province>?> GetProvincesAsync()
        {
            var list = await _context.ProvinceSet.ToListAsync();

            return list;
        }

        //Insert
        public async Task<bool> InsertProvinceAsync(Province province)
        {
            var existingProvince = await _context.ProvinceSet.FindAsync(province.ProvinceId);
            var find = false;
            if (existingProvince == null)
            {
                await _context.ProvinceSet.AddAsync(province);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        //Update
        public async Task<bool> UpdateProvinceAsync(Province province)
        {
            var existingProvince = await _context.ProvinceSet.FindAsync(province.ProvinceId);
            var find = false;
            if (existingProvince != null)
            {
                _context.Entry(existingProvince).CurrentValues.SetValues(province);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        //Delete
        public async Task<bool> DeleteProvinceAsync(int Id)
        {
            var existingProvince = await _context.ProvinceSet.FindAsync(Id);
            var find = false;
            if (existingProvince != null)
            {
                _context.ProvinceSet.Remove(existingProvince);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        public async Task<int> GetLastProvinceIdAsync()
        {
            int ultimoId = await _context.ProvinceSet.AnyAsync()
                ? await _context.ProvinceSet.MaxAsync(e => e.ProvinceId)
                : 0;

            return ultimoId;
        }

    }
}
