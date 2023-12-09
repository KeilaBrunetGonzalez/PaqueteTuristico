using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class ModalityServices : ServiceBase
    {
        public ModalityServices(conocubaContext context) : base(context)
        {
        }
        public async Task<int> GetLastModalityIdAsync()
        {
            int ultimoId = await context.ModalitySet.AnyAsync()
                ? await context.ModalitySet.MaxAsync(e => e.ModalityId)
                : 0;

            return ultimoId;
        }

        public async Task<Modality> GetModalityById(int id) 
        {
            return await context.ModalitySet.FirstAsync(c => c.ModalityId == id);
        }
    }
}
