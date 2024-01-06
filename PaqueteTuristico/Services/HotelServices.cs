using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;
using System.Net;

namespace PaqueteTuristico.Services
{
    public class HotelServices
    {

        private readonly conocubaContext _context;

        public HotelServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<Hotel?> GetHotelAsync(int HotelId)
        {
            var existingHotel = await _context.HotelSet.FirstAsync(H => H.HotelId == HotelId);
            if (existingHotel == null)
            {
                return null;

            }
            return existingHotel;
        }

        public async Task<List<Hotel>?> GetHotelsAsync()
        {
            var list = await _context.HotelSet.ToListAsync();

            return list;
        }
        
        //Insert
        public async Task<bool> InsertHotelAsync(Hotel hotel)
        {
            var existingHotel = await _context.HotelSet.FindAsync(hotel.HotelId);
            var find = false;
            if (existingHotel == null)
            {
                await _context.HotelSet.AddAsync(hotel);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        //Update
        public async Task<bool> UpdateHotelAsync(Hotel hotel)
        {
            var existingHotel = await _context.HotelSet.FindAsync(hotel.HotelId);
            var find = false;
            if (existingHotel != null)
            {
                _context.Entry(existingHotel).CurrentValues.SetValues(hotel);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        //Delete
        public async Task<bool> DeleteHotelAsync(int Id)
        {
            var existingHotel = await _context.HotelSet.FindAsync(Id);
            var find = false;
            if (existingHotel != null)
            {
                _context.HotelSet.Remove(existingHotel);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }

        public async Task<int> GetLastHotelIdAsync()
        {
            int ultimoId = await _context.HotelSet.AnyAsync()
                ? await _context.HotelSet.MaxAsync(e => e.HotelId)
                : 0;

            return ultimoId;
        }
        public async Task<bool> UpdateEnabledAsync(int hotelId, bool enb)
        {
            try
            {
                var existingHotel = await _context.HotelSet.FindAsync(hotelId);

                if (existingHotel != null)
                {
                    existingHotel.Enabled = enb;

                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public IQueryable<HotelDTO>? GetAllHotels()
        {
            var hotels = from Hotel in _context.HotelSet
                              join Province in _context.ProvinceSet on Hotel.ProvinceId equals Province.ProvinceId
                              select new HotelDTO
                              {
                                  HotelId = Hotel.HotelId,
                                  HotelName = Hotel.Name,
                                  HotelChain = Hotel.Chain,
                                  Category = Hotel.Category,
                                  Phone = Hotel.Phone,
                                  Email = Hotel.Email,
                                  NumberOfRooms = Hotel.NumberOfRooms,
                                  ProvinceName = Province.ProvinceName,
                                  DisNearCity = Hotel.DisNearCity,
                                  DisAirport = Hotel.DisAirport,
                                  NumberOfFloors = Hotel.NumberOfFloors,
                                  Address = Hotel.Address,
                                  ComercializationMode = Hotel.ComercializationMode,
                                  Price = Hotel.Price,
                                  Enabled = Hotel.Enabled
                              };
            return hotels;
        }
        public async Task<List<Hotel>?> GetProvinceActiveHotelAsync(int ProvinceId)
        {
            var list = await _context.HotelSet
            .Where(V => V.ProvinceId == ProvinceId && V.Enabled == true)
            .ToListAsync();

            return list;
        }
    }
       



}
