/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly ProvinceService _services;

        public ProvinceController(ProvinceService _services)
        {
            this._services = _services;
        }


        // GET 
        [HttpGet("{ProvinceId}")]
        public async Task<ActionResult<Province>> GetProvinceAsync(int ProvinceId)
        {
            var province = await _services.GetProvinceAsync(ProvinceId);

            if (province != null)
            {
                return Ok(province);
            }

            return NotFound();
        }


        // GET: api/<Province>
        [HttpGet]

        public async Task<ActionResult<List<Models.Province>>> GetProvincesByProvinceId()
        {
            var list = await _services.GetProvincesAsync();
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
        }


        // POST : api/<Province>
        [HttpPost]
        public async Task<ActionResult<String>> PostProvince([FromBody] Province province)
        {
            var id = await _services.GetLastProvinceIdAsync();
            province.ProvinceId = ++id;

            var inserted = await _services.InsertProvinceAsync(province);

            if (inserted)
            {
                return Ok("Province inserted");
            }

            return BadRequest("Province already exist");
        }

        // PUT: api/<Province>
        [HttpPut]
        public async Task<ActionResult<String>> PutProvince([FromBody] Province province)
        {
            var updated = await _services.UpdateProvinceAsync(province);

            if (updated)
            {
                return Ok("Province updated");
            }
            return NotFound("Province not found");
        }


        // DELETE: api/Province

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteProvince(int Id)
        {
            var removed = await _services.DeleteProvinceAsync(Id);

            if (removed)
            {
                return Ok("Province removed");
            }
            return NotFound("Province not found");
        }


    }



}
*/