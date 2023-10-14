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
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PaqueteTuristico.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("HotelSet");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.HotelPlan", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("SeasonId")
                        .HasColumnType("integer");

                    b.HasKey("HotelId", "SeasonId");

                    b.ToTable("Hotel_Plan");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Meal", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("HotelId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.HasIndex("HotelId");

                    b.ToTable("MealSet");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Room", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("HotelId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.HasIndex("HotelId");

                    b.ToTable("RoomSet");
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

            modelBuilder.Entity("PaqueteTuristico.Models.HotelPlan", b =>
                {
                    b.HasOne("PaqueteTuristico.Models.Hotel", "Hotel")
                        .WithMany("Plans")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaqueteTuristico.Models.Season", "Seasons")
                        .WithMany("HotelPlans")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Seasons");
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

            modelBuilder.Entity("PaqueteTuristico.Models.Hotel", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("Plans");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("PaqueteTuristico.Models.Season", b =>
                {
                    b.Navigation("HotelPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
