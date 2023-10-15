using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase

    {   private readonly ILogger<SeasonController> logger;

        private static readonly string[] Summaries = new[]
       {
        "Alta"," Baja"
        };

        private readonly HotelContext context;
        public SeasonController(ILogger<SeasonController> logger,HotelContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: api/<SeasonController1>
        
        [HttpGet(Name = "/Season/Default/")]

        public IEnumerable<Season> Get()
        {
            
            return Enumerable.Range(1, 10).Select(index => new Season
            {
                StartDate = DateTime.Now.AddDays(index),
                SeasonName = Summaries[Random.Shared.Next(Summaries.Length)],

            }
                ).ToArray(); ;
        }

            // GET api/<SeasonController1>/5

            [HttpGet("/Season/Season_ID")]
        public async Task<ActionResult<Season>> GetSeasonAsync(int id)
        {
            var season = await context.Seasons.FirstAsync(n => n.SeasonId == id);
            
            if (season == null)
            {
               return NotFound();
                
            }
            return season;
        }
        
        // POST api/<SeasonController1>
        [HttpPost]
        public  async Task<IActionResult> Post(int id , string name, DateTime date)
        {

            var current = await context.Seasons.FirstAsync(s => s.SeasonId == id);

            if (current == null)
            {
                return NotFound();
            }
            else
            {
                if (!(name.Length == 0))
                {
                    current.SeasonName = name;
                } 
            current.StartDate = date;
                context.Seasons.Update(current);
                await context.SaveChangesAsync();   
            }
            return Ok();
        }

        // PUT api/<SeasonController1>/5

        [HttpPut("/Season/Season_ID")]

        public async Task<ActionResult<Season>> Put(int id, string name, DateTime date)
        {
            var current = new Season
            {
                SeasonId = id,
                SeasonName = name,
                StartDate = date,
            };
            try
            {
            await context.Seasons.AddAsync(current);
            await context.SaveChangesAsync();
            }catch(Exception ex)
            {
                ex.ToString();  
            }
        return Ok();
        }

        // DELETE api/<SeasonController1>/5

        [HttpDelete("/Season/Season_ID")]
        public async Task<IActionResult> Delete(int id)
        {   try
            {
            var current = await context.Seasons.FirstAsync(x => x.SeasonId == id);
            context.Seasons.Remove(current);
            await context.SaveChangesAsync();
        }catch(ArgumentNullException ex)
            {
                ex.ToString();
                return NotFound();
            }
            return Ok();
        }
    }
}
