using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class profileFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPreferredContact",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "SecondPreferredContact",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "ApplicationUser");
        }
    }
}
