using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class dfugle_addingCountyIDFKtoLocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountyID",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountyID",
                table: "Locations",
                column: "CountyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Counties_CountyID",
                table: "Locations",
                column: "CountyID",
                principalTable: "Counties",
                principalColumn: "CountyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Counties_CountyID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CountyID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CountyID",
                table: "Locations");
        }
    }
}
