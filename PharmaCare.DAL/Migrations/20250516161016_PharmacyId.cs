using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PharmacyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_MangerPharmacyId",
                table: "Pharmacies");

            migrationBuilder.AlterColumn<int>(
                name: "MangerPharmacyId",
                table: "Pharmacies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_MangerPharmacyId",
                table: "Pharmacies",
                column: "MangerPharmacyId",
                unique: true,
                filter: "[MangerPharmacyId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_MangerPharmacyId",
                table: "Pharmacies");

            migrationBuilder.AlterColumn<int>(
                name: "MangerPharmacyId",
                table: "Pharmacies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_MangerPharmacyId",
                table: "Pharmacies",
                column: "MangerPharmacyId",
                unique: true);
        }
    }
}
