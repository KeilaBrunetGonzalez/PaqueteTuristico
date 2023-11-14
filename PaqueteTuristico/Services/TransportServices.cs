using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class TransportServices : ServiceBase
    {
        public TransportServices(conocubaContext context) : base(context)
        {
        }

        public async Task<bool> CreateTransport( Transport transport)
        {
            try {
                var vehiclecurrent = await context.VehicleSet.FirstAsync(x => x.VehicleId == transport.VehicleId);
                var modalitycurrent = await context.ModalitySet.FirstAsync(y => y.ModalityId == transport.ModalityId);
                transport.Modality = modalitycurrent;
                transport.Vehicle = vehiclecurrent;
                vehiclecurrent.Transports.Add(transport);
                modalitycurrent.Transports.Add(transport);
            await context.TransportSet.AddAsync(transport);
            await context.SaveChangesAsync();
            } catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteTransport( int modalityid , int vehicleid) 
        {
            try
            {
                var temp = context.TransportSet.FirstOrDefault(t => t.ModalityId == modalityid && t.VehicleId == vehicleid);
                context.TransportSet.Remove(temp);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return true;
        }
        public  async Task<bool> Updatetransport( Transport transport )
        {
            var temp = await context.TransportSet.FirstOrDefaultAsync(t => t.ModalityId == transport.ModalityId && t.VehicleId == transport.VehicleId);
            if (temp == null)
            {
                return false;
            }
            else
            {
                if (temp.Transport_Cost != transport.Transport_Cost)
                    temp.Transport_Cost = transport.Transport_Cost;
                context.TransportSet.Update(temp);
                await context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<List<Transport>> GetAll()
        {
            List<Transport> list = await context.TransportSet.ToListAsync();
            return list;
        }
        public async Task<Transport> GetTransportById( int vehicleid, int modalityid)
        {
            Transport transport = await context.TransportSet.FirstAsync(t => t.ModalityId == modalityid && t.VehicleId == vehicleid);
            return transport;
        }
    }
}
