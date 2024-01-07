using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleServices _vehicleServices;
        private readonly ILogger<HotelController> logger;
        
        public VehiclesController(ILogger<HotelController> logger, VehicleServices _vehicleServices)
        {
            this.logger = logger;
            
            this._vehicleServices = _vehicleServices;
        }

        // GET: api/<Vehicles>
        [HttpGet]
        public  async Task<ActionResult<List<Vehicle>>> Get()
        {

            return await _vehicleServices.GetAll();
        }

        // GET api/<Vehicles>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> Get(int id)
        {
            var temp = await _vehicleServices.GetVehicleById(id);
            if (temp == null)
            {
                return NotFound();
            }
            return Ok(temp);
        }
        [Authorize]
        [HttpGet("Province/{ProvinceId}/{startDate}/{endDate}")]
        public async Task<ActionResult<List<Vehicle>>> GetRoomsByHotelId(int ProvinceId, DateTime startDate, DateTime endDate)
        {
            var list = await _vehicleServices.GetProvinceVheicleAsync(ProvinceId,startDate,endDate);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
        }

        // POST api/<Vehicles>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Vehicle vehicle)
        {
            var id = await _vehicleServices.ObtenerUltimoIdVehicleAsync();
            vehicle.VehicleId = ++id;
            var temp = await _vehicleServices.CreateVehicle(vehicle);
            if(!temp)
               return BadRequest();
            return Ok("Vehicle Inserted");
        }

        // PUT api/<Vehicles>/5
        [HttpPut]
        public  async Task<ActionResult<string>> Put([FromBody] Vehicle vehicle)
        {
            var temp =  await _vehicleServices.UpdateVehicle(vehicle);
            if (temp)
            {
                return Ok("Vehicle Updated");
            }
            return NotFound();
        }

        // DELETE api/<Vehicles>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            
            var temp = await _vehicleServices.DeleteVehicle(id);
            if (!temp)
            {
                return BadRequest();
            }
            return Ok("Vehicle Deleted");
        }

        [HttpGet("GetVehicles")]
        public IActionResult GetVehicles()
        {
            var vehicles = _vehicleServices.GetAllVehicle();

            if (vehicles != null)
            {
                return Ok(vehicles);
            }

            return NotFound();
        }
    }
}
