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

        public TourPackageServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public IQueryable<TourPackageDTO>? GetAllTourPackages()
        {
            var package = from TourPackage in _context.TourPackagesSet
                              join Province in _context.ProvinceSet on TourPackage.ProvinceId equals Province.ProvinceId
                              join Hotel in _context.HotelSet on TourPackage.HotelId equals Hotel.HotelId
                              join Vehicle in _context.VehicleSet on TourPackage.VehicleId equals Vehicle.VehicleId
                              join DayliActivities in _context.DayliActivitieSet on TourPackage.ActivityId equals DayliActivities.ActivityId
                              select new TourPackageDTO
                              {
                                  PackageId = TourPackage.PackageId,
                                  ProvinceName = Province.ProvinceName,
                                  HotelName = Hotel.Name,
                                  Vehicle = Vehicle.License_Plate_Number,
                                  Modality = TourPackage.ModalityId,
                                  Activity = DayliActivities.Description,
                                  StartDate = TourPackage.StartDate,
                                  EndDate = TourPackage.EndDate,
                                  Totalprice = TourPackage.Totalprice,
                              };
            return package;
        }

    }


}
