using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class EVETDI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDisclaimers",
                columns: table => new
                {
                    GCPEventDisclaimerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(nullable: false),
                    DisclaimerID = table.Column<int>(nullable: false),
                    isSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDisclaimers", x => x.GCPEventDisclaimerID);
                    table.ForeignKey(
                        name: "FK_EventDisclaimers_Disclaimers_DisclaimerID",
                        column: x => x.DisclaimerID,
                        principalTable: "Disclaimers",
                        principalColumn: "DisclaimerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDisclaimers_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDisclaimers_DisclaimerID",
                table: "EventDisclaimers",
                column: "DisclaimerID");

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
