using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class bmcintyreVolunGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VolunteerGroups",
                columns: table => new
                {
                    VolunteerGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerGroups", x => x.VolunteerGroupID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerGroups");
        }
    }
}
