using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class addingloginfeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<bool>(
                name: "FirstTimeLogin",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTimeLogin",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "ApplicationUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
