using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationContract : ControllerBase
    {
        private readonly conocubaContext _context;

        public TransportationContract(conocubaContext context)
        {
            this._context = context;
        }

        // GET 

        [HttpGet("/contracts/transportationContract")]

        public async Task<ActionResult<List<Models.TransportationContract>>> GetTransContract()
        {
            var list = await _context.TransportationContractSet.ToListAsync();

            return Ok(list);
        }



        // POST 

        [HttpPost("/contracts/transportationContract")]
        public async Task<ActionResult<string>> CreateTransportationContract([FromBody] Models.TransportationContract contract)
        {
            var econtract = await _context.TransportationContractSet.FindAsync(contract.Id);
            if (econtract != null)
            {
                return BadRequest("Ese contrato ya existe");
            }
            else
            {
                await _context.EContractSet.AddAsync(contract);
                await _context.TransportationContractSet.AddAsync(contract);
                await _context.SaveChangesAsync();

                return Ok("Contrato de transporte introducido exitosamente");
            }
        }

        //PUT

        [HttpPut("/contracts/transportationContract")]
        public async Task<ActionResult<string>> UpdateTransportationContract([FromBody] Models.TransportationContract contract)
        {
            var econtract = await _context.TransportationContractSet.FindAsync(contract.Id);

            if (econtract == null)
            {
                return BadRequest("Ese contrato no existe");
            }
            _context.Entry(econtract).CurrentValues.SetValues(contract);

            await _context.SaveChangesAsync();

            return Ok("Contrato de transporte actualizado exitosamente");
        }

        //DELETE

        [HttpDelete("/contracts/transportationContract")]
        public async Task<ActionResult<string>> DeleteTransportationContract(int Id)
        {
            var econtract = await _context.TransportationContractSet.FindAsync(Id);

            if (econtract == null)
            {
                return BadRequest("Ese contrato no existe");
            }

            _context.TransportationContractSet.Remove(econtract);
            await _context.SaveChangesAsync();

            return Ok("Contrato de transporte eliminado exitosamente");
        }

    }
}
