using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<ComplementaryContractServices,ComplementaryContractServices>();
            services.AddScoped<HotelContractServices, HotelContractServices>();
            services.AddScoped<TransportationContractServices, TransportationContractServices>();

            return services;
        }
    }
}
