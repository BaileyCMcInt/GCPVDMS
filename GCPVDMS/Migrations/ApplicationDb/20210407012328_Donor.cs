using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class Donor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    donorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_id = table.Column<string>(nullable: true),
                    transaction_initiation_date = table.Column<string>(nullable: true),
                    currency_code = table.Column<string>(nullable: true),
                    transaction_value = table.Column<string>(nullable: true),
                    transaction_status = table.Column<string>(nullable: true),
                    given_name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    alt_full_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.donorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
