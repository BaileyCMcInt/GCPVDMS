using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class updatehours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nonEventInfo",
                table: "VolunteerHours");

            migrationBuilder.AddColumn<string>(
                name: "volunteerDescription",
                table: "VolunteerHours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "volunteerDescription",
                table: "VolunteerHours");

            migrationBuilder.AddColumn<string>(
                name: "nonEventInfo",
                table: "VolunteerHours",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
