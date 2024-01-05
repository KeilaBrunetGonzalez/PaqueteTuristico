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
    }



}
