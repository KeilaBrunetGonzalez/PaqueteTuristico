using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;
using System.Diagnostics;
using System.Net;

namespace PaqueteTuristico.Services
{
    public class TourPackageServices
    {

        private readonly conocubaContext _context;
        private readonly TransportServices _services;
        public TourPackageServices(conocubaContext context,TransportServices services)
        {
            this._context = context;
            this._services = services;
        }

        //Get
        public IQueryable<TourPackageDTO>? GetAllTourPackages()
        {
            var package = from TourPackage in _context.TourPackagesSet
                              join Province in _context.ProvinceSet on TourPackage.ProvinceId equals Province.ProvinceId
                              join Hotel in _context.HotelSet on TourPackage.HotelId equals Hotel.HotelId
                              join Room in _context.RoomSet on TourPackage.RoomId equals Room.Id
                              join Meal in _context.MealSet on TourPackage.MealId equals Meal.Id
                              join Vehicle in _context.VehicleSet on TourPackage.VehicleId equals Vehicle.VehicleId
                              join Modality in _context.ModalitySet on TourPackage.ModalityId equals Modality.ModalityId
                              join User in _context.Users on TourPackage.UserId equals User.Id
                              
                              select new TourPackageDTO
                              {
                                  PackageId = TourPackage.PackageId,
                                  ProvinceName = Province.ProvinceName,
                                  HotelName = Hotel.Name,
                                  RoomName = Room.Name,
                                  MealName = Meal.Name,
                                  Vehicle = Vehicle.License_Plate_Number,
                                  Modality = Modality.ModalityId,
                                  UserName = User.UserName,
                                  PeopleCant = TourPackage.PeopleCant,
                                  StartDate = TourPackage.StartDate,
                                  EndDate = TourPackage.EndDate,
                                  Totalprice = TourPackage.Totalprice,
                              };
            return package;
        }

        public async Task<int> GetLastTourPackageIdAsync()
        {
            int ultimoId = await _context.TourPackagesSet.AnyAsync()
                ? await _context.TourPackagesSet.MaxAsync(e => e.PackageId)
                : 0;

            return ultimoId;
        }

        public async Task<bool> InsertTouPackageAsync(TourPackage tp)
        {
            var tpExists = await _context.TourPackagesSet.AnyAsync(t => t.PackageId == tp.PackageId);

            if (tpExists)
            {
                return false;
            }

            var hotel = await _context.HotelSet.FindAsync(tp.HotelId);
            hotel?.TourPackages.Add(tp);

            var room = await _context.RoomSet.FindAsync(tp.RoomId);
            room?.TourPackages.Add(tp);

            var meal = await _context.MealSet.FindAsync(tp.MealId);
            meal?.TourPackages.Add(tp);

            if (tp.VehicleId.HasValue && tp.ModalityId.HasValue) { 
                var transport = await _services.GetTransportById(tp.VehicleId.Value, tp.ModalityId.Value);
                transport?.TourPackages.Add(tp);
            }
           
            await _context.TourPackagesSet.AddAsync(tp);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTourPackageAsync(int packageId)
        {
            var existingTp = await _context.TourPackagesSet.FirstAsync(t => t.PackageId == packageId);
            var find = false;
            if (existingTp != null)
            {
                _context.TourPackagesSet.Remove(existingTp);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }


    }


}
