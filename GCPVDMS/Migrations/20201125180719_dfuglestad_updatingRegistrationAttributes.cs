using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations
{
    public partial class dfuglestad_updatingRegistrationAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "isDonor",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVolunteer",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDonor",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isVolunteer",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
