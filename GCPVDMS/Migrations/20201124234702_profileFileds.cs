using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations
{
    public partial class profileFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                schema: "Identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredContact",
                schema: "Identity",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "County",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PreferredContact",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Availablity",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationPreference",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
