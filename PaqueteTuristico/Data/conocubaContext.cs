using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Dtos;
using PaqueteTuristico.Models;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Linq;


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

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Contract)
                .WithOne()
                .HasForeignKey<Hotel>(r => r.HotelId);

            modelBuilder.Entity<Room>()
               .HasMany(t => t.TourPackages)
               .WithOne()
               .HasForeignKey(t => t.RoomId);

            modelBuilder.Entity<Meal>()
               .HasMany(t => t.TourPackages)
               .WithOne()
               .HasForeignKey(t => t.MealId);


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

            modelBuilder.Entity<DayliActivities>()
                .HasOne(d => d.Contract)
                .WithOne()
                .HasForeignKey<DayliActivities>(d => d.ActivityId);

            base.OnModelCreating(modelBuilder);
        }          
               

    }

}
 