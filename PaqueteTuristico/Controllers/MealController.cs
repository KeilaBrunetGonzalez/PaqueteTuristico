using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly MealServices _services;

        public MealController(MealServices _services)
        {
            this._services = _services;
        }

        //GET
        [HttpGet("{mealId}")]
        public async Task<ActionResult<Meal>> GetMeal(int mealId)
        {
            var meal = await _services.GetMealAsync(mealId);

            if (meal != null)
            {
                return Ok(meal);
            }

            return NotFound();
        }

        [HttpGet("{hotelId}")]
        public async Task<ActionResult<List<Models.Meal>>> GetMealsByHotelId(int hotelId)
        {
            var list = await _services.GetMealsAsync(hotelId);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);

        }

        [HttpGet]

        public async Task<ActionResult<List<Models.Meal>>> GetMeals()
        {
            var list = await _services.GetMealsAsync();
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(list);
        }

        //POST

        [HttpPost]
        public async Task<ActionResult<string>> PostMeal([FromBody] Meal meal)
        {
            var id = await _services.GetLastMealIdAsync();
            meal.Id = ++id;
            var option = await _services.InsertMealAsync(meal);

            if (option == 1)
            {
                return BadRequest("Meal with the specified Id already exists in the hotel");
            }

            if (option == 2)
            {
                return NotFound("Hotel not found");
            }

            return Ok("Hotel Meal created");
        }


        //PUT
        [HttpPut]
        public async Task<ActionResult<string>> PutMeal([FromBody] Meal meal)
        {

            var updated = await _services.UpdateMealAsync(meal);

            if (updated)
            {
                return Ok("Hotel Meal updated");
            }

            return NotFound("Hotel Meal not found");
        }

        //DELETE
        [HttpDelete("{mealId}")]
        public async Task<ActionResult<string>> DeleteMeal(int mealId)
        {

            var removed = await _services.DeleteMealAsync(mealId);
            if (removed)
            {
                return Ok("Hotel Meal removed");
            }

            return NotFound("Hotel Meal not found");
        }

    }
}
