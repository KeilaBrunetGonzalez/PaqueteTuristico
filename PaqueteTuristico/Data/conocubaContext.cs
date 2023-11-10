using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Models;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace PaqueteTuristico.Data
{
    public class conocubaContext : DbContext
    {
        public DbSet<Hotel> HotelSet { get; set; }
        public DbSet<Room> RoomSet { get; set; }
        public DbSet<Meal> MealSet { get; set; }
        public DbSet<EContract> EContractSet { get; set; }
        public DbSet<ComplementaryContract> ComplementaryContractSet { get; set; }
        public DbSet<HotelContract> HotelContractSet { get; set; }
        public DbSet<TransportationContract> TransportationContractSet { get; set; }
        public DbSet<HotelPlan> HotelPlanSet { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Modality> ModalitySet { get; set; }
        public DbSet<CostPerHour> Cost_Per_HoursSet { get; set; }
        public DbSet<CostPerTour> Cost_Per_ToursSet { get; set; }
        public DbSet<MileageCost> Mileage_CostsSet { get; set; }


        public conocubaContext(DbContextOptions<conocubaContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne()
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Meals)
                .WithOne()
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HotelPlan>()
                .HasKey(p => new
                {
                    p.HotelId,
                    p.SeasonId
                });

            modelBuilder.Entity<Season>()
                .HasMany(t => t.HotelPlans)
                .WithOne(x => x.Seasons);




        }          
               

    }

}
 