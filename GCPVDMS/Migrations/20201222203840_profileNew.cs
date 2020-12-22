using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations
{
    public partial class profileNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPreferredContact",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SecondPreferredContact",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "birthday",
                schema: "Identity",
                table: "User");
        }
    }
}
