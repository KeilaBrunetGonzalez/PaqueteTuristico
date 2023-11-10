using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ILogger<HotelController> logger;
        private readonly conocubaContext context;
        public TransportController(ILogger<HotelController> logger, conocubaContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        // GET: api/<TransportController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transport>>> Get()
        {
            return await context.TransportSet.ToListAsync();

        }

        // GET api/<TransportController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transport>> Get(int id)
        {
            var temp = await context.TransportSet.FirstOrDefaultAsync();
            if (temp != null)
            {
                return NotFound();
            }
            return Ok(temp);

        }

        // POST api/<TransportController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Transport transport)
        {
            await context.TransportSet.AddAsync(transport);
            await context.SaveChangesAsync();
            return Ok("Transport Inserted");
        }

        // PUT api/<TransportController>/5
        [HttpPut]
        public async Task<ActionResult<string>> Put([FromBody] Transport transport)
        {
            var temp = await context.TransportSet.FirstOrDefaultAsync(t => t.ModalityId == transport.ModalityId && t.VehicleId == transport.VehicleId);
            if (temp == null)
            {
                return NotFound();
            }
            else
            {
                if (temp.Transport_Cost != transport.Transport_Cost)
                    temp.Transport_Cost = transport.Transport_Cost;
            }
            context.TransportSet.Update(temp);
            await context.SaveChangesAsync();
            return Ok("Transport Updated");
        }

        // DELETE api/<TransportController>/5
        [HttpDelete("{modalityid,vehicleid}")]
        public async Task<ActionResult<string>> Delete(int modalityid, int vehicleid)
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
            }
            return Ok("Transport Deleted");
        }
    }
}
