using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<HotelController> logger;
        private readonly conocubaContext context;
        public VehiclesController(ILogger<HotelController> logger, conocubaContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        // GET: api/<Vehicles>
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {

            return  await context.VehicleSet.ToListAsync();
        }

        // GET api/<Vehicles>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> Get(int id)
        {
            var temp = await context.VehicleSet.FirstOrDefaultAsync(V => V.VehicleId == id);
            if (temp == null)
            {
                return NotFound();
            }
            return Ok(temp);
        }

        // POST api/<Vehicles>
        [HttpPost]
        public  async Task<ActionResult<string>> Post([FromBody] Vehicle vehicle)
        {
            await context.VehicleSet.AddAsync(vehicle);
            await context.SaveChangesAsync();
            return Ok("Vehicle Inserted");
        }

        // PUT api/<Vehicles>/5
        [HttpPut("{id}")]
        public  async Task<ActionResult<string>> Put( [FromBody] Vehicle vehicle)
        {
            var temp =  await context.VehicleSet.FirstOrDefaultAsync(v => v.VehicleId == vehicle.VehicleId);
            if (temp == null)
            {
                return NotFound();
            }
            else { 
               if (temp.Capacity_Without_Equipement != vehicle.Capacity_Without_Equipement)
                {
                    temp.Capacity_Without_Equipement = vehicle.Capacity_Without_Equipement;
                }
               if(temp.Capacity_With_Equipement != vehicle.Capacity_With_Equipement)
                {
                    temp.Capacity_With_Equipement = vehicle.Capacity_With_Equipement;
                }
               if(temp.Manufacturing_Mode != vehicle.Manufacturing_Mode)
                {
                    temp.Manufacturing_Mode = vehicle.Manufacturing_Mode;
                }
               if(temp.Total_Capacity != vehicle.Total_Capacity)
                {
                    temp.Total_Capacity = vehicle.Total_Capacity;
                }
               if(temp.License_Plate_Number != vehicle.License_Plate_Number)
                {
                    temp.License_Plate_Number = vehicle.License_Plate_Number;
                }
               if(temp.Year_of_Manufacture != vehicle.Year_of_Manufacture)
                {
                    temp.Year_of_Manufacture = vehicle.Year_of_Manufacture;
                }
            }
            return Ok("Vehicle Updated");
        }

        // DELETE api/<Vehicles>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try { 
            var temp = await context.VehicleSet.FindAsync(id);
            context.VehicleSet.Remove(temp);
                await context.SaveChangesAsync();
            }catch (Exception ex)
            {
                ex.ToString();
            }
            return Ok("Vehicle Deleted");
        }
    }
}
