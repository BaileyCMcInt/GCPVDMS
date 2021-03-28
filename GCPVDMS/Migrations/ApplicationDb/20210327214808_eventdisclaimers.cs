using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class eventdisclaimers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDisclaimers",
                columns: table => new
                {
                    EventDisclaimerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(nullable: false),
                    DisclaimerID = table.Column<int>(nullable: false),
                    DislaimerID = table.Column<int>(nullable: true),
                    isSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDisclaimers", x => x.EventDisclaimerID);
                    table.ForeignKey(
                        name: "FK_EventDisclaimers_Disclaimers_DislaimerID",
                        column: x => x.DislaimerID,
                        principalTable: "Disclaimers",
                        principalColumn: "DisclaimerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventDisclaimers_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDisclaimers_DislaimerID",
                table: "EventDisclaimers",
                column: "DislaimerID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDisclaimers_EventID",
                table: "EventDisclaimers",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDisclaimers");
        }
    }
}
