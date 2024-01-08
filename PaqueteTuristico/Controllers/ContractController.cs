using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractServices _services;
        

        public ContractController(ContractServices services)
        {
            this._services = services;
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<EContract>> GetContract(int id)
        {
            var contract = await _services.GetContractAsync(id);

            if (contract != null)
            {
                return Ok(contract);
            }
            else
            {
                return NotFound();
            }

        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<EContract>>> GetAllContracts()
        {
            var contractList = await _services.GetAllContractsAsync();
            if (contractList.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(contractList);
        }


    }
}
