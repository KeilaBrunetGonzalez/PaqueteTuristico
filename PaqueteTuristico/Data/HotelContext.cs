using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Data
{
    public class HotelContext : DbContext
    {
        public DbSet<Hotel> HotelSet { get; set; }
        public DbSet<Room> RoomSet { get; set; }
        public DbSet<Meal> MealSet { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Meal>()
                .HasOne(m => m.Hotel)
                .WithMany(h2 => h2.Meals)
                .HasForeignKey(m => m.HotelId);


            base.OnModelCreating(modelBuilder);
        }

    }

}
