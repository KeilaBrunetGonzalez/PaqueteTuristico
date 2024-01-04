/*using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class ReportServices
    {
        private readonly conocubaContext _context;

        public ReportServices(conocubaContext context)
        {
            this._context = context;
        }

        //Reporte de Contrato de Hoteles conciliados
        public IQueryable<ConciliatedHotelContractDto>? GetConcilHotelContracts()
        {
            var concilCont = from HotelContract in _context.HotelContractSet
                             join Hotel in _context.HotelSet on HotelContract.Hotelid equals Hotel.HotelId
                             join Room in _context.RoomSet on Hotel.HotelId equals Room.HotelId
                             join Meal in _context.MealSet on Hotel.HotelId equals Meal.HotelId
                             join Province in _context.ProvinceSet on Hotel.ProvinceId equals Province.ProvinceId
                             where HotelContract.Enabled && HotelContract.ConcilTime >= HotelContract.StarDate
                             select new ConciliatedHotelContractDto
                             {
                                 HotelName = Hotel.Name,
                                 HotelChain = Hotel.Chain,
                                 Province = Province.ProvinceName,
                                 Address = Hotel.Address,
                                 Category = Hotel.Category,
                                 StartDate = HotelContract.StarDate,
                                 EndDate = HotelContract.StarDate,
                                 ConciliationDate = HotelContract.ConcilTime,
                                 Description = HotelContract.Desc,
                                 RoomType = Room.Description,
                                 MealPlan = Meal.Description,
                                 ContractPrice = HotelContract.HotelTotalPrice
                             };
            return concilCont;
        }

        //Reporte de listado de contratos de transporte
        /*public IQueryable<ListTransport>? GetTransportContractsList()
        {
            var transpCont = from TransportationContract in _context.TransportationContractSet
                             join Vehicle in _context.VehicleSet on TransportationContract.LicensePlateNumber equals Vehicle.License_Plate_Number
                             join Transport in _context.TransportSet on Vehicle.VehicleId equals Transport.VehicleId
                             join Modality in _context.ModalitySet on Transport.ModalityId equals Modality.ModalityId
                             let km = _context.Mileage_CostsSet.FirstOrDefault(x => x.ModalityId == Modality.ModalityId)
                             let hk = _context.Cost_Per_HoursSet.FirstOrDefault(x => x.ModalityId == Modality.ModalityId)
                             let re = _context.Cost_Per_ToursSet.FirstOrDefault(x => x.ModalityId == Modality.ModalityId)
                             select new ListTransport
                             {
                                 PrestarioTransporte = TransportationContract.TransportationProvider,
                                 FechaInicioContrato = TransportationContract.StarDate,
                                 FechaTerminacionContrato = TransportationContract.EndTime,
                                 FechaConciliacionContrato = TransportationContract.ConcilTime,
                                 Chapa = Vehicle.License_Plate_Number,
                                 Marca = Vehicle.Brand,
                                 CapacidadSinEquipajes = Vehicle.Capacity_Without_Equipement,
                                 CapacidadConEquipajes = Vehicle.Capacity_With_Equipement,
                                 CapacidadTotal = Vehicle.Total_Capacity,
                                 AnnoFabricacion = Vehicle.Year_of_Manufacture,
                                 CostoPorKilometro = km.cost_per_kilometer,
                                 CostoPorKilometroIdaVuelta = km.cost_per_round_trip,
                                 CostoPorHorasEspera = km.cost_per_waiting_hour,
                                 CostoPorKilometroRecorrido = hk.cost_per_kilometer_traveled,
                                 CostoPorHoras = hk.cost_per_hour,
                                 CostoPorKilometrosExtras = hk.extra_kilometer_cost,
                                 CostosPorHorasExtras = hk.extra_hour_cost,
                                 DescripcionRecorrido = re.rout_description,
                                 CostoRecorrido = re.route_cost,
                                 CostoPorIdaVuelta = re.round_trip_cost
                             };

            return transpCont;

        }*/

        //Reporte de listado de temporadas de los contratos de hoteles
        public IQueryable<SeasonHotelContract>? GetHotelContractsBySeason()
        {
            var seasonConts = from HotelContract in _context.HotelContractSet
                              join Hotel in _context.HotelSet on HotelContract.Hotelid equals Hotel.HotelId
                              join HotelPlan in _context.HotelPlanSet on Hotel.HotelId equals HotelPlan.HotelId
                              join Season in _context.SeasonSet on HotelPlan.SeasonId equals Season.SeasonId
                              join Room in _context.RoomSet on Hotel.HotelId equals Room.HotelId
                              join Meal in _context.MealSet on Hotel.HotelId equals Meal.HotelId
                              select new SeasonHotelContract
                              {
                                  HotelName = Hotel.Name,
                                  StartDate = HotelContract.StarDate,
                                  EndDate = HotelContract.EndTime,
                                  ConciliationDate = HotelContract.ConcilTime,
                                  SeasonStartDate = Season.StartDate,
                                  SeasonName = Season.SeasonName,
                                  RoomType = Room.Description,
                                  MealPlan = Meal.Description,
                                  ContractPrice = HotelContract.HotelTotalPrice
                              };
            return seasonConts;
        }

        //Reporte de listado de hoteles activos
        public IQueryable<HotelDTO>? GetActivesHotels()
        {
            var activeHotel = from Hotel in _context.HotelSet
                              join Province in _context.ProvinceSet on Hotel.ProvinceId equals Province.ProvinceId
                              where Hotel.Enabled
                              select new HotelDTO
                              {
                                  Date = DateTime.Now,
                                  HotelName = Hotel.Name,
                                  HotelChain = Hotel.Chain,
                                  Province = Province.ProvinceName,
                                  Category = Hotel.Category,
                                  Phone = Hotel.Phone,
                                  Address = Hotel.Address,
                                  Email = Hotel.Email,
                                  DisNearCity = Hotel.DisNearCity,
                                  DisAirport = Hotel.DisAirport,
                                  NumberOfRooms = Hotel.NumberOfRooms,
                                  NumberOfFloors = Hotel.NumberOfFloors,
                                  ComercializationMode = Hotel.ComercializationMode
                              };
            return activeHotel;
        }
    }
}
*/