using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly conocubaContext _context;

        public MealController(conocubaContext context)
        {
            this._context = context;
        }

        //GET

        [HttpGet("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<ActionResult<Meal>> GetMealAsync(int MealId)
        {
            var m = await _context.MealSet.FindAsync(MealId);

            if (m != null)
            {
                return Ok(m);
            }

            return NotFound();
        }
        //POST
        [HttpPost("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<ActionResult<Meal>> PostMeal([FromBody] Meal meal)
        {
            var mealExists = await _context.MealSet.AnyAsync(M => M.Id == meal.Id && M.HotelId == meal.HotelId);

            if (mealExists)
            {
                return BadRequest("Meal with the specified Id already exists in the hotel");
            }

            var hotel = await _context.HotelSet.FindAsync(meal.HotelId);

            if (hotel == null)
            {
                return NotFound("Hotel not found");
            }

            hotel.Meals.Add(meal);
            await _context.MealSet.AddAsync(meal);
            await _context.SaveChangesAsync();

            return Ok("Hotel Meal created");
        }

        //PUT
        [HttpPut("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<IActionResult> PutMeal([FromBody] Meal meal)
        {
            var mealExists = await _context.MealSet.FirstAsync(M => M.Id == meal.Id && M.HotelId == meal.HotelId);

            if (mealExists != null)
            {
                _context.Entry(mealExists).CurrentValues.SetValues(meal);
                await _context.SaveChangesAsync();

                return Ok("Hotel Meal updated");
            }

            return NotFound("Hotel Meal not found");
        }

        //DELETE

        [HttpDelete("/hotels/Hotel_ID/meals/MEAL_ID")]
        public async Task<ActionResult<Meal>> DeleteMeal(int MealId, int HotelId)
        {

           var m = await _context.MealSet.FirstAsync(M => M.Id == MealId && M.HotelId == HotelId);

           if (m != null)
           {
                _context.MealSet.Remove(m);
                await _context.SaveChangesAsync();
                return Ok("Hotel Meal removed");
            }

            return NotFound("Hotel Meal not found");

        }

    }
}
