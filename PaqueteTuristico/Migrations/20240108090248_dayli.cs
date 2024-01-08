using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaqueteTuristico.Migrations
{
    /// <inheritdoc />
    public partial class dayli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplementaryContract_Dayli_Activities_ActivityId",
                table: "ComplementaryContract");

            migrationBuilder.DropIndex(
                name: "IX_ComplementaryContract_ActivityId",
                table: "ComplementaryContract");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "ComplementaryContract");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "ComplementaryContract",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComplementaryContract_ActivityId",
                table: "ComplementaryContract",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplementaryContract_Dayli_Activities_ActivityId",
                table: "ComplementaryContract",
                column: "ActivityId",
                principalTable: "Dayli_Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
