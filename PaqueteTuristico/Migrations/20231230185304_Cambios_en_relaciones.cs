using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaqueteTuristico.Migrations
{
    /// <inheritdoc />
    public partial class Cambios_en_relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPackagesSet_Dayli_Activities_ActivityId",
                table: "TourPackagesSet");

            migrationBuilder.DropIndex(
                name: "IX_TourPackagesSet_ActivityId",
                table: "TourPackagesSet");

            migrationBuilder.AddColumn<int>(
                name: "PeopleCant",
                table: "TourPackagesSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserAppId",
                table: "TourPackagesSet",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TourPackagesSet",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                name: "IX_TourPackagesSet_UserAppId",
                table: "TourPackagesSet",
                column: "UserAppId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesSet_UserId",
                table: "TourPackagesSet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesperPackage_TourPackagePackageId",
                table: "ActivitiesperPackage",
                column: "TourPackagePackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackagesSet_AspNetUsers_UserAppId",
                table: "TourPackagesSet",
                column: "UserAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackagesSet_AspNetUsers_UserId",
                table: "TourPackagesSet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPackagesSet_AspNetUsers_UserAppId",
                table: "TourPackagesSet");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackagesSet_AspNetUsers_UserId",
                table: "TourPackagesSet");

            migrationBuilder.DropTable(
                name: "ActivitiesperPackage");

            migrationBuilder.DropIndex(
                name: "IX_TourPackagesSet_UserAppId",
                table: "TourPackagesSet");

            migrationBuilder.DropIndex(
                name: "IX_TourPackagesSet_UserId",
                table: "TourPackagesSet");

            migrationBuilder.DropColumn(
                name: "PeopleCant",
                table: "TourPackagesSet");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "TourPackagesSet");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TourPackagesSet");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesSet_ActivityId",
                table: "TourPackagesSet",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackagesSet_Dayli_Activities_ActivityId",
                table: "TourPackagesSet",
                column: "ActivityId",
                principalTable: "Dayli_Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
