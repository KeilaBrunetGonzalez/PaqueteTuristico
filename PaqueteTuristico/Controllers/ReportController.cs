using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportServices _services;
        public ReportController(ReportServices services)
        {
            this._services = services;
        }

        //Reporte de contratos de hoteles conciliados
        [HttpGet("ConcilHotelContractDetails")]
        public IActionResult GetHotelContractDetails()
        {
            var concilCont = _services.GetConcilHotelContracts();

            if (concilCont != null)
            {
                return Ok(concilCont);
            }

            return NotFound();
        }

        //Reporte de listado de contratos de transporte
        /*[HttpGet("TransportationContractList")]
        public IActionResult GetTransportContractsDetails()
        {
            var transpCont = _services.GetTransportContractsList();

            if (transpCont != null)
            {
                return Ok(transpCont);
            }

            return NotFound();
        }*/

        //Reporte de listado de temporadas de los contratos de hoteles
        [HttpGet("HotelContractsBySeason")]
        public IActionResult GetHotelContractsBySeasonDetails()
        {
            var seasonConts = _services.GetHotelContractsBySeason();

            if(seasonConts != null)
            {
                return Ok(seasonConts);
            }
            return NotFound();
        }

        //Reporte de listado de hoteles activos
        [HttpGet("ActivesHotels")]
        public IActionResult GetActivesHotelsDetails()
        {
            var actives = _services.GetActivesHotels();

            if (actives != null)
            {
                return Ok(actives);
            }
            return NotFound();
        }
    }
}

