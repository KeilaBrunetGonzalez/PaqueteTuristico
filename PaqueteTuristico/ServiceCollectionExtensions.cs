using Microsoft.Extensions.DependencyInjection;
using PaqueteTuristico.Service;


namespace PaqueteTuristico
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<HotelServices, HotelServices>();

            return services;
        }
    }
}
