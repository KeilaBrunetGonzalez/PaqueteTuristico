using PaqueteTuristico.Data;

namespace PaqueteTuristico.Services
{
    public class ServiceBase
    {
        protected readonly conocubaContext context;
        public ServiceBase(conocubaContext context)
        {
            this.context = context;
        }
    }
}
