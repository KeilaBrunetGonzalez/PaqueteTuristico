﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;
using System.Diagnostics.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostPerHourController : ControllerBase
    {
        private readonly conocubaContext _context;
        private readonly Cost_per_hourServicescs _cost_per_hourServicescs;

        public CostPerHourController(conocubaContext context, Cost_per_hourServicescs _cost_per_hourServicescs)
        {
            this._context = context;
            this._cost_per_hourServicescs = _cost_per_hourServicescs;
        }

        // GET

        [HttpGet]

        public async Task<ActionResult<List<Models.CostPerHour>>> GetCostPerHour()
        {
            var list = await _cost_per_hourServicescs.GetCostPerHours();

            return Ok(list);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<String>> PostCostPerHour([FromBody] CostPerHour modality)
        {
            var mod = await _cost_per_hourServicescs.CreateCostperhour(modality);
            if (!mod)
            {
                return NotFound("Cost per hour not found");
            }
            return Ok("Cost per hour inserted");
        }

        // PUT 
        [HttpPut]
        public async Task<ActionResult<String>> PutCostPerHour([FromBody] CostPerHour modality)
        {
            var mod = await _cost_per_hourServicescs.UpdateCostPerHour(modality);
            if (mod)
            {
                return Ok("Cost Per Hour updated");
            }
            return NotFound("Cost Per Hour not found");
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCostPerHour(int Id)
        {
            var mod = await _cost_per_hourServicescs.DeleteCostPerHour(Id);

            if (!mod)
            {
                return BadRequest("Cost Per Hour not found");
            }
            return Ok("Cost Per Hour not removed");
        }


    }
}
