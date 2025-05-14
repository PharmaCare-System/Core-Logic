using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Pharmacists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Pharmacists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_ApplicationUserId1",
                table: "Pharmacists",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId1",
                table: "Customers",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId1",
                table: "Customers",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacists_AspNetUsers_ApplicationUserId1",
                table: "Pharmacists",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacists_AspNetUsers_ApplicationUserId1",
                table: "Pharmacists");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacists_ApplicationUserId1",
                table: "Pharmacists");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ApplicationUserId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Pharmacists",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pharmacists",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Pharmacists",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Pharmacists",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Pharmacists",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Pharmacists",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Pharmacists",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(YEAR, [Birthday], GETDATE())",
                stored: false);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Customers",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(YEAR, [Birthday], GETDATE())",
                stored: false);
        }
    }
}
