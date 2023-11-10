﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaqueteTuristico.Data;

#nullable disable

namespace PaqueteTuristico.Migrations
{
    [DbContext(typeof(ConocecubaContext))]
    partial class ConocecubaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PaqueteTuristico.Models.DayliActivities", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ActivityId"));

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<TimeOnly>("Hour")
                        .HasColumnType("time");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("ActivityId");

                    b.ToTable("Dayli_Activities");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.HotelPlan", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("SeasonId")
                        .HasColumnType("integer");

                    b.HasKey("HotelId", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Hotel_Plan");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Modality", b =>
                {
                    b.Property<int>("ModalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ModalityId"));

                    b.HasKey("ModalityId");

                    b.ToTable("Modality");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SeasonId"));

                    b.Property<string>("SeasonName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("SeasonId");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Transport", b =>
                {
                    b.Property<int>("ModalityId")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.Property<float>("Transport_Cost")
                        .HasColumnType("real");

                    b.HasKey("ModalityId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("TransportSet");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Capacity_With_Equipement")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity_Without_Equipement")
                        .HasColumnType("integer");

                    b.Property<string>("License_Plate_Number")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Manufacturing_Mode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Total_Capacity")
                        .HasColumnType("integer");

                    b.Property<int>("Year_of_Manufacture")
                        .HasColumnType("integer");

                    b.HasKey("VehicleId");

                    b.ToTable("vehicles");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Cost_per_hour", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.Modality");

                    b.Property<float>("CostperHour")
                        .HasColumnType("real");

                    b.Property<float>("CostperKilometerTraveled")
                        .HasColumnType("real");

                    b.Property<float>("ExtraHour_cost")
                        .HasColumnType("real");

                    b.Property<float>("ExtraKilometer_cost")
                        .HasColumnType("real");

                    b.ToTable("Cost_per_hour");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Cost_per_tour", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.Modality");

                    b.Property<float>("Round_Trip_cost")
                        .HasColumnType("real");

                    b.Property<string>("Rout_Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<float>("Route_cost")
                        .HasColumnType("real");

                    b.ToTable("cost_per_tour");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Mileage_cost", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.Modality");

                    b.Property<float>("cost_per_kilometer")
                        .HasColumnType("real");

                    b.Property<float>("cost_per_round_trip")
                        .HasColumnType("real");

                    b.Property<float>("cost_per_waiting_hour")
                        .HasColumnType("real");

                    b.ToTable("Mileage_cost");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.HotelPlan", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Hotel", "Hotel")
                        .WithMany("Plans")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaqueteTuristico.Models.Season", "Season")
                        .WithMany("Plans")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Meal", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Hotel", "Hotel")
                        .WithMany("Meals")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Room", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Transport", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Modality", "Modality")
                        .WithMany("Transports")
                        .HasForeignKey("ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaqueteTuristico.Models.Vehicle", "Vehicle")
                        .WithMany("Transports")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modality");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Cost_per_hour", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Modality", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.Cost_per_hour", "ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Cost_per_tour", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Modality", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.Cost_per_tour", "ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Mileage_cost", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Modality", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.Mileage_cost", "ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Hotel", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("Plans");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Modality", b =>
                {
                    b.Navigation("Transports");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Season", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Vehicle", b =>
                {
                    b.Navigation("Transports");
                });
#pragma warning restore 612, 618
        }
    }
}
