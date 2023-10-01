using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Models;
using System.Reflection;

namespace PaqueteTuristico.Data
{
    public class HotelContext : DbContext
    {
        public DbSet<Hotel> HotelSet { get; set; }
        public DbSet<Room> RoomSet { get; set; }
        public DbSet<Meal> MealSet { get; set; }
        public DbSet<HotelPlan> HotelPlanSet { get; set; }
        public DbSet<Season> Seasons { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Meal>()
                .HasOne(m => m.Hotel)
                .WithMany(h2 => h2.Meals)
                .HasForeignKey(p => p.HotelId);

            modelBuilder.Entity<HotelPlan>()
                .HasKey(e => new {
                     e.HotelId,
                     e.SeasonId
                });
                
            base.OnModelCreating(modelBuilder);
        }

    }

}
