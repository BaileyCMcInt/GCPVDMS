using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class rcook_countylocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress2",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountyState",
                table: "Counties",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "ApplicationUser",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "StreetAddress2",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CountyState",
                table: "Counties");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "ApplicationUser",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
