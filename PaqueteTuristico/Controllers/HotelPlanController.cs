﻿using Microsoft.AspNetCore.Mvc;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelPlanController : ControllerBase
    {
        private readonly ILogger<HotelPlanController> logger;

        private static readonly string[] Summaries = new[]
       {
        "Alta"," Baja"
        };

        private readonly HotelContext context;
        public HotelPlanController(ILogger<HotelPlanController> logger, HotelContext context)
        {
            this.context = context;
            this.logger = logger;
        }


        // GET api/<HotelPlanController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelPlan>> GetHotelPlanAsync(int HotelId, int seasonId)
        {
            var current = await context.HotelPlanSet.FindAsync(HotelId, seasonId);
            if (current == null)
            {
                return NotFound();

            }
            return current;
        }
            
 

        // PUT api/<HotelPlanController>/5
        [HttpPut("{id}")]
    public async Task<ActionResult<HotelPlan>> Put(int hotelid, int seasonid)
    {      var temp = await context.HotelSet.FindAsync(hotelid);
            var temp1 = await context.Seasons.FindAsync(seasonid);
            if (temp == null || temp1 == null)
            {
                return BadRequest();
            }
            var current = new HotelPlan
        {
            SeasonId = seasonid,
            HotelId = hotelid,
        };
        try
        {
            await context.HotelPlanSet.AddAsync(current);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        return Ok();
    }

    // DELETE api/<HotelPlanController>/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Seasonid , int Hotelid)
        {
            try
            {
                var current = await context.HotelPlanSet.FindAsync(Seasonid, Hotelid);
                var temp = await context.Seasons.FindAsync(Seasonid);
                var temp1 = await context.HotelSet.FindAsync(Hotelid);
                context.Seasons.Remove(temp);
                context.HotelPlanSet.Remove(current);
                context.HotelSet.Remove(temp1);
                await context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                ex.ToString();
                return NotFound();
            }
            return Ok();
        }

    }
}