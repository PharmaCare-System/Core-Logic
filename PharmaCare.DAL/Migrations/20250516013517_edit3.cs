﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class edit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inventories_PharmacyId",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                table: "Inventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PharmacyId",
                table: "Inventories",
                column: "PharmacyId",
                unique: true,
                filter: "[PharmacyId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inventories_PharmacyId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PharmacyId",
                table: "Inventories",
                column: "PharmacyId",
                unique: true);
        }
    }
}
