using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class TransportationContractServices
    {
        private readonly conocubaContext _context;

        public TransportationContractServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<List<TransportationContract>?> GetTransportationContractAsync()
        {
            var list = await _context.TransportationContractSet.ToListAsync();

            return list;
        }

        //Post
        public async Task<bool> InsertTransportationContractAsync(TransportationContract cont)
        {
            var econtract = await _context.TransportationContractSet.FindAsync(cont.Id);
            var find = false;
            if (econtract != null)
            {
                find = true;
            }
            else
            {
                await _context.TransportationContractSet.AddAsync(cont);
                await _context.SaveChangesAsync();

            }
            return find;
        }

        //Put
        public async Task<bool> UpdateTransportationContractAsync(TransportationContract cont)
        {
            var econtract = await _context.TransportationContractSet.FindAsync(cont.Id);
            var find = true;
            if (econtract == null)
            {
                find = false;
            }
            else
            {
                _context.Entry(econtract).CurrentValues.SetValues(cont);
                await _context.SaveChangesAsync();
            }
            return find;
        }

        //Delete
        public async Task<bool> DeleteTransportationContractAsync(int Id)
        {
            var econtract = await _context.TransportationContractSet.FindAsync(Id);
            var find = true;
            if (econtract == null)
            {
                find = false;
            }
            else
            {
                _context.TransportationContractSet.Remove(econtract);
                await _context.SaveChangesAsync();
            }
            return find;
        }


        internal async Task<bool> UpdateEnabledAsync(int contractId, bool enb)
        {
            try
            {
                var existingContract = await _context.ComplementaryContractSet.FindAsync(contractId);

                if (existingContract != null)
                {
                    existingContract.Enabled = enb;

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
    }
}
