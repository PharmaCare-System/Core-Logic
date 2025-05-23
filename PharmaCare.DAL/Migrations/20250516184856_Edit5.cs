using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Edit5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inventories_PharmacyId",
                table: "Inventories");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PharmacyId",
                table: "Inventories",
                column: "PharmacyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inventories_PharmacyId",
                table: "Inventories");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PharmacyId",
                table: "Inventories",
                column: "PharmacyId",
                unique: true,
                filter: "[PharmacyId] IS NOT NULL");
        }
    }
}
