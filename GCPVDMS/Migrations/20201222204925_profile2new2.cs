using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations
{
    public partial class profile2new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "birthday",
                schema: "Identity",
                table: "User",
                newName: "Birthday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                schema: "Identity",
                table: "User",
                newName: "birthday");
        }
    }
}
