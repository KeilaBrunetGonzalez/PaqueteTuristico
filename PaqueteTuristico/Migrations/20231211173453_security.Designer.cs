﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaqueteTuristico.Data;

#nullable disable

namespace PaqueteTuristico.Migrations
{
    [DbContext(typeof(conocubaContext))]
    [Migration("20231211173453_security")]
    partial class security
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("ActivityId");

                    b.ToTable("Dayli_Activities");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.EContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ConcilTime")
                        .HasColumnType("date");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("date");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("EContract");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Chain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("ComercializationMode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("DisAirport")
                        .HasColumnType("integer");

                    b.Property<int>("DisNearCity")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("NumberOfFloors")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("integer");

                    b.Property<int>("Phone")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

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

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

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

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

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

            modelBuilder.Entity("PaqueteTuristico.Models.ComplementaryContract", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.EContract");

                    b.Property<string>("ComplementaryServiceProvince")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<decimal>("CostPerPerson")
                        .HasColumnType("money");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.ToTable("ComplementaryContract");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.HotelContract", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.EContract");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<decimal>("HotelTotalPrice")
                        .HasColumnType("money");

                    b.ToTable("HotelContract");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.TransportationContract", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.EContract");

                    b.Property<int>("IncluedVehicles")
                        .HasColumnType("integer");

                    b.Property<string>("LicensePlateNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("TransportationProvider")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.ToTable("TransportationContract");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.CostPerHour", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.Modality");

                    b.Property<float>("cost_per_hour")
                        .HasColumnType("real");

                    b.Property<float>("cost_per_kilometer_traveled")
                        .HasColumnType("real");

                    b.Property<float>("extra_hour_cost")
                        .HasColumnType("real");

                    b.Property<float>("extra_kilometer_cost")
                        .HasColumnType("real");

                    b.ToTable("CostPerHour");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.CostPerTour", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.Modality");

                    b.Property<float>("round_trip_cost")
                        .HasColumnType("real");

                    b.Property<string>("rout_description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<float>("route_cost")
                        .HasColumnType("real");

                    b.ToTable("CostPerTour");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.MileageCost", b =>
                {
                    b.HasBaseType("PaqueteTuristico.Models.Modality");

                    b.Property<float>("cost_per_kilometer")
                        .HasColumnType("real");

                    b.Property<float>("cost_per_round_trip")
                        .HasColumnType("real");

                    b.Property<float>("cost_per_waiting_hour")
                        .HasColumnType("real");

                    b.ToTable("MileageCost");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("PaqueteTuristico.Models.Hotel", null)
                        .WithMany("Meals")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Room", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Hotel", null)
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("PaqueteTuristico.Models.ComplementaryContract", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.EContract", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.ComplementaryContract", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.HotelContract", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.EContract", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.HotelContract", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.TransportationContract", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.EContract", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.TransportationContract", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.CostPerHour", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Modality", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.CostPerHour", "ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.CostPerTour", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Modality", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.CostPerTour", "ModalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteTuristico.Models.MileageCost", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Modality", null)
                        .WithOne()
                        .HasForeignKey("PaqueteTuristico.Models.MileageCost", "ModalityId")
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
