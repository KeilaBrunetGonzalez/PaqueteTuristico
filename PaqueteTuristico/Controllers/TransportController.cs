using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly TransportServices services;
        
        public TransportController(TransportServices services)
        {
            this.services = services;
            
        }
        // GET: api/<TransportController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transport>>> Get()
        {
            return await services.GetAll();

        }

        // GET api/<TransportController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transport>> Get(int vehicleid , int modalityid)
        {  
            return await services.GetTransportById(vehicleid, modalityid);  

        }

        // POST api/<TransportController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] TransportDTO transport)
        {
            Transport transport1 = new Transport();
            transport1.ModalityId = transport.ModalityId;
            transport1.VehicleId = transport.VehicleId;
            transport1.Transport_Cost = transport.Transport_Cost;   
            var t = await services.CreateTransport(transport1);

            if (t)
            {
                return Ok("Transport inserted");
            }

            return BadRequest("Transport already exist");
        }

        // PUT api/<TransportController>/5
        [HttpPut]
        public async Task<ActionResult<string>> Put([FromBody] TransportDTO transport)
        {
            Transport transport1 = new Transport();
            transport1.ModalityId = transport.ModalityId;
            transport1.VehicleId = transport.VehicleId;
            transport1.Transport_Cost = transport.Transport_Cost;
            var r = await services.Updatetransport(transport1);

            if (r)
            {
                return Ok("Transport updated");
            }
            return NotFound("Transport not found");

        }

        // DELETE api/<TransportController>/5
        [HttpDelete("{modalityid}/{vehicleid}")]
        public async Task<ActionResult<string>> Delete(int modalityid, int vehicleid)
        {
            var r = await services.DeleteTransport(modalityid, vehicleid);

            if (r)
            {
                return Ok("Transport Deleted");
            }
            return NotFound("Transport not found");
        }
    }
}
