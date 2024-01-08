using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class ContractServices
    {
        private readonly conocubaContext _context;

        public ContractServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<EContract?> GetContractAsync(int contractId)
        {
            var contract = await _context.EContractSet.FirstAsync(c => c.Id == contractId);
            if (contract == null)
            {
                return null;

            }
            return contract;
        }

        public async Task<List<EContract>?> GetAllContractsAsync()
        {
            var list = await _context.EContractSet.ToListAsync();

            return list;
        }

        public async Task<bool> UpdateEnabledAsync(int contractId, bool enb)
        {
            try
            {
                var existingContract = await _context.EContractSet.FindAsync(contractId);

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


        public async Task<bool> IsContractEnabled(int contractId)
        {
            var EContrat = await _context.EContractSet
            .Where(H => H.Id == contractId && H.Enabled == true)
            .ToListAsync();

            if (EContrat != null) { return false; }

            return true;
        }


    }

}
