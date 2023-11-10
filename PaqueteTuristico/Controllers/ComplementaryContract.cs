﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplementaryContract : ControllerBase
    {
        private readonly conocubaContext _context;

        public ComplementaryContract(conocubaContext context)
        {
            this._context = context;
        }
        //GET
        [HttpGet("/contracts/complementaryContract")]
        public async Task<ActionResult<List<Models.ComplementaryContract>>> GetCompContract()
        {
            var list = await _context.ComplementaryContractSet.ToListAsync();

            return Ok(list);
        }

        //POST
        [HttpPost("/contracts/complementaryContract")]
        public async Task<ActionResult<string>> CreateComplementaryContract([FromBody] Models.ComplementaryContract contract)
        {
            var econtract = await _context.ComplementaryContractSet.FindAsync(contract.Id);
            if (econtract != null)
            {
                return BadRequest("Ese contrato ya existe");
            }
            else
            {
                await _context.EContractSet.AddAsync(contract);
                await _context.ComplementaryContractSet.AddAsync(contract);
                await _context.SaveChangesAsync();

                return Ok("Contrato complementario introducido exitosamente");
            }
        }

        //PUT
        [HttpPut("/contracts/complementaryContract")]

        public async Task<ActionResult<string>> UpdateComplementaryContract([FromBody] Models.ComplementaryContract contract)
        {
            var econtract = await _context.ComplementaryContractSet.FindAsync(contract.Id);
            if (econtract == null)
            {
                return BadRequest("Ese contrato no existe");
            }
            else
            {
                _context.EContractSet.Update(contract);
                await _context.SaveChangesAsync();
                _context.ComplementaryContractSet.Update(contract);
                await _context.SaveChangesAsync();

                return Ok("Contrato complementario actualizado exitosamente");
            }
        }

        //Delete
        [HttpDelete("/contracts/complementaryContract")]

        public async Task<ActionResult<string>> DeleteComplementaryContract(int Id)
        {
            var econtract = await _context.ComplementaryContractSet.FindAsync(Id);
            if (econtract == null)
            {
                return BadRequest("Ese contrato no existe");
            }
            else
            {
                _context.ComplementaryContractSet.Remove(econtract);
                await _context.SaveChangesAsync();
                _context.EContractSet.Remove(econtract);
                await _context.SaveChangesAsync();

                return Ok("Contrato complementario eliminado exitosamente");
            }
        }

    }
}
