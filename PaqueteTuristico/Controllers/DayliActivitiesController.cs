using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayliActivitiesController : ControllerBase
    {
        private readonly ILogger<HotelController> logger;
        private readonly conocubaContext context;
        public DayliActivitiesController(ILogger<HotelController> logger, conocubaContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        // GET: api/<DayliActivitiesControler>
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<DayliActivities>>> Get()
        {
            return await context.DayliActivitieSet.ToListAsync();
        }

        // GET api/<DayliActivitiesControler>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayliActivities>> Get(int id)
        {
            var temp = await context.DayliActivitieSet.FirstAsync(d =>d.ActivityId == id);
            return Ok(temp);
        }

        // POST api/<DayliActivitiesControler>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] DayliActivities dayli)
        {
            await context.DayliActivitieSet.AddAsync(dayli);
            await context.SaveChangesAsync();
            return Ok("Activity inserted");
        }

        // PUT api/<DayliActivitiesControler>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DayliActivities dayli)
        {
            var current = await context.DayliActivitieSet.FirstAsync(s => s.ActivityId == dayli.ActivityId);

            if (current == null)
            {
                return NotFound();
            }
            else
            {
                if (current.Price != dayli.Price)
                {
                    current.Price = dayli.Price;
                }
                if(current.Description != dayli.Description)
                {
                    current.Description = dayli.Description;
                }
                if(current.Day != dayli.Day)
                {
                    current.Day = dayli.Day;
                }
                if(current.Hour != dayli.Hour)
                {
                    current.Hour = dayli.Hour;
                }
                context.DayliActivitieSet.Update(current);
                await context.SaveChangesAsync();
            }
            return Ok();
        }

        // DELETE api/<DayliActivitiesControler>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try { 
            var temp =  await context.DayliActivitieSet.FirstAsync(d =>d.ActivityId == id);
            context.DayliActivitieSet.Remove(temp);
            await context.SaveChangesAsync();
            }catch (Exception ex)
            {
                ex.ToString();
            }
            return Ok("Activity Deleted");

        }
    }
}
