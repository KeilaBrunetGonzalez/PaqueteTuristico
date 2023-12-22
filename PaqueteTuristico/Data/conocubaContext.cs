﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Models;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace PaqueteTuristico.Data
{
    public class conocubaContext : IdentityDbContext<IdentityUser,IdentityRole,string>
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
        public DbSet<TrasportWithContract> TrasportWithContractsSet { get; set; }
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
                .HasOne(p => p.Province)
                .WithMany(h => h.Hotels)
                .HasForeignKey(i => i.ProvinceId);

            modelBuilder.Entity<Hotel>()
                .HasMany(t => t.TourPackages)
                .WithOne(t => t.Hotel)
                .HasForeignKey(t => t.HotelId);
            

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
                .HasOne(s => s.Plan)
                .WithMany(p => p.Contracts)
                .HasForeignKey(n => new
                {
                    n.Seasonid,
                    n.Hotelid
                });
            modelBuilder.Entity<ComplementaryContract>()
                .HasMany(d => d.DayliActivities)
                .WithMany(c => c.Complementary)
                .UsingEntity(j => j.ToTable("ActivitiesWhithContracts"));

            modelBuilder.Entity<TransportationContract>()
                .HasMany(s => s.Transports)
                .WithMany(x => x.Contract)
                .UsingEntity<TrasportWithContract>( j => 
                j.HasKey(t => new
                {
                    t.id,
                    t.Modalityid,
                    t.Vehicleid
                }));

            

            modelBuilder.Entity<TourPackage>()
                .HasOne(y => y.Transport)
                .WithMany()
                .HasForeignKey(x => new
                {
                    x.ModalityId,
                    x.VehicleId
                });
            modelBuilder.Entity<TourPackage>()
                .HasOne(d => d.DayliActivities)
                .WithMany()
                .HasForeignKey(j => j.ActivityId);

            base.OnModelCreating(modelBuilder);
        }          
               

    }

}
 