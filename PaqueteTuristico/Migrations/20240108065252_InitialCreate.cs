using System;
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Modality",
                columns: table => new
                {
                    ModalityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modality", x => x.ModalityId);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceSet",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProvinceName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProvinceDesc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceSet", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Porcent = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IncluedVehicles = table.Column<int>(type: "integer", nullable: false)
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
                name: "CostPerHour",
                columns: table => new
                {
                    ModalityId = table.Column<int>(type: "integer", nullable: false),
                    cost_per_hour = table.Column<decimal>(type: "money", nullable: false),
                    cost_per_kilometer_traveled = table.Column<decimal>(type: "money", nullable: false),
                    extra_kilometer_cost = table.Column<decimal>(type: "money", nullable: false),
                    extra_hour_cost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostPerHour", x => x.ModalityId);
                    table.ForeignKey(
                        name: "FK_CostPerHour_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostPerTour",
                columns: table => new
                {
                    ModalityId = table.Column<int>(type: "integer", nullable: false),
                    rout_description = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    route_cost = table.Column<decimal>(type: "money", nullable: false),
                    round_trip_cost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostPerTour", x => x.ModalityId);
                    table.ForeignKey(
                        name: "FK_CostPerTour_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MileageCost",
                columns: table => new
                {
                    ModalityId = table.Column<int>(type: "integer", nullable: false),
                    cost_per_kilometer = table.Column<decimal>(type: "money", nullable: false),
                    cost_per_round_trip = table.Column<decimal>(type: "money", nullable: false),
                    cost_per_waiting_hour = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileageCost", x => x.ModalityId);
                    table.ForeignKey(
                        name: "FK_MileageCost_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dayli_Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    ContractId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dayli_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Dayli_Activities_ComplementaryContract_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "ComplementaryContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dayli_Activities_ProvinceSet_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "ProvinceSet",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Chain = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    NumberOfRooms = table.Column<int>(type: "integer", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    DisNearCity = table.Column<int>(type: "integer", nullable: false),
                    DisAirport = table.Column<int>(type: "integer", nullable: false),
                    NumberOfFloors = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    ComercializationMode = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    ContractId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotel_HotelContract_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotel_ProvinceSet_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "ProvinceSet",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    License_Plate_Number = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Brand = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Capacity_Without_Equipement = table.Column<int>(type: "integer", nullable: false),
                    Capacity_With_Equipement = table.Column<int>(type: "integer", nullable: false),
                    Total_Capacity = table.Column<int>(type: "integer", nullable: false),
                    Year_of_Manufacture = table.Column<int>(type: "integer", nullable: false),
                    Manufacturing_Mode = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    ContractId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_vehicles_ProvinceSet_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "ProvinceSet",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicles_TransportationContract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "TransportationContract",
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
                        principalColumn: "HotelId",
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
                    AmountofPeople = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportSet",
                columns: table => new
                {
                    ModalityId = table.Column<int>(type: "integer", nullable: false),
                    VehicleId = table.Column<int>(type: "integer", nullable: false),
                    Transport_Cost = table.Column<decimal>(type: "money", nullable: false),
                    ContractId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportSet", x => new { x.ModalityId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_TransportSet_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportSet_vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourPackagesSet",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    MealId = table.Column<int>(type: "integer", nullable: false),
                    VehicleId = table.Column<int>(type: "integer", nullable: true),
                    ModalityId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PeopleCant = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Totalprice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPackagesSet", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_TourPackagesSet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPackagesSet_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPackagesSet_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPackagesSet_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPackagesSet_TransportSet_ModalityId_VehicleId",
                        columns: x => new { x.ModalityId, x.VehicleId },
                        principalTable: "TransportSet",
                        principalColumns: new[] { "ModalityId", "VehicleId" });
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesperPackage",
                columns: table => new
                {
                    DayliActivitiesActivityId = table.Column<int>(type: "integer", nullable: false),
                    TourPackagePackageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesperPackage", x => new { x.DayliActivitiesActivityId, x.TourPackagePackageId });
                    table.ForeignKey(
                        name: "FK_ActivitiesperPackage_Dayli_Activities_DayliActivitiesActivi~",
                        column: x => x.DayliActivitiesActivityId,
                        principalTable: "Dayli_Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesperPackage_TourPackagesSet_TourPackagePackageId",
                        column: x => x.TourPackagePackageId,
                        principalTable: "TourPackagesSet",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesperPackage_TourPackagePackageId",
                table: "ActivitiesperPackage",
                column: "TourPackagePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dayli_Activities_ProvinceId",
                table: "Dayli_Activities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_ProvinceId",
                table: "Hotel",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_HotelId",
                table: "Meal",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesSet_HotelId",
                table: "TourPackagesSet",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesSet_MealId",
                table: "TourPackagesSet",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesSet_ModalityId_VehicleId",
                table: "TourPackagesSet",
                columns: new[] { "ModalityId", "VehicleId" });

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesSet_RoomId",
                table: "TourPackagesSet",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesSet_UserId",
                table: "TourPackagesSet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSet_VehicleId",
                table: "TransportSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_ContractId",
                table: "vehicles",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_ProvinceId",
                table: "vehicles",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesperPackage");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CostPerHour");

            migrationBuilder.DropTable(
                name: "CostPerTour");

            migrationBuilder.DropTable(
                name: "MileageCost");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Dayli_Activities");

            migrationBuilder.DropTable(
                name: "TourPackagesSet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ComplementaryContract");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "TransportSet");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Modality");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "HotelContract");

            migrationBuilder.DropTable(
                name: "ProvinceSet");

            migrationBuilder.DropTable(
                name: "TransportationContract");

            migrationBuilder.DropTable(
                name: "EContract");
        }
    }
}
