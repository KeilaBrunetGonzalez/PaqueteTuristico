using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace PaqueteTuristico.Data
{
    public class conocubaContext : IdentityDbContext<UserApp,IdentityRole,string>
    {
        public DbSet<Hotel> HotelSet { get; set; }
        public DbSet<Room> RoomSet { get; set; }
        public DbSet<Meal> MealSet { get; set; }
        public DbSet<EContract> EContractSet { get; set; }
        public DbSet<ComplementaryContract> ComplementaryContractSet { get; set; }
        public DbSet<HotelContract> HotelContractSet { get; set; }
        public DbSet<TransportationContract> TransportationContractSet { get; set; }
        public DbSet<HotelPlan> HotelPlanSet { get; set; }
        public DbSet<Season> SeasonSet { get; set; }
        public DbSet<Modality> ModalitySet { get; set; }
        public DbSet<CostPerHour> Cost_Per_HoursSet { get; set; }
        public DbSet<CostPerTour> Cost_Per_ToursSet { get; set; }
        public DbSet<MileageCost> Mileage_CostsSet { get; set; }
        public DbSet<DayliActivities> DayliActivitieSet { get; set; }
        public DbSet<Transport> TransportSet { get; set; }
        public DbSet<Vehicle> VehicleSet { get; set; }
        public DbSet<TourPackage> TourPackagesSet { get; set; }
        public DbSet<Province> ProvinceSet { get; set; }

        public conocubaContext(DbContextOptions<conocubaContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

           

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

            modelBuilder.Entity<Hotel>()
                .HasMany(t => t.TourPackages)
                .WithOne()
                .HasForeignKey(t => t.HotelId);

            modelBuilder.Entity<Room>()
               .HasMany(t => t.TourPackages)
               .WithOne()
               .HasForeignKey(t => t.RoomId);

            modelBuilder.Entity<Meal>()
               .HasMany(t => t.TourPackages)
               .WithOne()
               .HasForeignKey(t => t.MealId);


            modelBuilder.Entity<HotelPlan>()
                .HasKey(p => new
                {
                    p.HotelId,
                    p.SeasonId
                });

            modelBuilder.Entity<HotelPlan>()
                .HasOne(x => x.Season)
                .WithMany(r => r.Plans)
                .HasForeignKey(y => y.SeasonId);

            modelBuilder.Entity<HotelPlan>()
                .HasOne(n => n.Hotel)
                .WithMany(x => x.Plans)
                .HasForeignKey(y => y.HotelId);

            modelBuilder.Entity<Transport>()
                .HasKey(n => new
                {
                    n.ModalityId,
                    n.VehicleId
                });

            modelBuilder.Entity<Transport>()
                .HasOne(s => s.Vehicle)
                .WithMany(t => t.Transports)
                .HasForeignKey(r => r.VehicleId);

            modelBuilder.Entity<Transport>()
                .HasOne(s => s.Modality)
                .WithMany(n => n.Transports)
                .HasForeignKey(r => r.ModalityId);

            modelBuilder.Entity<HotelContract>()
                .HasOne(s => s.Hotel)
                .WithOne()
                .HasForeignKey<HotelContract>(n => n.Hotelid
                );

            modelBuilder.Entity<ComplementaryContract>()
                .HasOne(a => a.Activity)
                .WithOne()
                .HasForeignKey<ComplementaryContract>(c => c.ActivityId);

            modelBuilder.Entity<TransportationContract>()
                .HasMany(s => s.Vehicles)
                .WithOne()
                .HasForeignKey(j => j.ContractId);

            modelBuilder.Entity<Transport>()
                .HasMany(y => y.TourPackages)
                .WithOne()
                .HasForeignKey(x => new
                {
                    x.ModalityId,
                    x.VehicleId
                });

            modelBuilder.Entity<TourPackage>()
                .HasMany(d => d.DayliActivities)
                .WithMany()
                .UsingEntity(j => j.ToTable("ActivitiesperPackage"));

            modelBuilder.Entity<UserApp>()
                .HasMany(u => u.TourPackages)
                .WithOne()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Province>()
                .HasMany(h => h.Hotels)
                .WithOne()
                .HasForeignKey(x => x.ProvinceId);

            modelBuilder.Entity<Province>()
                .HasMany(h => h.DaylActivities)
                .WithOne()
                .HasForeignKey(x => x.ProvinceId);

            modelBuilder.Entity<Province>()
                .HasMany(h => h.Vehicles)
                .WithOne()
                .HasForeignKey(x => x.ProvinceId);
           

            base.OnModelCreating(modelBuilder);
        }          
               

    }

}
 