using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System.Diagnostics.Contracts;

namespace PaqueteTuristico.Services
{
    public class ComplementaryContractServices
    {
        private readonly conocubaContext _context;
        
        public ComplementaryContractServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<List<ComplementaryContract>?> GetComplementaryContractsAsync()
        {
            var list = await _context.ComplementaryContractSet.ToListAsync();

            return list;
        }

        //Post
        public async Task<bool> InsertComplementaryContractAsync(ComplementaryContract cont)
        {
            var econtract = await _context.ComplementaryContractSet.FindAsync(cont.Id);
            var find = false;
            if (econtract != null)
            {
                find = true;
            }
            else
            {
                await _context.ComplementaryContractSet.AddAsync(cont);
                await _context.SaveChangesAsync();
                
            }
            return find;
        }

        //Put
        public async Task<bool> UpdateComplementaryContractAsync(ComplementaryContract cont)
        {
            var econtract = await _context.ComplementaryContractSet.FindAsync(cont.Id);
            var find = true;
            if (econtract == null)
            {
                find = false;
            }
            else { 
            _context.Entry(econtract).CurrentValues.SetValues(cont);
            await _context.SaveChangesAsync();
            }
            return find;
        }

        //Delete
        public async Task<bool> DeleteComplementaryContractAsync(int Id)
        {
            var econtract = await _context.ComplementaryContractSet.FindAsync(Id);
            var find = true;
            if (econtract == null)
            {
                find = false;
            }
            else
            {
                _context.ComplementaryContractSet.Remove(econtract);
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
