using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TourPackageController : ControllerBase
    {
        private readonly TourPackageServices _services;

        public TourPackageController(TourPackageServices _services)
        {
            this._services = _services;
        }


        // GET 
        [HttpGet("GetTourPackages")]
        public IActionResult GetTourPackages()
        {
            var tourPackages = _services.GetAllTourPackages();

            if (tourPackages != null)
            {
                return Ok(tourPackages);
            }

            return NotFound();
        }

       /* [HttpPost]
        public async Task<ActionResult<string>> PostRoom([FromBody] TourPackage tp, ICollection<DayliActivities> das)
        {
            var id = await _services.GetLastTourPackageIdAsync();
            tp.PackageId = ++id;

            var option = await _services.InsertTouPackageAsync(tp,das);

            if (!option)
            {
                return BadRequest("Tour Package with the specified Id already exists");
            }

            return Ok("Tour Package created");
        }*/

    }



}
