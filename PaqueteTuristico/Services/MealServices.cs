using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class MealServices
    {
        private readonly conocubaContext _context;

        public MealServices(conocubaContext context)
        {
            this._context = context;
        }

        //Get
        public async Task<Meal?> GetMealAsync(int mealCode)
        {
            var existingMeal = await _context.MealSet.FindAsync(mealCode);
            if (existingMeal == null)
            {
                return null;

            }
            return existingMeal;
        }

        public async Task<List<Meal>?> GetMealsAsync(int hotelCode)
        {
            var list = await _context.MealSet
            .Where(H => H.HotelId == hotelCode)
            .ToListAsync();

            return list;
        }

        //Insert
        public async Task<int> InsertMealAsync(Meal meal)
        {
            var mealExists = await _context.MealSet.AnyAsync(r => r.Id == meal.Id && r.HotelId == meal.HotelId);

            if (mealExists)
            {
                return 1;
            }

            var hotel = await _context.HotelSet.FindAsync(meal.HotelId);

            if (hotel == null)
            {
                return 2;
            }

            hotel.Meals.Add(meal);
            await _context.MealSet.AddAsync(meal);
            await _context.SaveChangesAsync();

            return 0;
        }

        //Update
        public async Task<bool> UpdateMealAsync(Meal meal)
        {
            var existingMeal = await _context.MealSet.FirstAsync(R => R.Id == meal.Id && R.HotelId == meal.HotelId);
            var find = false;
            if (existingMeal != null)
            {
                _context.Entry(existingMeal).CurrentValues.SetValues(meal);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }


        //Delete
        public async Task<bool> DeleteMealAsync(int mealCode)
        {
            var existingMeal = await _context.MealSet.FirstAsync(R => R.Id == mealCode);
            var find = false;
            if (existingMeal != null)
            {
                _context.MealSet.Remove(existingMeal);
                await _context.SaveChangesAsync();
                find = true;

            }
            return find;
        }
    }
}
