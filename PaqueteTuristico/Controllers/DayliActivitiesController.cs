﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DayliActivitiesController : ControllerBase
    {
        private readonly DayliActivityServices _services;
        private readonly ILogger<HotelController> logger;
        
        public DayliActivitiesController(ILogger<HotelController> logger, conocubaContext context , DayliActivityServices _services)
        {
            this.logger = logger;
            
            this._services = _services;
        }

        // GET: api/<DayliActivitiesControler>
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<DayliActivities>>> Get()
        {
            return await _services.GetAll();
        }

        // GET api/<DayliActivitiesControler>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayliActivities>> Get(int id)
        {
            var temp = await _services.GetDayliActivitieById(id);
            if (temp == null)
            {
                return BadRequest();
            }
            return Ok(temp);
        }
        [Authorize]
        [HttpGet("Province/{ProvinceId}/{startDate}/{endDate}")]
        public async Task<ActionResult<List<DayliActivities>>> GetActivitiesByProvinceId(int ProvinceId, DateTime startDate, DateTime endDate)
        {
            var list = await _services.GetProvinceActivitiesAsync(ProvinceId,startDate,endDate);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
        }

        // POST api/<DayliActivitiesControler>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] DayliActivitiesDTO dayli)

        {
            var activity = new DayliActivities();
            activity.Price = dayli.Price;
            activity.ProvinceId = dayli.ProvinceId;
            activity.ContractId = dayli.ContractId;
            activity.Day = dayli.Day;
            activity.Description = dayli.Description;
            var id = await _services.ObtenerUltimoIdActivitiesAsync();
            dayli.ActivityId = ++id;
            var temp = await _services.CreateDayliActivitie(activity);
            if (!temp)
            {
                return BadRequest();
            }

            return Ok("Activity inserted");
        }

        // PUT api/<DayliActivitiesControler>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DayliActivities dayli)
        {
            var activity = new DayliActivities();
            activity.Price = dayli.Price;
            activity.ProvinceId = dayli.ProvinceId;
            activity.ContractId = dayli.ContractId;
            activity.Day = dayli.Day;
            activity.Description = dayli.Description;
            activity.ActivityId = dayli.ActivityId;
            var current = await _services.UpdateDayliActivities(dayli);

            if (!current)
            {
                return NotFound();
            }
            
                
            return Ok("Dayli Activitie Updated");
        }

        // DELETE api/<DayliActivitiesControler>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try { 
            var temp =  await _services.DeletedayliActivities(id);
                if (!temp)
                {
                    return BadRequest();
                }
            }catch (Exception ex)
            {
                ex.ToString();
            }
            return Ok("Activity Deleted");

        }

        [HttpGet("GetActivities")]
        public IActionResult GetHotels()
        {
            var activities = _services.GetAllActivities();

            if (activities != null)
            {
                return Ok(activities);
            }

            return NotFound();
        }
    }
}
