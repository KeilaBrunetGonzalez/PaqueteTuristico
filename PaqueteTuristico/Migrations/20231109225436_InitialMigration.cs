using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PaqueteTuristico.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EContract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Desc = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    StarDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndTime = table.Column<DateTime>(type: "date", nullable: false),
                    ConcilTime = table.Column<DateTime>(type: "date", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Chain = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Province = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Phone = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    NumberOfRooms = table.Column<int>(type: "integer", nullable: false),
                    DisNearCity = table.Column<int>(type: "integer", nullable: false),
                    DisAirport = table.Column<int>(type: "integer", nullable: false),
                    NumberOfFloors = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    ComercializationMode = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modality",
                columns: table => new
                {
                    modality_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modality", x => x.modality_id);
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
                name: "ComplementaryContract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ServiceType = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    CostPerPerson = table.Column<decimal>(type: "money", nullable: false),
                    ComplementaryServiceProvince = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplementaryContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplementaryContract_EContract_Id",
                        column: x => x.Id,
                        principalTable: "EContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelContract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    HotelTotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelContract_EContract_Id",
                        column: x => x.Id,
                        principalTable: "EContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportationContract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    TransportationProvider = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    IncluedVehicles = table.Column<int>(type: "integer", nullable: false),
                    LicensePlateNumber = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationContract_EContract_Id",
                        column: x => x.Id,
                        principalTable: "EContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostPerHour",
                columns: table => new
                {
                    modality_id = table.Column<int>(type: "integer", nullable: false),
                    cost_per_hour = table.Column<float>(type: "real", nullable: false),
                    cost_per_kilometer_traveled = table.Column<float>(type: "real", nullable: false),
                    extra_kilometer_cost = table.Column<float>(type: "real", nullable: false),
                    extra_hour_cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostPerHour", x => x.modality_id);
                    table.ForeignKey(
                        name: "FK_CostPerHour_Modality_modality_id",
                        column: x => x.modality_id,
                        principalTable: "Modality",
                        principalColumn: "modality_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostPerTour",
                columns: table => new
                {
                    modality_id = table.Column<int>(type: "integer", nullable: false),
                    rout_description = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    route_cost = table.Column<float>(type: "real", nullable: false),
                    round_trip_cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostPerTour", x => x.modality_id);
                    table.ForeignKey(
                        name: "FK_CostPerTour_Modality_modality_id",
                        column: x => x.modality_id,
                        principalTable: "Modality",
                        principalColumn: "modality_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MileageCost",
                columns: table => new
                {
                    modality_id = table.Column<int>(type: "integer", nullable: false),
                    cost_per_kilometer = table.Column<float>(type: "real", nullable: false),
                    cost_per_round_trip = table.Column<float>(type: "real", nullable: false),
                    cost_per_waiting_hour = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileageCost", x => x.modality_id);
                    table.ForeignKey(
                        name: "FK_MileageCost_Modality_modality_id",
                        column: x => x.modality_id,
                        principalTable: "Modality",
                        principalColumn: "modality_id",
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
                        name: "FK_Hotel_Plan_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
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
                name: "IX_Meal_HotelId",
                table: "Meal",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplementaryContract");

            migrationBuilder.DropTable(
                name: "CostPerHour");

            migrationBuilder.DropTable(
                name: "CostPerTour");

            migrationBuilder.DropTable(
                name: "Hotel_Plan");

            migrationBuilder.DropTable(
                name: "HotelContract");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "MileageCost");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "TransportationContract");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Modality");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "EContract");
        }
    }
}
