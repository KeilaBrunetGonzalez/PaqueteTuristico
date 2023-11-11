using Microsoft.EntityFrameworkCore;
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

    }
}
