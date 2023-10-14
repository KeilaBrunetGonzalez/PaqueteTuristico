﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PaqueteTuristico.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "MealSet",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealSet", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MealSet_HotelSet_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomSet",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSet", x => x.Name);
                    table.ForeignKey(
                        name: "FK_RoomSet_HotelSet_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel_Plan",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    SeasonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_Plan", x => new { x.HotelId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_Hotel_Plan_HotelSet_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotel_Plan_Season_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Season",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealSet_HotelId",
                table: "MealSet",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSet_HotelId",
                table: "RoomSet",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel_Plan");

            migrationBuilder.DropTable(
                name: "MealSet");

            migrationBuilder.DropTable(
                name: "RoomSet");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "HotelSet");
        }
    }
}