using PaqueteTuristico.Services;

namespace PaqueteTuristico
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<HotelServices, HotelServices>();
            services.AddScoped<RoomServices, RoomServices>();
            services.AddScoped<MealServices, MealServices>();
            services.AddScoped<ContractServices, ContractServices>();
            services.AddScoped<ComplementaryContractServices, ComplementaryContractServices>();
            services.AddScoped<HotelContractServices, HotelContractServices>();
            services.AddScoped<TransportationContractServices, TransportationContractServices>();  
            services.AddScoped<HotelPlanServices, HotelPlanServices>();
            services.AddScoped<DayliActivityServices, DayliActivityServices>();
            services.AddScoped<VehicleServices, VehicleServices>();
            services.AddScoped<ModalityServices, ModalityServices>();
            services.AddScoped<Mileage_CostServices, Mileage_CostServices>();
            services.AddScoped<Cost_per_hourServicescs, Cost_per_hourServicescs>();
            services.AddScoped<Cost_per_tourServices, Cost_per_tourServices>();
            services.AddScoped<TransportServices, TransportServices>();
            services.AddScoped<SeasonServices, SeasonServices>();


            return services;
        }
    }
}
