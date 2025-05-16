using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Edit6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Pharmacies_PharmacyId",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Pharmacies_PharmacyId",
                table: "Inventories",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Pharmacies_PharmacyId",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                table: "Inventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Pharmacies_PharmacyId",
                table: "Inventories",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }
    }
}
