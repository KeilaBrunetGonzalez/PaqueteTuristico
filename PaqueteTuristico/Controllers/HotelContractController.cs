﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelContractController : ControllerBase
    {
        private readonly conocubaContext _context;

        public HotelContractController(conocubaContext context)
        {
            this._context = context;
        }

        //GET
        [HttpGet("/contracts/HotelContract")]

        public async Task<ActionResult<List<Models.HotelContract>>> GetHotelContract()
        {
            var list = await _context.HotelContractSet.ToListAsync();

            return Ok(list);
        }

        //POST
        [HttpPost("/contracts/HotelContract")]
        public async Task<ActionResult<string>> CreateHotelContract([FromBody] Models.HotelContract contract)
        {
            var econtract = await _context.HotelContractSet.FindAsync(contract.Id);
            if (econtract != null)
            {
                return BadRequest("Ese contrato ya existe");
            }
            else
            {
                await _context.EContractSet.AddAsync(contract);
                await _context.HotelContractSet.AddAsync(contract);
                await _context.SaveChangesAsync();

                return Ok("Contrato hotelero introducido exitosamente");
            }
        }

        //PUT
        [HttpPut("/contracts/HotelContract")]
        public async Task<ActionResult<string>> UpdateHotelContract([FromBody] Models.HotelContract contract)
        {
            var econtract = await _context.HotelContractSet.FindAsync(contract.Id);

            if (econtract == null)
            {
                return BadRequest("Ese contrato no existe");
            }
            _context.Entry(econtract).CurrentValues.SetValues(contract);
            await _context.SaveChangesAsync();

            return Ok("Contrato hotel actualizado exitosamente");
        }

        //DELETE
        [HttpDelete("/contracts/HotelContract")]
        public async Task<ActionResult<string>> DeleteHotelContract(int Id)
        {
            var econtract = await _context.HotelContractSet.FindAsync(Id);

            if (econtract == null)
            {
                return BadRequest("Ese contrato no existe");
            }

            _context.HotelContractSet.Remove(econtract);
            await _context.SaveChangesAsync();

            return Ok("Contrato de transporte eliminado exitosamente");
        }
    }
}