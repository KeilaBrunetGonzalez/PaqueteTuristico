using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonController : ControllerBase

    {   private readonly ILogger<SeasonController> logger;

        SeasonServices services;

        private readonly conocubaContext context;
        public SeasonController(ILogger<SeasonController> logger,conocubaContext context, SeasonServices seasonServices)
        {
            this.context = context;
            this.logger = logger;
            this.services = seasonServices; 
        }

        // GET: api/<SeasonController1>
        
        [HttpGet(Name = "/Season/Default/")]

        public async Task<ActionResult<IEnumerable<Season>>>Get()
        {
            
            return await services.GetAll();
        }

            // GET api/<SeasonController1>/5

            [HttpGet("/Season/Season_ID")]
        public async Task<ActionResult<Season>> GetSeasonAsync(int id)
        {
            var season = await services.GetSeasonById(id);
            
            if (season == null)
            {
               return NotFound();
                
            }
            return Ok(season);
        }
        //  POST api/<SeasonController1>/5

        [HttpPost]

        public async Task<ActionResult<Season>> Post([FromBody] Season season)
        {
            
            try
            {
                await services.CreateSeason(season); 
            }
            catch (Exception ex)
            {
                ex.ToString();
                return BadRequest(ex);
            }
            return Ok();
        }

        //  PUT api/<SeasonController1>
        [HttpPut]
        public  async Task<IActionResult> Put([FromBody] Season season)
        {

            var current = await services.UpdateSeasons(season);

            if (!current)
            {
                return NotFound();
            }
            return Ok();
        }

        

        // DELETE api/<SeasonController1>/5

        [HttpDelete("/Season/Season_ID")]
        public async Task<IActionResult> Delete(int id)
        {   try
            {
            var current = await services.DeleteSeason(id);
            
        }catch(ArgumentNullException e)
            {
                e.ToString();
                return NotFound();
            }
            return Ok();
        }
    }
}
