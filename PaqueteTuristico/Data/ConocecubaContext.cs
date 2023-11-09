using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Models;
using System.Reflection;

namespace PaqueteTuristico.Data
{
    public class ConocecubaContext : DbContext
    {
        public DbSet<Hotel> HotelSet { get; set; }
        public DbSet<Room> RoomSet { get; set; }
        public DbSet<Meal> MealSet { get; set; }
        public DbSet<HotelPlan> HotelPlanSet { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Modality> ModalitySet { get; set; }
        public DbSet<Cost_per_hour> Cost_Per_HoursSet { get; set; }
        public DbSet<Cost_per_tour> Cost_Per_ToursSet { get; set; }
        public DbSet<Mileage_cost> Mileage_CostsSet { get; set; }
        public DbSet<DayliActivities> DayliActivitieSet { get; set; }
        public DbSet<Vehicle> VehicleSet { get; set; }
        public DbSet<Transport> TransportSet { get; set; }

        public ConocecubaContext(DbContextOptions<ConocecubaContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Meal>()
                .HasOne(m => m.Hotel)
                .WithMany(h2 => h2.Meals)
                .HasForeignKey(m => m.HotelId);

           modelBuilder.Entity<HotelPlan>()
                .HasKey(r => new 
                { r.HotelId, 
                  r.SeasonId }
                );

            modelBuilder.Entity<HotelPlan>()
                .HasOne(h => h.Hotel)
                .WithMany(s => s.Plans)
                .HasForeignKey(s => s.HotelId);
                

            modelBuilder.Entity<HotelPlan>()
                .HasOne(t => t.Season)
                .WithMany(s => s.Plans) 
                .HasForeignKey(h => h.SeasonId);

            modelBuilder.Entity<Transport>()
                .HasKey(t => new
                {
                    t.ModalityId,
                    t.VehicleId
                });

            modelBuilder.Entity<Transport>()
                .HasOne(t => t.Modality)
                .WithMany(s => s.Transports)
                .HasForeignKey(tm  => tm.ModalityId);

            modelBuilder.Entity<Transport>()
                .HasOne(t =>t.Vehicle)
                .WithMany(s => s.Transports)
                .HasForeignKey(tv => tv.VehicleId);

             
        }          
               

    }

}
 