using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class _99 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nonEventInfo",
                table: "VolunteerHours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nonEventInfo",
                table: "VolunteerHours");
        }
    }
}
